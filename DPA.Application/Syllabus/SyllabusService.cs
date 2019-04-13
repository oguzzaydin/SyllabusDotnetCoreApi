using System.Threading.Tasks;
using DPA.Database;
using DPA.Model;

namespace DPA.Application
{
 
    public class SyllabusService : ISyllabusService
    {
        public SyllabusService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ISyllabusRepository syllabusRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            SyllabusRepository = syllabusRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private ISyllabusRepository SyllabusRepository { get; }


        public async Task<SyllabusEntity> SelectAsync(long DepartmentId)
        {
            return await SyllabusRepository.SingleOrDefaultAsync<SyllabusEntity>(x => x.DepartmentId == DepartmentId);
        }
    }
}