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

        public async Task<SyllabusEntity> CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                var lessons = _lessonRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.PeriodType);
                var syllabusLessons = lessons.Map<List<SyllabusForLessonWithGroupListDto>>();
                var syllabus = SyllabusDomainFactory.Create(request);
                syllabus.CreateSyllabusDefaultTable(request.EducationType);

                syllabus.AssignToLesson(lessons, request);

                AssignToTeacherOnSyllabus(syllabusLessons, syllabus);
                CheckAssignToTeacherOnSyllabus(syllabusLessons, syllabus);

                AssignToLocationsOnSyllabus(syllabus, request.FacultyId);
                CheckAssignToLocationOnSyllabus(syllabus, request.FacultyId);

                syllabus.AddWeeklyHour(syllabus.UnitLessons.Count);
                var syllabusEntity = syllabus.Map<SyllabusEntity>();
                await _syllabusRepository.AddAsync(syllabusEntity);
                await _databaseUnitOfWork.SaveChangesAsync();
                return syllabusEntity;
            }
            catch (Exception ex)
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
        }

        public async Task<SyylabusForDepartmentDTo> GetSyllabusForDepartment(long departmentId)
        {
            return await _syllabusRepository.SingleOrDefaultAsync<SyylabusForDepartmentDTo>(x => x.DepartmentId == departmentId);
        }
        private SyllabusForUserWithConstraintListDto TeacherSelection(List<SyllabusForUserWithConstraintListDto> teachers)
        {
            var firstTeacher = teachers.OrderBy(x => x.Title).FirstOrDefault(); // Öğretmenlerden öncelikli olanları seçer 
            var selectTeachers = teachers.FindAll(x => x.Title == firstTeacher.Title);
            selectTeachers.Shuffle();
            return selectTeachers.First();
        }
        private void AssignToTeacherOnSyllabus(List<SyllabusForLessonWithGroupListDto> syllabusLessons, SyllabusDomain syllabus)
        {
            foreach (var lesson in syllabusLessons)
            {
                var teachers = _userRepository.GetUserWithConstraintsForLesson(lesson.LessonId);
                var teacher = TeacherSelection(teachers);
                var teacherForLessons = _lessonRepository.GetLessonsForTeacher(teacher.UserId);
                syllabus.AssignToTeacher(teacherForLessons, teacher);
            }
        }
        private void CheckAssignToTeacherOnSyllabus(List<SyllabusForLessonWithGroupListDto> syllabusLessons, SyllabusDomain syllabus)
        {
            var emptyLessonOnSyllabus = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId == 0);
            var unAssignLessons = syllabusLessons.FindAll(x => emptyLessonOnSyllabus.Contains(emptyLessonOnSyllabus.Find(y => y.LessonId == x.LessonId))).ToList();
            if (unAssignLessons.Count >= 0)
                AssignToTeacherOnSyllabus(unAssignLessons, syllabus);
        }
        private void AssignToLocationsOnSyllabus(SyllabusDomain syllabus, long facultyId)
        {
            var locations = _locationRepository.GetFacultyLocations(facultyId);
            locations.Shuffle();
            syllabus.AssignToLocations(locations);
            syllabus.UnitLessons.RemoveAll(x => x.LessonId == 0 && x.UserId == 0 && x.LocationId == 0);
        }
        private void CheckAssignToLocationOnSyllabus(SyllabusDomain syllabus, long facultyId)
        {
            var emptyLocationOnUnits = new List<UnitLessonEntity>();
            emptyLocationOnUnits = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
            while(emptyLocationOnUnits.Count != 0)
            {
               emptyLocationOnUnits = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
            if (emptyLocationOnUnits.Count > 0)
               AssignToLocationsOnSyllabus(syllabus, facultyId);
            }
        }
      
    }
}