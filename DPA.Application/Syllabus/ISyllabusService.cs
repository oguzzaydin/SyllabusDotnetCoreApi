using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Application
{
    public interface ISyllabusService
    {
        Task CreateSyllabus(CreateSyllabusRequest request);
        Task<SyllabusEntity> SelectAsync(long DepartmentId);
    }
}