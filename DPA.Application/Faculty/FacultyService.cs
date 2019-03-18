using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class FacultyService : IFacultyService
    {
        public FacultyService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IFacultyRepository facultyRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            FacultyRepository = facultyRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IFacultyRepository FacultyRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddFacultyModel addFacultyModel)
        {
            var validation = new FacultyModelValidator().Valid(addFacultyModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var facultyDomain = FacultyDomainFactory.Create(addFacultyModel);

            facultyDomain.Add();

            var facultyEntity = facultyDomain.Map<FacultyEntity>();

            await FacultyRepository.AddAsync(facultyEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(facultyEntity.FacultyId);
        }

        public async Task<IResult> DeleteAsync(long facultyId)
        {
            await FacultyRepository.DeleteAsync(facultyId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<ListFacultyModel>> ListAsync()
        {
            return await FacultyRepository.ListAsync<ListFacultyModel>();
        }

        public async Task<PagedList<ListFacultyModel>> ListAsync(PagedListParameters parameters)
        {
            return await FacultyRepository.ListAsync<ListFacultyModel>(parameters);
        }

        public async Task<ListFacultyModel> SelectAsync(long facultyId)
        {
            return await FacultyRepository.SelectAsync<ListFacultyModel>(facultyId);
        }

        public async Task<IResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel)
        {
            var validation = new FacultyModelValidator().Valid(updateFacultyModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var facultyEntity = await FacultyRepository.SelectAsync(facultyId);

            var nullObjectValidation = new NullObjectValidation<FacultyEntity>().Valid(facultyEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var facultyDomain = FacultyDomainFactory.Create(facultyEntity);

            facultyDomain.Update(updateFacultyModel);

            facultyEntity = facultyDomain.Map<FacultyEntity>();

            facultyEntity.FacultyId = facultyId;

            await FacultyRepository.UpdateAsync(facultyEntity, facultyEntity.FacultyId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}