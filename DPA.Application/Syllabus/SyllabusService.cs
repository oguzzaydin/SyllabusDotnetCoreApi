using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DPA.Database;
using DPA.Domain;
using DPA.Domain.Syllabus;
using DPA.Domain.UnitLesson;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.LocationModel.Dtos;
using DPA.Model.Models.UserModel.Dtos;
using System;

namespace DPA.Application
{
    public class SyllabusService : ISyllabusService
    {
        private SyllabusDomain syllabus;
        private List<UnitLessonDomain> unit = new List<UnitLessonDomain>();

        #region .ctor
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;
        private readonly ISyllabusRepository _syllabusRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;

        public SyllabusService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ISyllabusRepository syllabusRepository,
            ILessonRepository lessonRepository,
            IUserRepository userRepository,
            ILocationRepository locationRepository
        )
        {
            _databaseUnitOfWork = databaseUnitOfWork;
            _syllabusRepository = syllabusRepository;
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }
        #endregion

        public async Task<SyllabusEntity> SelectAsync(long DepartmentId)
        {
            return await _syllabusRepository.SingleOrDefaultAsync<SyllabusEntity>(x => x.DepartmentId == DepartmentId);
        }

        public Task CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                var lessons = _lessonRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.SemesterType);
                var lesson = lessons.FirstOrDefault();
                syllabus = SyllabusDomainFactory.Create(request);

                // await _syllabusRepository.AddAsync(baseSyllabus);

                CreateUnitLesson(lesson.LessonId, request.FacultyId);

                //await _databaseUnitOfWork.SaveChangesAsync();

                return null;
            }
            catch (Exception ex)
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
        }

        private void CreateUnitLesson(long lessonId, long facultyId)
        {
            var teachers = _userRepository.GetUserWithConstraintsForLesson(lessonId);
            var teacher = TeacherSelection(teachers);
            var locationId = ChooseLocation(facultyId, lessonId);
            var unitDomain = UnitLessonDomainFactory.Create(lessonId, teacher.UserId, locationId);

            unit.Add(unitDomain);


            // unit.Map<UnitLessonEntity>();

            // TODO : baseUnitLessons boş saat bulunup eklenmeli
            //unitLessonDomain.AddTime()
        }

        private SyllabusForUserWithConstraintListDto TeacherSelection(List<SyllabusForUserWithConstraintListDto> teachers)
        {
            var firstTeacher = teachers.OrderBy(x => x.Title).FirstOrDefault(); // Öğretmenlerden öncelikli olanları seçer 
            var selectTeachers = teachers.FindAll(x => x.Title == firstTeacher.Title);
            if (syllabus.UnitLessons.Count == 0) // Programa hiç alan eklenmemiş ise
            {
                selectTeachers.Shuffle();
                return selectTeachers.FirstOrDefault();
            }

            //TODO : Birim dersler eklenmiş ise filtrelemeler ?
            return null;
        }
        private long ChooseLocation(long facultyId, long lessonId)
        {
            var locations = _locationRepository.GetFacultyLocations(facultyId);
            if (unit.Count == 0)
            {
                locations.Shuffle();
                return locations.FirstOrDefault().LocationId;
            }
            else
            {
                //Unit nesnesinde bulunanlarda farklı ilk buldugunu alır
                foreach (var item in locations)
                {
                    //TODO: Sylabuss daki unitlerde gezip bos zamana denk geleni donder buradan
                    return unit.Find(y => y.LocationId != item.LocationId).LocationId;
                }
            }

            return -1;
            // TODO : baseUnitLessons ' a eklenmiş olan birim derslerin Time'larında filtreleme yapıcaktık
            // Time 'larda gezmişken boş saatlerde bulunabilir ve dönülebillir
        }

        private void CreateSyllabusDefaultTable(EducationType educationType)
        {
            if ((int)educationType == 1)
                CreatorTimeTable(7, 15);
            else
                CreatorTimeTable(15, 23);
                
        }
        public void CreatorTimeTable(int startTime, int endTime)
        {
            for (int i = 1; i < 6; i++)
            {
                var unitLessonDomain = UnitLessonDomainFactory.Create(0, 0, 0);
                for (int j = startTime; j < endTime; j++)
                {
                    unitLessonDomain.AddTime((DayOfTheWeekType)i, j, j + 1);
                    unit.Add(unitLessonDomain);
                    syllabus.AddUnitLesson(unit.Map<ICollection<UnitLessonEntity>>());
                }
            }
        }
    }
}