using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IDepartmanService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmanModel addDepartmanModel);

        Task<IResult> DeleteAsync(long departmanId);

        Task<IEnumerable<DepartmanModel>> ListAsync();

        Task<PagedList<DepartmanModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel);

        Task<IResult> UpdateUserAsync(long departmanId, long userId);

        Task<DepartmanModel> SelectAsync(long departmanId);

        Task<UserModel> SingleOrDefaultUserAsync(long departmanId);

        Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long departmanId);
    }
}