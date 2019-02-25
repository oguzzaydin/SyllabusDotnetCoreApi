using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

namespace DPA.Application
{
    public sealed class ConstraintService : IConstraintService
    {
        public ConstraintService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IConstraintRepository constraintRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            ConstraintRepository = constraintRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IConstraintRepository ConstraintRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddConstraintModel addConstraintModel)
        {
            var validation = new AddConstraintModelValidator().Valid(addConstraintModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var constraintDomain = ConstraintDomainFactory.Create(addConstraintModel);

            constraintDomain.Add();

            var constraintEntity = constraintDomain.Map<ConstraintEntity>();

            await ConstraintRepository.AddAsync(constraintEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(constraintEntity.ConstraintId);
        }
        public async Task<IResult> DeleteAsync(long constraintId)
        {
            await ConstraintRepository.DeleteAsync(constraintId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<ConstraintModel>> ListAsync()
        {
            return await ConstraintRepository.ListAsync<ConstraintModel>();
        }

        public async Task<PagedList<ConstraintModel>> ListAsync(PagedListParameters parameters)
        {
            return await ConstraintRepository.ListAsync<ConstraintModel>(parameters);
        }

        public async Task<ConstraintModel> SelectAsync(long constraintId)
        {
            return await ConstraintRepository.SelectAsync<ConstraintModel>(constraintId);
        }

        public async Task<IResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel)
        {
            var validation = new UpdateConstraintModelValidator().Valid(updateConstraintModel);

             if (!validation.Success)
            {
                return new ErrorResult(validation.Message);
            }

            var constraintEntity = await ConstraintRepository.SelectAsync(constraintId);

            var constraintDomain = ConstraintDomainFactory.Create(constraintEntity);

            constraintDomain.Update(updateConstraintModel);

            constraintEntity = constraintDomain.Map<ConstraintEntity>();

            await ConstraintRepository.UpdateAsync(constraintEntity, constraintEntity.ConstraintId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}