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

        public async Task<SyylabusForDepartmentDTo> CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                Check.NotNullOrEmpty(request, "request");
                var test = _userRepository.GetTeacherConstraintWithLessons(request.DepartmentId);

                foreach (var item in test)
                {
                    var userLessons = _lessonRepository.GetLessonsForTeacher(item.UserId);
                    item.Lessons = userLessons.Map<List<LessonDto>>();
                }

                var lessons = _lessonRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.PeriodType);
                var syllabusLessons = lessons.Map<List<SyllabusForLessonWithGroupListDto>>();
                var syllabus = SyllabusDomainFactory.Create(request);
                // syllabus.CreateSyllabusDefaultTable(request.EducationType);
                syllabus.AssignToLesson(lessons, request);
                syllabus.UnitLessons.RemoveAll(x => x.LessonId == 0);
                AssignToTeacherOnSyllabus(syllabusLessons, syllabus, request.EducationType);
                CheckAssignToTeacherOnSyllabus(syllabusLessons, syllabus, request.EducationType);
                syllabus.UnitLessons.RemoveAll(x => x.LessonId > 0 && x.UserId == 0);

                AssignToLocationsOnSyllabus(syllabus, request.FacultyId);
                CheckAssignToLocationOnSyllabus(syllabus, request.FacultyId);
                syllabus.UnitLessons.RemoveAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);

                syllabus.AddWeeklyHour(syllabus.UnitLessons.Count);
                var syllabusEntity = syllabus.Map<SyllabusEntity>();

                await _syllabusRepository.AddAsync(syllabusEntity);

                await _databaseUnitOfWork.SaveChangesAsync();
                var result = await GetSyllabus(syllabusEntity.SyllabusId).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
        }

    
        public async Task<IEnumerable<SyylabusForDepartmentDTo>> GetSyllabusForDepartment(long departmentId)
        {
            return await _syllabusRepository.ListAsync<SyylabusForDepartmentDTo>(x => x.DepartmentId == departmentId);
        }

        private async Task<SyylabusForDepartmentDTo> GetSyllabus(long syllabusId)
        {
            return await _syllabusRepository.SingleOrDefaultAsync<SyylabusForDepartmentDTo>(x => x.SyllabusId == syllabusId);
        }

        private SyllabusForUserWithConstraintListDto TeacherSelection(List<SyllabusForUserWithConstraintListDto> teachers, EducationType educationType)
        {

            var firstTeacher = teachers.OrderBy(x => x.Title).FirstOrDefault(); // Öğretmenlerden öncelikli olanları seçer 
            var selectTeachers = teachers.FindAll(x => x.Title == firstTeacher.Title && x.Constraint.EducationType == educationType);

            if (selectTeachers.Count == 0)
                selectTeachers = teachers.FindAll(x => x.Title == firstTeacher.Title);

            selectTeachers.Shuffle();
            return selectTeachers.First();
        }
        private void AssignToTeacherOnSyllabus(List<SyllabusForLessonWithGroupListDto> syllabusLessons, SyllabusDomain syllabus, EducationType educationType)
        {
            foreach (var lesson in syllabusLessons)
            {
                var teachers = _userRepository.GetUserWithConstraintsForLesson(lesson.LessonId);
                var teacher = TeacherSelection(teachers, educationType);
                var teacherForLessons = _lessonRepository.GetLessonsForTeacher(teacher.UserId);
                syllabus.AssignToTeacher(teacherForLessons, teacher);
            }

        }
        private void CheckAssignToTeacherOnSyllabus(List<SyllabusForLessonWithGroupListDto> syllabusLessons, SyllabusDomain syllabus, EducationType educationType)
        {
            var emptyLessonOnSyllabus = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId == 0);
            var unAssignLessons = syllabusLessons.FindAll(x => emptyLessonOnSyllabus.Contains(emptyLessonOnSyllabus.Find(y => y.LessonId == x.LessonId))).ToList();
            if (unAssignLessons.Count > 0)
                AssignToTeacherOnSyllabus(unAssignLessons, syllabus, educationType);
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
            var emptyLocationOnUnits = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
            while (emptyLocationOnUnits.Count != 0)
            {
                emptyLocationOnUnits = syllabus.UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
                if (emptyLocationOnUnits.Count > 0)
                    AssignToLocationsOnSyllabus(syllabus, facultyId);
            }
        }

        public SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId)
        {
            return _syllabusRepository.GetFirstSyllabusForDepartment(departmentId);
        }

        public SyylabusForDepartmentDTo GetSecondSyllabusForDepartment(long departmentId)
        {
            return _syllabusRepository.GetSecondSyllabusForDepartment(departmentId);
        }
    }
}