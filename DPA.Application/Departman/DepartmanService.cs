using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

namespace DPA.Application
{
    public sealed class DepartmanService : IDepartmanService
    {
        public DepartmanService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IDepartmanRepository departmanRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            DepartmanRepository = departmanRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IDepartmanRepository DepartmanRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddDepartmanModel addDepartmanModel)
        {
            var validation = new DepartmanModelValidator().Valid(addDepartmanModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var departmanDomain = DepartmanDomainFactory.Create(addDepartmanModel);

            departmanDomain.Add();

            var departmanEntity = departmanDomain.Map<DepartmanEntity>();

            await DepartmanRepository.AddAsync(departmanEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(departmanEntity.Id);
        }

        public async Task<IResult> DeleteAsync(long departmanId)
        {
            await DepartmanRepository.DeleteAsync(departmanId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<DepartmanModel>> ListAsync()
        {
            return await DepartmanRepository.ListAsync<DepartmanModel>();
        }

        public async Task<PagedList<DepartmanModel>> ListAsync(PagedListParameters parameters)
        {
            return await DepartmanRepository.ListAsync<DepartmanModel>(parameters);
        }

        public async Task<DepartmanModel> SelectAsync(long departmanId)
        {
            return await DepartmanRepository.SelectAsync<DepartmanModel>(departmanId);
        }

        public async Task<IResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel)
        {
            var validation = new DepartmanModelValidator().Valid(updateDepartmanModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var departmanEntity = await DepartmanRepository.SelectAsync(departmanId);

            var departmanDomain = DepartmanDomainFactory.Create(departmanEntity);

            departmanDomain.Update(updateDepartmanModel);

            departmanEntity = departmanDomain.Map<DepartmanEntity>();

            await DepartmanRepository.UpdateAsync(departmanEntity, departmanEntity.Id);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}