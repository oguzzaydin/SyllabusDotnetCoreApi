using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmentRepository : EntityFrameworkCoreRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(DatabaseContext context) : base(context)
        {
        }

        // public async SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId)
        // {
        //     var syllabuses = await SingleOrDefaultAsync(x => x.DepartmentId == departmentId, p => p.Syllabus);

        //     // if (syllabuses.Count == 0)
        //     //     throw new UserFriendlyException("Bölüme ait ders programı bulunamadı.");
        //     return syllabuses.Map<SyylabusForDepartmentDTo>();
        // }
    }
}