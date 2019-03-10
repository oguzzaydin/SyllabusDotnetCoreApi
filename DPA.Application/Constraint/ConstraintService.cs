using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ListConstraintModel>> ListAsync()
        {
            return await ConstraintRepository.ListAsync<ListConstraintModel>();
        }

        public async Task<PagedList<ListConstraintModel>> ListAsync(PagedListParameters parameters)
        {
            return await ConstraintRepository.ListAsync<ListConstraintModel>(parameters);
        }

        public async Task<ListConstraintModel> SelectAsync(long constraintId)
        {
            return await ConstraintRepository.SelectAsync<ListConstraintModel>(constraintId);
        }

        public async Task<IResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel)
        {
            var validation = new UpdateConstraintModelValidator().Valid(updateConstraintModel);

            if (!validation.Success)
            {
                return new ErrorResult(validation.Message);
            }

            var constraintEntity = await ConstraintRepository.SelectAsync(constraintId);

            var nullObjectValidation = new NullObjectValidation<ConstraintEntity>().Valid(constraintEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var constraintDomain = ConstraintDomainFactory.Create(constraintEntity);

            constraintDomain.Update(updateConstraintModel);

            constraintEntity = constraintDomain.Map<ConstraintEntity>();

            await ConstraintRepository.UpdateAsync(constraintEntity, constraintEntity.ConstraintId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}