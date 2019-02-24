using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface IDepartmanService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmanModel addDepartmanModel);

        Task<IResult> DeleteAsync(long departmanId);

        Task<IEnumerable<DepartmanModel>> ListAsync();

        Task<PagedList<DepartmanModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel);

        Task<DepartmanModel> SelectAsync(long departmanId);
    }
}