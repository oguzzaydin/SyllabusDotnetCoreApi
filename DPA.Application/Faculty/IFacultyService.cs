using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IFacultyService
    {
        Task<IDataResult<long>> AddAsync(AddFacultyModel addFacultyModel);

        Task<IResult> DeleteAsync(long facultyId);

        Task<IEnumerable<ListFacultyModel>> ListAsync();

        Task<PagedList<ListFacultyModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel);

        Task<ListFacultyModel> SelectAsync(long facultyId);
    }
}