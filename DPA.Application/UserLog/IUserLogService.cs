using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IUserLogService
    {
        Task AddAsync(UserLogModel userLogModel);
    }
}
