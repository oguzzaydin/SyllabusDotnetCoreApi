using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Application
{
    public interface ISyllabusService
    {
        void CreateSyllabus(CreateSyllabusRequest request);
        Task<SyllabusEntity> SelectAsync(long DepartmentId);
    }
}