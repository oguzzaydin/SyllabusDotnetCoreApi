using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Application
{
    public interface ISyllabusService
    {
        Task<SyllabusEntity> SelectAsync(long departmanId);
    }
}