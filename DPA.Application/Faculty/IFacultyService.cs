using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface IFacultyService
    {
        Task<IDataResult<long>> AddAsync(AddFacultyModel addFacultyModel);

        Task<IResult> DeleteAsync(long facultyId);

        Task<IEnumerable<FacultyModel>> ListAsync();

        Task<PagedList<FacultyModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel);

        Task<FacultyModel> SelectAsync(long facultyId);
    }
}