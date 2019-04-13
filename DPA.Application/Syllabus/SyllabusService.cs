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

        public SyllabusService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ISyllabusRepository syllabusRepository,
            ILessonRepository lessonRepository
        )
        {
            _databaseUnitOfWork = databaseUnitOfWork;
            _syllabusRepository = syllabusRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<SyllabusEntity> SelectAsync(long DepartmentId)
        {
            return await _syllabusRepository.SingleOrDefaultAsync<SyllabusEntity>(x => x.DepartmentId == DepartmentId);
        }

        public async void CreateSyllabus(CreateSyllabusRequest request)
        {
            try
            {
                var lessons = await _lessonRepository.GetDepartmentLessons(request.FacultyId, request.DepartmentId, request.SemesterType);
            }
            catch
            {
                _databaseUnitOfWork.Rollback();
                throw;
            }
        }
    }
}