using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class DepartmentService : IDepartmentService
    {
        public DepartmentService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IDepartmentRepository departmentRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            DepartmentRepository = departmentRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IDepartmentRepository DepartmentRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddDepartmentModel addDepartmentModel)
        {
            var validation = new DepartmentModelValidator().Valid(addDepartmentModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var DepartmentDomain = DepartmentDomainFactory.Create(addDepartmentModel);
            DepartmentDomain.Add();
            var DepartmentEntity = DepartmentDomain.Map<DepartmentEntity>();

            await DepartmentRepository.AddAsync(DepartmentEntity);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(DepartmentEntity.DepartmentId);
        }

        public async Task<IResult> DeleteAsync(long departmentId)
        {
            await DepartmentRepository.DeleteAsync(departmentId);
            await DatabaseUnitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IEnumerable<ListDepartmentModel>> ListAsync()
        {
            return await DepartmentRepository.ListAsync<ListDepartmentModel>();
        }

        public async Task<PagedList<ListDepartmentModel>> ListAsync(PagedListParameters parameters)
        {
            return await DepartmentRepository.ListAsync<ListDepartmentModel>(parameters);
        }

        public async Task<DepartmentModel> SelectAsync(long departmentId)
        {
            return await DepartmentRepository.SelectAsync<DepartmentModel>(departmentId);
        }

        public async Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long departmentId)
        {
            return await DepartmentRepository.SingleOrDefaultAsync<SyllabusModel>(x => x.DepartmentId == departmentId, x => x.Syllabus.Map<SyllabusModel>());
        }

        public async Task<UserModel> SingleOrDefaultUserAsync(long departmentId)
        {
            return await DepartmentRepository.SingleOrDefaultAsync<UserModel>(x => x.DepartmentId == departmentId);
        }

        public async Task<IResult> UpdateAsync(long departmentId, UpdateDepartmentModel updateDepartmentModel)
        {
            var validation = new DepartmentModelValidator().Valid(updateDepartmentModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var DepartmentEntity = await DepartmentRepository.SelectAsync(departmentId);

            var nullObjectValidation = new NullObjectValidation<DepartmentEntity>().Valid(DepartmentEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var DepartmentDomain = DepartmentDomainFactory.Create(DepartmentEntity);
            DepartmentDomain.Update(updateDepartmentModel);
            DepartmentEntity = DepartmentDomain.Map<DepartmentEntity>();
            DepartmentEntity.DepartmentId = departmentId;
            await DepartmentRepository.UpdateAsync(DepartmentEntity, DepartmentEntity.DepartmentId);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateFirstSyylabusAsync(long departmentId, long firstSyllabusId)
        {
            Check.NotNullOrEmpty(firstSyllabusId, "firstSyllabusId");
            Check.NotNullOrEmpty(departmentId, "departmentId");

            var DepartmentEntity = await DepartmentRepository.SelectAsync(departmentId);
            Check.NotNullOrEmpty(DepartmentEntity, "DepartmentEntity");

            var DepartmentDomain = DepartmentDomainFactory.Create(DepartmentEntity);
            DepartmentDomain.FirstActiveSyllabus(firstSyllabusId);
            DepartmentEntity = DepartmentDomain.Map<DepartmentEntity>();
            DepartmentEntity.DepartmentId = departmentId;
            await DepartmentRepository.UpdateAsync(DepartmentEntity, DepartmentEntity.DepartmentId);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateSecondSyylabusAsync(long departmentId, long secondSyllabusId)
        {
            Check.NotNullOrEmpty(secondSyllabusId, "secondSyllabusId");
            Check.NotNullOrEmpty(departmentId, "departmentId");

            var DepartmentEntity = await DepartmentRepository.SelectAsync(departmentId);
            Check.NotNullOrEmpty(DepartmentEntity, "DepartmentEntity");

            var DepartmentDomain = DepartmentDomainFactory.Create(DepartmentEntity);
            DepartmentDomain.SecondActiveSyllabus(secondSyllabusId);
            DepartmentEntity = DepartmentDomain.Map<DepartmentEntity>();
            DepartmentEntity.DepartmentId = departmentId;
            await DepartmentRepository.UpdateAsync(DepartmentEntity, DepartmentEntity.DepartmentId);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateUserAsync(long departmentId, long headOfDepartmentId)
        {
            var DepartmentEntity = await DepartmentRepository.SelectAsync(departmentId);
            var DepartmentDomain = DepartmentDomainFactory.Create(DepartmentEntity);
            await DepartmentRepository.UpdateAsync(DepartmentEntity, DepartmentEntity.DepartmentId);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<ListDepartmentModel> GetDepartmentForHeadOfDepartmentAsync(long headOfDepartmentId)
        {
            //Duzenlenecek
            return await DepartmentRepository.SingleOrDefaultAsync<ListDepartmentModel>(x => x.FacultyId == headOfDepartmentId);
        }

        
        // public async Task<SyylabusForDepartmentDTo> GetFirstSyllabusForDepartment(long departmentId)
        // {
 
        // }

        // public async Task<SyylabusForDepartmentDTo> GetSecondSyllabusForDepartment(long departmentId)
        // {
        //     return _syllabusRepository.GetSecondSyllabusForDepartment(departmentId);
        // }
    }
}