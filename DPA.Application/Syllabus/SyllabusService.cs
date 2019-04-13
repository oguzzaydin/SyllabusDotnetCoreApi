using System;
using System.Threading.Tasks;
using DPA.Database;
using DPA.Database.Exceptions;
using DPA.Model;

namespace DPA.Application
{
 
    public class SyllabusService : ISyllabusService
    {
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;
        private readonly ISyllabusRepository _syllabusRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public SyllabusService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ISyllabusRepository syllabusRepository,
            ILessonRepository lessonRepository,
            IDepartmentRepository departmentRepository
        )
        {
            _databaseUnitOfWork = databaseUnitOfWork;
            _syllabusRepository = syllabusRepository;
            _lessonRepository = lessonRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<SyllabusEntity> SelectAsync(long DepartmentId)
        {
            return await _syllabusRepository.SingleOrDefaultAsync<SyllabusEntity>(x => x.DepartmentId == DepartmentId);
        }

        public async void CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                var lessons = await _departmentRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.SemesterType);
            }
            catch
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
        }
    }
}