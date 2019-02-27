using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            return new SuccessDataResult<long>(departmanEntity.DepartmanId);
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

        public async Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long departmanId)
        {
            return await DepartmanRepository.SingleOrDefaultAsync<SyllabusModel>(x => x.DepartmanId == departmanId, x => x.Syllabus.Map<SyllabusModel>());
        }

        public async Task<UserModel> SingleOrDefaultUserAsync(long departmanId)
        {
            return  await DepartmanRepository.SingleOrDefaultAsync<UserModel>(x => x.DepartmanId == departmanId, x => x.User.Map<UserModel>());
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

            await DepartmanRepository.UpdateAsync(departmanEntity, departmanEntity.DepartmanId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateUserAsync(long departmanId, long userId)
        {
            var departmanEntity = await DepartmanRepository.SelectAsync(departmanId);

            var departmanDomain = DepartmanDomainFactory.Create(departmanEntity);

            departmanEntity.UserId = userId;

            await DepartmanRepository.UpdateAsync(departmanEntity, departmanEntity.DepartmanId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}