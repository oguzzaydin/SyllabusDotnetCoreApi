using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DPA.Database;
using DPA.Database.Exceptions;
using DPA.Domain.UnitLesson;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.SyllabusModel.Dtos;
using DPA.Model.Models.UserModel.Dtos;

namespace DPA.Application
{
    public class SyllabusService : ISyllabusService
    {
        private SyllabusEntity baseSyllabus = new SyllabusEntity();
        private List<UnitLessonEntity> baseUnitLessons = new List<UnitLessonEntity>();

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

        public async Task CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                var lessons = _lessonRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.SemesterType);
                var lesson = lessons.FirstOrDefault();
                baseSyllabus = request.Map<SyllabusEntity>();
                await _syllabusRepository.AddAsync(baseSyllabus);
                
                CreateUnitLesson(lesson.LessonId, request.FacultyId);

                //await _databaseUnitOfWork.SaveChangesAsync();
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
            var locationId = ChooseLocation(facultyId);

            var unitLessonDomain = UnitLessonFactory.Create(lessonId, teacher.UserId, locationId, baseSyllabus.SyllabusId);
            
            // TODO : baseUnitLessons boş saat bulunup eklenmeli
            //unitLessonDomain.AddTime()
        }

        private SyllabusForUserWithConstraintListDto TeacherSelection(List<SyllabusForUserWithConstraintListDto> teachers)
        {
            var firstTeacher = teachers.OrderBy(x => x.Title).FirstOrDefault(); // Öğretmenlerden öncelikli olanları seçer 
            var selectTeachers = teachers.FindAll(x => x.Title == firstTeacher.Title);
            if (baseSyllabus.UnitLessons.Count == 0) // Programa hiç alan eklenmemiş ise
            {
                selectTeachers.Shuffle();
                return selectTeachers.FirstOrDefault();
            }

            //TODO : Birim dersler eklenmiş ise filtrelemeler ?
            return null;
        }
        private int ChooseLocation(long facultyId)
        {
            var locations = _locationRepository.GetFacultyLocations(facultyId);

            // TODO : baseUnitLessons ' a eklenmiş olan birim derslerin Time'larında filtreleme yapıcaktık
            // Time 'larda gezmişken boş saatlerde bulunabilir ve dönülebillir

            return -1;
        }
        
    }
}