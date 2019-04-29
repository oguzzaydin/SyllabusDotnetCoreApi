using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Application.DepartmentInstuctor;
using DPA.Database;
using DPA.Domain.DepartmentInstructor;
using DPA.Model;

namespace DPA.Application
{
    public class DepartmentInstuctorService : IDepartmentInstuctorService
    {
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;
        private readonly IDepartmentInstructorRepository _departmentInstructorRepository;
        public DepartmentInstuctorService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IDepartmentInstructorRepository departmentInstructorRepository
        )
        {
            _databaseUnitOfWork = databaseUnitOfWork;
            _departmentInstructorRepository = departmentInstructorRepository;
        }

        public async Task<IDataResult<long>> AddAsync(DepartmentInstructorModel request)
        {
            Check.NotNullOrEmpty(request, "request");
            var departmentInstructorDomain = DepartmentInstructorDomainFactory.Create(request);
            var departmentInstructorEntity = departmentInstructorDomain.Map<DepartmentInstructorEntity>();
            await _departmentInstructorRepository.AddAsync(departmentInstructorEntity);
            await _databaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(departmentInstructorEntity.DepartmentInstructorId);
        }

        public async Task<IResult> DeleteInstructorAsync(long departmentId, long userId)
        {
            Check.NotNullOrEmpty(departmentId, "departmentId");
            Check.NotNullOrEmpty(userId, "userId");
            await _departmentInstructorRepository.DeleteAsync(x => x.DepartmentId == departmentId && x.UserId == userId);
            await _databaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
        public async Task<IEnumerable<ListUserModel>> ListInstructorAsync(long departmentId)
        {
            Check.NotNullOrEmpty(departmentId, "departmentId");
            var departmentInstructor = await _departmentInstructorRepository.ListAsync<DepartmentInstructorEntity>(x => x.DepartmentId == departmentId, y => y.User);
            return departmentInstructor.Select(x => x.User).Map<IEnumerable<ListUserModel>>();
        }

        public async Task<IEnumerable<ListDepartmentModel>> ListDepartmentAsync(long userId)
        {
            Check.NotNullOrEmpty(userId, "userId");
            var departmentInstructor = await _departmentInstructorRepository.ListAsync<DepartmentInstructorEntity>(x => x.UserId == userId, y => y.Department);
            return departmentInstructor.Select(x => x.Department).Map<IEnumerable<ListDepartmentModel>>();
        }

    }
}