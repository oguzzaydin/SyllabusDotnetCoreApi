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
using DPA.Model.Models.SyllabusModel.Dtos;

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
                var teachers = _userRepository.GetUserWithConstraintsForLesson(lesson.LessonId);
                syllabus = SyllabusDomainFactory.Create(request);
                var teacher = TeacherSelection(teachers);
                CreateSyllabusDefaultTable(request.EducationType);
                var locationId = ChooseLocation(request.FacultyId, lesson.LessonId);
                AssignToTeacherOnSyllabus(teacher.UserId, lesson, locationId);
                // await _syllabusRepository.AddAsync(baseSyllabus);

                //await _databaseUnitOfWork.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
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
            locations.Shuffle();
            if (unit.Count == 0)
            {
                return locations.FirstOrDefault().LocationId;
            }
            else
            {
                foreach (var item in locations)
                {
                    //TODO: Sylabuss daki unitlerde gezip bos zamana denk geleni donder buradan
                    return  unit.Find(y => y.LocationId != item.LocationId).LocationId;
                }
            }

            return -1;
            // TODO : baseUnitLessons ' a eklenmiş olan birim derslerin Time'larında filtreleme yapıcaktık
            // Time 'larda gezmişken boş saatlerde bulunabilir ve dönülebillir
        }
        private void CreateSyllabusDefaultTable(EducationType educationType)
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
                for (int j = startTime; j <= endTime; j++)
                {
                    var unitLessonDomain = UnitLessonDomainFactory.Create();
                    unitLessonDomain.AddTime((DayOfTheWeekType)i, j, j + 1);
                    unit.Add(unitLessonDomain);
                    syllabus.AddUnitLesson(unit.Map<UnitLessonEntity>());
                }
            }
        }
        private void AssignToTeacherOnSyllabus(long userId, SyllabusForLessonWithGroupListDto lesson, long locationId) {
           if (lesson.LessonGroups.Count <= 1)
           {
              if ((int)lesson.WeeklyHour <= 2) 
              {
                int index = FindEmptyUnit();
                var syllabusEmptyUnit = syllabus.UnitLessons.ElementAt(index);
                syllabusEmptyUnit.LessonId = lesson.LessonId;
                syllabusEmptyUnit.UserId = userId;
                syllabusEmptyUnit.LocationId = locationId;
                if (syllabus.UnitLessons.ElementAt(index + 1).LocationId == 0)
                {
                  var syllabusNewEmptyUnit = syllabus.UnitLessons.ElementAt(index + 1);
                  syllabusNewEmptyUnit.LessonId = lesson.LessonId;
                  syllabusNewEmptyUnit.UserId = userId;
                  syllabusNewEmptyUnit.LocationId = locationId;
                } else {
                  index = FindEmptyUnit();
                  syllabus.UnitLessons.ElementAt(index).LessonId = lesson.LessonId;
                  syllabus.UnitLessons.ElementAt(index).UserId = userId;
                  syllabus.UnitLessons.ElementAt(index).LocationId = locationId;
                }
              } else {

              }
             
           }
        }
        private int FindEmptyUnit() 
        {
            var unit = (IList<UnitLessonEntity>)syllabus.UnitLessons.Where(x => x.LocationId == 0);
            unit.Shuffle();
            
            return unit.IndexOf(unit.FirstOrDefault());
;
        }

    }
}