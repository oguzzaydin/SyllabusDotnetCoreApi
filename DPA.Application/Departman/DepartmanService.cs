using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public sealed class DepartmanService : IDepartmanService
    {
        public Task<IDataResult<long>> AddAsync(AddDepartmanModel addDepartmanModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> DeleteAsync(long departmanId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DepartmanModel>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<DepartmanModel>> ListAsync(PagedListParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<DepartmanModel> SelectAsync(long departmanId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel)
        {
            throw new System.NotImplementedException();
        }
    }
}