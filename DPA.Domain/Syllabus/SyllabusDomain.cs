using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.Mapping;
using DPA.Domain.Syllabus;
using DPA.Domain.UnitLesson;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.LocationModel.Dtos;
using DPA.Model.Models.SyllabusModel.Dtos;
using DPA.Model.Models.UserModel.Dtos;

namespace DPA.Domain
{
    public class SyllabusDomain
    {
        protected internal SyllabusDomain(long departmentId, PeriodType periodType, EducationType educationType)
        {
            DepartmentId = departmentId;
            PeriodType = periodType;
            EducationType = educationType;
            Year = (int)educationType == 1 ? DateTime.Now.Year : DateTime.Now.Year + 1;
        }

        #region prop
        public int Year { get; private set; }
        public PeriodType PeriodType { get; private set; }
        public EducationType EducationType { get; private set; }
        public int WeeklyHour { get; private set; }
        public long DepartmentId { get; private set; }
        public virtual DepartmentEntity Department { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime UpdatedDate { get; private set; } = DateTime.Now;

        public virtual List<UnitLessonEntity> UnitLessons { get; private set; } = new List<UnitLessonEntity>();

        public virtual List<LessonBlock> LessonBlocks { get; private set; } = new List<LessonBlock>();

        #endregion

        public void AddUnitLesson(UnitLessonEntity unitLessons)
        {
            UnitLessons.Add(unitLessons);
        }
        #region DEFAULT PROGRAM OLUŞTURMA
        public void CreateSyllabusDefaultTable(EducationType educationType)
        {
            if ((int)educationType == 1)
                CreatorTimeTable(9, 15);
            else
                CreatorTimeTable(15, 23);

        }
        private void CreatorTimeTable(int startTime, int endTime)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = startTime; j < endTime; j++)
                {
                    var unitLessonDomain = UnitLessonDomainFactory.Create();
                    unitLessonDomain.AddTime((DayOfTheWeekType)i, j, j + 1);
                    var unitEntity = unitLessonDomain.Map<UnitLessonEntity>();
                    AddUnitLesson(unitEntity);
                }
            }
        }
        #endregion

        #region DERS ATAMA
        public void AssignToLesson(List<SyllabusForLessonWithGroupListDto> lessons, CreateSyllabusRequest request,EducationType educationType)
        {
            var lessonsss = lessons.OrderBy(x => x.SemesterType == SemesterType.One).ToList();
            var lesson = lessonsss.First();
            while (lessonsss.Count != 0)
            {
                foreach (var group in lesson.LessonGroups)
                {
                    var blocks = AssignLessonCheckCriteria(lesson, group.GroupType, educationType);
                    int blckId = LessonBlocks.Count + 1;

                    foreach (var item in blocks)
                    {
                        item.BlockId = LessonBlocks.Count + 1;
                        LessonBlocks.Add(item);
                    }
                }
                lessonsss.Remove(lesson);
                lessonsss.Shuffle();
                if (lessonsss.Count > 0)
                    lesson = lessonsss.First();
            }
        }

        private List<LessonBlock> AssignLessonCheckCriteria(SyllabusForLessonWithGroupListDto lesson, LessonGroupType groupType, EducationType educationType)
        {
            var assignLesson = lesson.Map<SyllabusForLessonWithGroupListDto>();
            var blocks = UnitToBlock(lesson);

            var lsBlocks = new List<LessonBlock>();

            foreach (var block in blocks.ToList())
            {
                var timesAndDays = new TimesAndDays(educationType);

                var cakisanAynıDers = UnitLessons.FindAll(unit => unit.EducationType == educationType  && unit.LessonId == lesson.LessonId && unit.GroupType == groupType).FirstOrDefault();

                if (cakisanAynıDers != null)
                    timesAndDays.TimeAndDays.RemoveAll(item => item.Day == cakisanAynıDers.DayOfTheWeekType);

                var cakisanGruplar = UnitLessons.FindAll(unit => unit.EducationType == educationType && unit.SemesterType == lesson.SemesterType && unit.GroupType == groupType);

                foreach (var item in cakisanGruplar.ToList())
                {
                    for (int i = 0; i < timesAndDays.TimeAndDays.Count; i++)
                    {
                        if (timesAndDays.TimeAndDays[i].Day != item.DayOfTheWeekType)
                            continue;

                        timesAndDays.TimeAndDays[i].Times.RemoveAll(del => del == item.StarTime);
                    }
                }

                foreach (var gn in timesAndDays.TimeAndDays.ToList())
                {
                    foreach (var st in gn.Times.ToList())
                    {
                        for (int k = 0; k < block.Count; k++)
                        {
                            int sonraki = st + k;
                            if (!(gn.Times.Any(tm => tm == sonraki)))
                            {
                                for(int i=0; i<timesAndDays.TimeAndDays.Count;i++)
                                {
                                    if (timesAndDays.TimeAndDays[i].Day != gn.Day)
                                        continue;

                                    timesAndDays.TimeAndDays[i].Times.RemoveAll(deltm => deltm == st);
                                }
                            }
                        }
                    }
                }


                int secilenSaat = -1;
                int gunSayisi = timesAndDays.TimeAndDays.Count;
                DayOfTheWeekType secilenGunId = new DayOfTheWeekType();
                for (int i = 0; i < gunSayisi; i++)
                {
                    timesAndDays.TimeAndDays.Shuffle();
                    var secilenGun = timesAndDays.TimeAndDays.FirstOrDefault();
                    if (secilenGun.Times.Count > 0)
                    {
                        secilenSaat = secilenGun.Times.Min();
                        secilenGunId = secilenGun.Day;
                        break;
                    }

                    timesAndDays.TimeAndDays.RemoveAll(x => x.Day == secilenGun.Day);
                }

                if (secilenSaat == -1)
                {
                    // throw new UserFriendlyException("Program oluşturmak için hatalı veriler var.");

                }

                for (int i = 0; i < block.Count; i++)
                {
                    block[i].DayOfTheWeekType = secilenGunId;
                    block[i].StarTime = secilenSaat + i;
                    block[i].EndTime = secilenSaat + i + 1;
                    block[i].GroupType = groupType;
                    block[i].SemesterType = lesson.SemesterType;
                    block[i].EducationType = educationType;

                    UnitLessons.Add(block[i]);

                }
                var lsBlock = new LessonBlock
                {
                    LessonId = lesson.LessonId,
                    units = block
                };
                lsBlocks.Add(lsBlock);
            }
            return lsBlocks;

        }
        private List<List<UnitLessonEntity>> UnitToBlock(SyllabusForLessonWithGroupListDto lesson)
        {

            //var units = new List<UnitLessonEntity>();
            var blocks = new List<List<UnitLessonEntity>>();
            int lessonHour = lesson.WeeklyHour;
            if (lessonHour == 5)
            {

            }
            while (lessonHour != 0)
            {
                if (lessonHour % 2 == 0)
                {
                    var units = new List<UnitLessonEntity>();
                    for (int i = 0; i < 2; i++)
                    {
                        var unitLessonDomain = UnitLessonDomainFactory.Create(lesson.LessonId);
                        units.Add(unitLessonDomain.Map<UnitLessonEntity>());
                    }
                    blocks.Add(units);
                    lessonHour = lessonHour - 2;
                    if (lessonHour == 0)
                        break;
                }
                else
                {
                    var units = new List<UnitLessonEntity>();
                    for (int i = 0; i < 3; i++)
                    {
                        var unitLessonDomain = UnitLessonDomainFactory.Create(lesson.LessonId);
                        units.Add(unitLessonDomain.Map<UnitLessonEntity>());
                    }
                    blocks.Add(units);
                    lessonHour = lessonHour - 3;
                    if (lessonHour == 0)
                        break;
                }

                if (lessonHour == 0)
                    break;
            }
            return blocks;
        }

        #endregion


        public void HocaAta(List<TeacherConstraintWithLessonsDto> teachers)
        {
            teachers.Shuffle();

            foreach (var teacher in teachers)
            {
                switch (teacher.Title)
                {
                    case (Title.Profesor):
                        teacher.MinHour = (int)CompulsoryLessonHoursForTitle.Prof;
                        break;
                    case (Title.DocentDoktor):
                        teacher.MinHour = (int)CompulsoryLessonHoursForTitle.Doc;
                        break;
                    case (Title.YardimciDocent):
                        teacher.MinHour = (int)CompulsoryLessonHoursForTitle.YrDoc;
                        break;
                    case (Title.OgretimGorevlisi):
                        teacher.MinHour = (int)CompulsoryLessonHoursForTitle.OgrGor;
                        break;
                    case (Title.Doktor):
                        teacher.MinHour = (int)CompulsoryLessonHoursForTitle.OgrGor;
                        break;
                    default:
                        teacher.MinHour = 0;
                        break;
                }
            }

            #region Hocaların minimum saatini doldur
            foreach (var tc in teachers)
            {
                tc.IterationCount++;
                foreach (var ls in tc.Lessons)
                {
                    var verebilecegiBloklar = LessonBlocks.FindAll(lsb => lsb.LessonId == ls.LessonId && lsb.UserId == 0);
                    if (verebilecegiBloklar.Count > 0)
                    {
                        if (UnitLessons.FindAll(x => x.UserId == tc.UserId).Count > tc.MinHour)
                        {
                            break;
                        }

                        var dahaOnceAtandigiBloklar = LessonBlocks.FindAll(x => x.UserId == tc.UserId);

                        List<int> silinecekIdler = new List<int>();
                        if (tc.Constraint.EducationType == EducationType.IIOgretim)
                        {
                            verebilecegiBloklar.Shuffle();
                            verebilecegiBloklar.OrderBy(x => x.units[0].EducationType);
                        }
                        else
                        {
                            verebilecegiBloklar.Shuffle();
                            verebilecegiBloklar.OrderByDescending(x => x.units[0].EducationType);
                        }

                        foreach (var vrb in verebilecegiBloklar)
                        {
                            bool dersiVeremez = false;
                            foreach (var atndg in dahaOnceAtandigiBloklar)
                            {
                                if (atndg.units[0].DayOfTheWeekType != vrb.units[0].DayOfTheWeekType)
                                    continue;

                                foreach (var vrun in vrb.units)
                                {
                                    foreach (var atun in atndg.units)
                                    {
                                        if (vrun.StarTime == atun.StarTime)
                                        {
                                            dersiVeremez = true;
                                        }
                                    }
                                }
                            }

                            if (dersiVeremez)
                            {
                                silinecekIdler.Add(vrb.BlockId);
                            }
                        }

                        foreach (var id in silinecekIdler)
                        {
                            verebilecegiBloklar.RemoveAll(x => x.BlockId == id);

                        }

                        if (verebilecegiBloklar.Count > 0)
                        {
                            verebilecegiBloklar.Shuffle();
                            for (int i = 0; i < UnitLessons.Count; i++)
                            {
                                //education type da eklenecek
                                if (verebilecegiBloklar[0].units[0].GroupType == UnitLessons[i].GroupType && verebilecegiBloklar[0].units[0].LessonId == UnitLessons[i].LessonId && verebilecegiBloklar[0].units[0].DayOfTheWeekType == UnitLessons[i].DayOfTheWeekType && verebilecegiBloklar[0].units[0].SemesterType == UnitLessons[i].SemesterType && verebilecegiBloklar[0].units[0].EducationType == UnitLessons[i].EducationType)
                                {
                                    UnitLessons[i].UserId = tc.UserId;
                                }
                            }
                            foreach (var lsblck in LessonBlocks)
                            {
                                if (lsblck.BlockId == verebilecegiBloklar[0].BlockId)
                                {
                                    lsblck.UserId = tc.UserId;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Derslerden başlayarak hoca ata
            foreach (var blck in LessonBlocks)
            {
                List<TeacherConstraintWithLessonsDto> dersiVerenler = new List<TeacherConstraintWithLessonsDto>();
                if (blck.UserId != 0)
                {
                    continue;
                }

                foreach (var tc in teachers)
                {
                    foreach (var ls in tc.Lessons)
                    {
                        if (ls.LessonId == blck.LessonId)
                        {
                            dersiVerenler.Add(tc);
                            break;
                        }
                    }
                }

                dersiVerenler.Shuffle();
                //dersiVerenler = dersiVerenler.OrderBy(x=> x.)
                if (blck.units[0].EducationType == EducationType.IIOgretim)
                {
                    dersiVerenler.Shuffle();
                    dersiVerenler.OrderBy(x => x.Constraint.EducationType);
                }
                else
                {
                    dersiVerenler.Shuffle();
                    dersiVerenler.OrderByDescending(x => x.Constraint.EducationType);
                }

                bool derseHocaAtandiMi = false;
                foreach (var tc in dersiVerenler)
                {
                    bool dersiVeremez = false;

                    var dahaOnceAtandigiBloklar = LessonBlocks.FindAll(x => x.UserId == tc.UserId);
                    foreach (var atndg in dahaOnceAtandigiBloklar)
                    {
                        if (atndg.units[0].DayOfTheWeekType != blck.units[0].DayOfTheWeekType)
                            continue;

                        foreach (var vrun in blck.units)
                        {
                            foreach (var atun in atndg.units)
                            {
                                if (vrun.StarTime == atun.StarTime)
                                {
                                    dersiVeremez = true;
                                }
                            }
                        }
                    }
                    if (dersiVeremez)
                        continue;
                    foreach (var lsblck in LessonBlocks)
                    {
                        if (lsblck.BlockId == blck.BlockId)
                        {
                            lsblck.UserId = tc.UserId;
                        }
                    }
                    derseHocaAtandiMi = true;
                    foreach (var un in blck.units)
                    {
                        for (int i = 0; i < UnitLessons.Count; i++)
                        {
                            if (blck.units[0].EducationType == UnitLessons[i].EducationType && blck.units[0].GroupType == UnitLessons[i].GroupType && blck.units[0].LessonId == UnitLessons[i].LessonId && blck.units[0].DayOfTheWeekType == UnitLessons[i].DayOfTheWeekType && blck.units[0].SemesterType == UnitLessons[i].SemesterType)
                            {
                                UnitLessons[i].UserId = tc.UserId;
                            }
                        }
                    }
                }
                if (!derseHocaAtandiMi)
                {
                    blck.IsDeadLock = true;
                }
            }

            //bu kod debug için yazılmıştır.
            var atanamayanBlocklar = LessonBlocks.FindAll(x => x.IsDeadLock == true);
            #endregion

            #region Şuanki Ders Atamasına Göre Hoca Atanamayan Derslerin Yerlerini Değiştir
            foreach (var lsb in LessonBlocks)
            {
                if (lsb.IsDeadLock)
                {
                    List<TeacherConstraintWithLessonsDto> dersiVerenler = new List<TeacherConstraintWithLessonsDto>();
                    foreach (var tc in teachers)
                    {
                        foreach (var ls in tc.Lessons)
                        {
                            if (ls.LessonId == lsb.LessonId)
                            {
                                dersiVerenler.Add(tc);
                                break;
                            }
                        }
                    }

                    dersiVerenler.Shuffle();

                    foreach (var tc in dersiVerenler)
                    {
                        var cakisanHoca = LessonBlocks.FindAll(x => x.UserId == tc.UserId);


                        //burada bu dersleri tekrardan yerleştir
                        var gecerliSaatler = new TimesAndDays(lsb.units[0].EducationType);

                        //educationtype eklenecek
                        var cakisanAyniDers = LessonBlocks.FindAll(x => x.units[0].EducationType == lsb.units[0].EducationType && x.units[0].LessonId == lsb.units[0].LessonId && x.units[0].GroupType == lsb.units[0].GroupType).FirstOrDefault();
                        if (cakisanAyniDers != null)
                        {
                            gecerliSaatler.TimeAndDays.RemoveAll(x => x.Day == cakisanAyniDers.units[0].DayOfTheWeekType);
                        }

                        //educationtype eklenecek
                        var cakisanGruplar = LessonBlocks.FindAll(x => x.units[0].EducationType == lsb.units[0].EducationType && x.units[0].SemesterType == lsb.units[0].SemesterType && x.units[0].GroupType == lsb.units[0].GroupType);

                        foreach (var bl in cakisanGruplar.ToList())
                        {
                            foreach (var un in bl.units)
                            {
                                for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                                {
                                    if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                                        continue;

                                    gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                                }
                            }
                        }

                        foreach (var bl in cakisanHoca.ToList())
                        {
                            foreach (var un in bl.units)
                            {
                                for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                                {
                                    if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                                        continue;

                                    gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                                }
                            }
                        }

                        foreach (var gn in gecerliSaatler.TimeAndDays.ToList())
                        {
                            foreach (var st in gn.Times.ToList())
                            {
                                for (int k = 0; k < lsb.units.Count; k++)
                                {
                                    int sonraki = st + k;
                                    if (!(gn.Times.Any(tm => tm == sonraki)))
                                    {
                                        for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                                        {
                                            if (gecerliSaatler.TimeAndDays[i].Day != gn.Day)
                                                continue;

                                            gecerliSaatler.TimeAndDays[i].Times.RemoveAll(deltm => deltm == st);
                                        }
                                    }
                                }
                            }
                        }

                        int secilenSaat = -1;
                        int gunSayisi = gecerliSaatler.TimeAndDays.Count;
                        DayOfTheWeekType secilenGunId = new DayOfTheWeekType();
                        for (int i = 0; i < gunSayisi; i++)
                        {
                            gecerliSaatler.TimeAndDays.Shuffle();
                            var secilenGun = gecerliSaatler.TimeAndDays.FirstOrDefault();
                            if (secilenGun.Times.Count > 0)
                            {
                                secilenSaat = secilenGun.Times.Min();
                                secilenGunId = secilenGun.Day;
                                break;
                            }

                            gecerliSaatler.TimeAndDays.RemoveAll(x => x.Day == secilenGun.Day);
                        }
                        if (secilenSaat == -1)
                        {
                            continue;
                        }
                        else
                        {
                            for (int i = 0; i < lsb.units.Count; i++)
                            {
                                lsb.units[i].DayOfTheWeekType = secilenGunId;
                                lsb.units[i].StarTime = secilenSaat + i;
                                lsb.units[i].EndTime = secilenSaat + i + 1;
                                lsb.units[i].UserId = tc.UserId;
                            }
                            lsb.UserId = tc.UserId;
                        }
                    }
                }
            }
            #endregion

            #region Kısıtlara Göre Optmize Et Hocalara Boş Gün Ver
            foreach (var blck in LessonBlocks)
            {
                List<TeacherConstraintWithLessonsDto> dersiVerenler = new List<TeacherConstraintWithLessonsDto>();

                var dersiVerenHoca = teachers.FindAll(x => x.UserId == blck.UserId).FirstOrDefault();
                if (dersiVerenHoca == null)
                    continue;//Bi hata var demektir ama çıkmaz burada hata garanti olsun diye yazalım

                if (!dersiVerenHoca.Constraint.IsFreeDay)
                    continue;

                if (!(UnitLessons.Any(x => x.UserId == blck.UserId && x.DayOfTheWeekType == DayOfTheWeekType.One)))
                    continue;

                if (!(UnitLessons.Any(x => x.UserId == blck.UserId && x.DayOfTheWeekType == DayOfTheWeekType.Two)))
                    continue;

                if (!(UnitLessons.Any(x => x.UserId == blck.UserId && x.DayOfTheWeekType == DayOfTheWeekType.Three)))
                    continue;

                if (!(UnitLessons.Any(x => x.UserId == blck.UserId && x.DayOfTheWeekType == DayOfTheWeekType.Four)))
                    continue;

                if (!(UnitLessons.Any(x => x.UserId == blck.UserId && x.DayOfTheWeekType == DayOfTheWeekType.Five)))
                    continue;

                //Buraya gelirse bu hoca boş gün istiyor ama boş günü yok o zaman boş gün açalım

                #region Hocaya Boş Gün Açma

                List<List<LessonBlock>> gunlereGoreDersleri = new List<List<LessonBlock>>();

                for (int i = 1; i < 6; i++)
                {
                    var oGunkuDersleri = LessonBlocks.FindAll(x => (int)x.units[0].DayOfTheWeekType == i && x.UserId == blck.UserId);
                    gunlereGoreDersleri.Add(oGunkuDersleri);
                }

                gunlereGoreDersleri = gunlereGoreDersleri.OrderBy(x => x.Count).ToList();

                foreach (var oGunkuBloklar in gunlereGoreDersleri)
                {
                    bool gunBosaldi = true;

                    foreach (var blk in oGunkuBloklar)
                    {
                        var gecerliSaatler = (ValidSaatleriBul(blk));

                        int secilenSaat = -1;
                        int gunSayisi = gecerliSaatler.TimeAndDays.Count;
                        DayOfTheWeekType secilenGunId = new DayOfTheWeekType();
                        for (int i = 0; i < gunSayisi; i++)
                        {
                            gecerliSaatler.TimeAndDays.Shuffle();
                            var secilenGun = gecerliSaatler.TimeAndDays.FirstOrDefault();
                            if (secilenGun.Times.Count > 0)
                            {
                                secilenSaat = secilenGun.Times.Min();
                                secilenGunId = secilenGun.Day;
                                break;
                            }

                            gecerliSaatler.TimeAndDays.RemoveAll(x => x.Day == secilenGun.Day);
                        }

                        if (secilenSaat == -1)
                        {
                            gunBosaldi = false;
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < blk.units.Count; i++)
                            {
                                blk.units[i].DayOfTheWeekType = secilenGunId;
                                blk.units[i].StarTime = secilenSaat + i;
                                blk.units[i].EndTime = secilenSaat + i + 1;
                            }
                        }
                    }
                    if (gunBosaldi)
                        break;
                }

                #endregion

            }
            #endregion

            #region Ders Saatlerini Yakınlaştır

            DersSaatleriniYakinlastir(teachers);

            #endregion

        }

        public void DerslikAta(List<SyllabusForLocationListDto> locations)
        {

            foreach (var lsb in LessonBlocks)
            {
                locations.Shuffle();
                foreach (var loc in locations)
                {
                    bool isLocBusy = false;
                    foreach (var un in lsb.units)
                    {
                        if (UnitLessons.Any(x => x.StarTime == un.StarTime && x.LocationId == loc.LocationId && x.DayOfTheWeekType == un.DayOfTheWeekType))
                        {
                            isLocBusy = true;
                            break;
                        }
                    }
                    if (isLocBusy)
                        continue;

                    foreach (var un in lsb.units)
                    {
                        un.LocationId = loc.LocationId;
                    }

                }
            }
        }

        private void DersSaatleriniYakinlastir(List<TeacherConstraintWithLessonsDto> teachers)
        {
            //minimum 2 saatlik ders olduğu için ve 1. öğretim aralığı 6 saat olduğundan 3 kere dönüyor

            for (int k = 0; k < 3; k++)
            {
                foreach (var lsb in LessonBlocks)
                {
                    if (lsb.units[0].EducationType != EducationType.IOgretim)
                        continue;
                    var gecerliSaatler = YerDegistirmeIcinValidSaatleriBul(lsb);

                    int secilenSaat = -1;
                    int gunSayisi = gecerliSaatler.TimeAndDays.Count;
                    var secilenGun = gecerliSaatler.TimeAndDays.Find(x => x.Day == lsb.units[0].DayOfTheWeekType);
                    if (secilenGun.Times.Count > 0)
                    {
                        if (secilenGun.Times.Max() > lsb.units[0].StarTime)
                        {
                            secilenSaat = secilenGun.Times.Min();
                            for (int i = 0; i < lsb.units.Count; i++)
                            {
                                lsb.units[i].StarTime = secilenSaat + i;
                                lsb.units[i].EndTime = secilenSaat + i + 1;
                            }
                        }
                    }
                }
            }

        }

        private TimesAndDays YerDegistirmeIcinValidSaatleriBul(LessonBlock blk)
        {
            var gecerliSaatler = new TimesAndDays(blk.units[0].EducationType);

            var cakisanHoca = LessonBlocks.FindAll(x => x.UserId == blk.UserId);

            //var cakisanAyniDers = LessonBlocks.FindAll(x => x.units[0].EducationType == blk.units[0].EducationType && x.units[0].LessonId == blk.units[0].LessonId && x.units[0].GroupType == blk.units[0].GroupType).FirstOrDefault();
            //if (cakisanAyniDers != null)
            //{
            //    gecerliSaatler.TimeAndDays.RemoveAll(x => x.Day == cakisanAyniDers.units[0].DayOfTheWeekType);
            //}

            var cakisanGruplar = LessonBlocks.FindAll(x => x.units[0].EducationType == blk.units[0].EducationType && x.units[0].SemesterType == blk.units[0].SemesterType && x.units[0].GroupType == blk.units[0].GroupType);

            foreach (var bl in cakisanGruplar.ToList())
            {
                foreach (var un in bl.units)
                {
                    for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                    {
                        if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                            continue;

                        gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                    }
                }
            }

            foreach (var bl in cakisanHoca.ToList())
            {
                foreach (var un in bl.units)
                {
                    for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                    {
                        if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                            continue;

                        gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                    }
                }
            }

            foreach (var gn in gecerliSaatler.TimeAndDays.ToList())
            {
                foreach (var st in gn.Times.ToList())
                {
                    for (int k = 0; k < blk.units.Count; k++)
                    {
                        int sonraki = st + k;
                        if (!(gn.Times.Any(tm => tm == sonraki)))
                        {
                            for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                            {
                                if (gecerliSaatler.TimeAndDays[i].Day != gn.Day)
                                    continue;

                                gecerliSaatler.TimeAndDays[i].Times.RemoveAll(deltm => deltm == st);
                            }
                        }
                    }
                }
            }
            return gecerliSaatler;
        }

        private TimesAndDays ValidSaatleriBul(LessonBlock blk)
        {
            var gecerliSaatler = new TimesAndDays(blk.units[0].EducationType);

            var cakisanHoca = LessonBlocks.FindAll(x => x.UserId == blk.UserId);

            var cakisanAyniDers = LessonBlocks.FindAll(x => x.units[0].EducationType == blk.units[0].EducationType && x.units[0].LessonId == blk.units[0].LessonId && x.units[0].GroupType == blk.units[0].GroupType).FirstOrDefault();
            if (cakisanAyniDers != null)
            {
                gecerliSaatler.TimeAndDays.RemoveAll(x => x.Day == cakisanAyniDers.units[0].DayOfTheWeekType);
            }

            var cakisanGruplar = LessonBlocks.FindAll(x => x.units[0].EducationType == blk.units[0].EducationType && x.units[0].SemesterType == blk.units[0].SemesterType && x.units[0].GroupType == blk.units[0].GroupType);

            foreach (var bl in cakisanGruplar.ToList())
            {
                foreach (var un in bl.units)
                {
                    for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                    {
                        if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                            continue;

                        gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                    }
                }
            }

            foreach (var bl in cakisanHoca.ToList())
            {
                foreach (var un in bl.units)
                {
                    for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                    {
                        if (gecerliSaatler.TimeAndDays[i].Day != un.DayOfTheWeekType)
                            continue;

                        gecerliSaatler.TimeAndDays[i].Times.RemoveAll(del => del == un.StarTime);
                    }
                }
            }

            foreach (var gn in gecerliSaatler.TimeAndDays.ToList())
            {
                foreach (var st in gn.Times.ToList())
                {
                    for (int k = 0; k < blk.units.Count; k++)
                    {
                        int sonraki = st + k;
                        if (!(gn.Times.Any(tm => tm == sonraki)))
                        {
                            for (int i = 0; i < gecerliSaatler.TimeAndDays.Count; i++)
                            {
                                if (gecerliSaatler.TimeAndDays[i].Day != gn.Day)
                                    continue;

                                gecerliSaatler.TimeAndDays[i].Times.RemoveAll(deltm => deltm == st);
                            }
                        }
                    }
                }
            }
            return gecerliSaatler;
        }

        //Kullanılmıyor
        private void HocalarinDersSaatleriniYakinlastir(List<TeacherConstraintWithLessonsDto> teachers)
        {
            foreach (var tc in teachers)
            {
                List<List<LessonBlock>> gunlereGoreDersleri = new List<List<LessonBlock>>();

                for (int i = 1; i < 6; i++)
                {
                    var oGunkuDersleri = LessonBlocks.FindAll(x => (int)x.units[0].DayOfTheWeekType == i && x.UserId == tc.UserId);
                    gunlereGoreDersleri.Add(oGunkuDersleri);
                }

                gunlereGoreDersleri = gunlereGoreDersleri.OrderBy(x => x.Count).ToList();

                foreach (var oGunkuBloklar in gunlereGoreDersleri)
                {
                    if (oGunkuBloklar.Count < 1)
                        break;

                    int ilkUnitSaati = oGunkuBloklar[0].units[0].StarTime;
                    int sonUnitSaati = oGunkuBloklar[0].units[0].StarTime;

                    foreach (var blk in oGunkuBloklar)
                    {
                        foreach (var un in blk.units)
                        {
                            if (un.StarTime < ilkUnitSaati)
                                ilkUnitSaati = un.StarTime;
                            if (un.StarTime > sonUnitSaati)
                                sonUnitSaati = un.StarTime;
                        }
                    }
                    if (ilkUnitSaati - sonUnitSaati > 8)
                    {
                        var sonBlok = oGunkuBloklar.OrderByDescending(x => x.units[0].StarTime).First();
                        TimesAndDays gecerliSaatler = ValidSaatleriBul(sonBlok);

                        int secilenSaat = -1;
                        int gunSayisi = gecerliSaatler.TimeAndDays.Count;
                        var secilenGun = gecerliSaatler.TimeAndDays.Find(x=> x.Day == sonBlok.units[0].DayOfTheWeekType);
                        if (secilenGun.Times.Count>0)
                        {
                            if (secilenGun.Times.Min() < sonBlok.units[0].StarTime)
                            {
                                secilenSaat = secilenGun.Times.Min();
                                for (int i = 0; i < sonBlok.units.Count; i++)
                                {
                                    sonBlok.units[i].StarTime = secilenSaat + i;
                                    sonBlok.units[i].EndTime = secilenSaat + i + 1;
                                }
                            }
                        }
                    }
                }
            }

        }


        #region ÖĞRETMEN ATAMA
        public void AssignToTeacher(List<SyllabusForLessonWithGroupListDto> teacherForLesson, SyllabusForUserWithConstraintListDto teacher)
        {
            var emptyUnit = UnitLessons.FindAll(x => x.UserId == 0 && teacherForLesson.Contains(teacherForLesson.Find(y => y.LessonId == x.LessonId)));
            var days = emptyUnit.Select(x => x.DayOfTheWeekType).OrderBy(x => x).Distinct().ToList();

            if (teacher.Constraint != null)
            {
                if (teacher.Constraint.IsFreeDay && days.Count >= 3)
                {
                    var units = TeacherConstraintFreeDayCase(emptyUnit, teacher, days);

                    if (units.Count > 0)
                        TaecherTitleControlAndAssign(units, teacher);
                    else
                        TaecherTitleControlAndAssign(emptyUnit, teacher);
                }
                else
                {
                    if (teacher.Constraint.StartTime != 0 && teacher.Constraint.EndTime != 0)
                    {
                        var filterByTimeUnit = emptyUnit.FindAll(x => x.StarTime == teacher.Constraint.StartTime && x.EndTime == teacher.Constraint.EndTime);
                        if (filterByTimeUnit.Count > 0)
                            TaecherTitleControlAndAssign(filterByTimeUnit, teacher);
                        else
                            TaecherTitleControlAndAssign(emptyUnit, teacher);
                    }
                    else
                    {
                        TaecherTitleControlAndAssign(emptyUnit, teacher);
                    }
                }
            }
            else
            {
                TaecherTitleControlAndAssign(emptyUnit, teacher);
            }
        }
        private List<UnitLessonEntity> TeacherConstraintFreeDayCase(List<UnitLessonEntity> emptyUnit, SyllabusForUserWithConstraintListDto teacher, List<DayOfTheWeekType> days)
        {
            var day = days.First();
            int randomDay = new Random().Next((int)day, (int)days.Last() - 2);

            var units = emptyUnit.FindAll(x => (int)x.DayOfTheWeekType == randomDay && (int)x.DayOfTheWeekType == randomDay + 2);
            if (teacher.Constraint.StartTime != 0 && teacher.Constraint.EndTime != 0)
                units = units.FindAll(x => x.StarTime == teacher.Constraint.StartTime && x.EndTime == teacher.Constraint.EndTime);
            if (units.Count == 0)
                units = emptyUnit.FindAll(x => (int)x.DayOfTheWeekType == randomDay && (int)x.DayOfTheWeekType == randomDay + 2);
            return units;
        }
        //Teacher Title göre once mecburi saat kadar ders ata
        private void TaecherTitleControlAndAssign(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            switch (teacher.Title)
            {
                case (Title.Profesor):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.Prof)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.DocentDoktor):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.Doc)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.YardimciDocent):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.YrDoc)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.OgretimGorevlisi):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.OgrGor)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                default:
                    PlaceAssingToTeacher(units, teacher);
                    break;
            }
        }
        //Title a göre atanacak dersler aynı güne ve ard arda mı geliyor ona göre atama yap    
        private void TitleForMinUnitsAndAssignOnTeacher(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            for (int i = 0; i < units.Count; i++)
            {
                var sameLessonUnits = units.FindAll(x => x.GroupType == units[i].GroupType && x.LessonId == units[i].LessonId && x.DayOfTheWeekType == units[i].DayOfTheWeekType);

                if (sameLessonUnits.Count == 3)
                {
                    if (sameLessonUnits.ElementAt(0).LessonId == sameLessonUnits.ElementAt(1).LessonId
                                && sameLessonUnits.ElementAt(0).EndTime == sameLessonUnits.ElementAt(1).StarTime
                                && sameLessonUnits.ElementAt(1).EndTime == sameLessonUnits.ElementAt(2).StarTime)
                    {
                        PlaceAssingToTeacher(sameLessonUnits, teacher);
                        units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType);
                    }
                }

                if (sameLessonUnits.Count == 2)
                {
                    if (sameLessonUnits.ElementAt(0).LessonId == sameLessonUnits.ElementAt(1).LessonId
                                   && sameLessonUnits.ElementAt(0).EndTime == sameLessonUnits.ElementAt(1).StarTime)
                    {
                        PlaceAssingToTeacher(sameLessonUnits, teacher);
                        units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                    }
                }

                if (sameLessonUnits.Count == 1)
                {
                    PlaceAssingToTeacher(sameLessonUnits, teacher);
                    units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                }

                if (sameLessonUnits.Count > 3)
                {
                    PlaceAssingToTeacher(sameLessonUnits, teacher);
                    units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                }

                if (sameLessonUnits.Count == 0)
                    units.RemoveAt(i);
            }
        }
        private void PlaceAssingToTeacher(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            if (units.Count > 0)
            {
                var isSameDayThisTeacher = UnitLessons.FindAll(x => x.UserId == teacher.UserId && x.DayOfTheWeekType == units.First().DayOfTheWeekType && x.StarTime == units.First().StarTime);
                var isSameTeacherEndTime = UnitLessons.FindAll(x => x.UserId == teacher.UserId && x.DayOfTheWeekType == units.Last().DayOfTheWeekType && x.EndTime == units.Last().EndTime);

                if(teacher.UserId == 13)
                {

                }

                if (isSameDayThisTeacher.Count == 0 && isSameTeacherEndTime.Count == 0)
                {
                    int index = 0;
                    units.ForEach(item =>
                     {
                         index = UnitLessons.IndexOf(item);
                         UnitLessons[index].UserId = teacher.UserId;
                     });
                }
            } else {
                //ÇAkışma var
            }
        }

        #endregion

        #region DERSLİK ATAMA
        public void AssignToLocations(List<SyllabusForLocationListDto> locations)
        {
            var emptyLocationOnUnits = UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
            var tempLocations = locations.Map<List<SyllabusForLocationListDto>>();

            for (int i = (int)DayOfTheWeekType.One; i <= (int)DayOfTheWeekType.Five; i++)
            {
                var sameDayUnits = emptyLocationOnUnits.FindAll(x => x.DayOfTheWeekType == (DayOfTheWeekType)i);
                for (int j = 0; j < sameDayUnits.Count; j++)
                {
                    var units = sameDayUnits.FindAll(x => x.LessonId == sameDayUnits[j].LessonId && x.GroupType == sameDayUnits[j].GroupType && x.DayOfTheWeekType == sameDayUnits[j].DayOfTheWeekType);
                    if (locations.FirstOrDefault() != null)
                    {
                        PlaceLocationsOnUnits(units, locations.FirstOrDefault(), tempLocations);
                        ClearToAssignLocationOnUnit(units, sameDayUnits);
                        emptyLocationOnUnits = UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0 && x.LocationId != locations.FirstOrDefault().LocationId);
                        locations.Remove(locations.FirstOrDefault());
                    }
                }
            }
        }
        private void ClearToAssignLocationOnUnit(List<UnitLessonEntity> units, List<UnitLessonEntity> sameDayUnits)
        {
            foreach (var item in units)
            {
                int index = sameDayUnits.IndexOf(item);
                sameDayUnits.RemoveAt(index);
            }
        }
        private void PlaceLocationsOnUnits(List<UnitLessonEntity> units, SyllabusForLocationListDto location, List<SyllabusForLocationListDto> tempLocations)
        {
            var isEmpty = units.FindAll(x => x.DayOfTheWeekType == units[0].DayOfTheWeekType && x.StarTime == units[0].StarTime && x.LocationId == location.LocationId);

            if (isEmpty.Count > 0)
            {
                tempLocations.Shuffle();
                AssignToLocations(tempLocations);
            }
            else
            {
                int index = 0;
                units.ForEach(item =>
                {
                    index = UnitLessons.IndexOf(item);
                    UnitLessons[index].LocationId = location.LocationId;
                });
            }
        }

        #endregion

        public void AddWeeklyHour(int weeklyHour)
        {
            WeeklyHour = weeklyHour;
        }
    }
}