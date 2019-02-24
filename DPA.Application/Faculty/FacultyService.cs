using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

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

            return new SuccessDataResult<long>(facultyEntity.Id);
        }

        public async Task<IResult> DeleteAsync(long facultyId)
        {
            await FacultyRepository.DeleteAsync(facultyId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<FacultyModel>> ListAsync()
        {
            return await FacultyRepository.ListAsync<FacultyModel>();
        }

        public async Task<PagedList<FacultyModel>> ListAsync(PagedListParameters parameters)
        {
            return await FacultyRepository.ListAsync<FacultyModel>(parameters);
        }

        public async Task<FacultyModel> SelectAsync(long facultyId)
        {
            return await FacultyRepository.SelectAsync<FacultyModel>(facultyId);
        }

        public async Task<IResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel)
        {
            var validation = new FacultyModelValidator().Valid(updateFacultyModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var facultyEntity = await FacultyRepository.SelectAsync(facultyId);

            var facultyDomain = FacultyDomainFactory.Create(facultyEntity);

            facultyDomain.Update(updateFacultyModel);

            facultyEntity = facultyDomain.Map<FacultyEntity>();

            await FacultyRepository.UpdateAsync(facultyEntity, facultyEntity.Id);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}