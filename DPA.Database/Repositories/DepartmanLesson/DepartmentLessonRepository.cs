using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmentLessonRepository : EntityFrameworkCoreRepository<DepartmentLessonEntity>, IDepartmentLessonRepository
    {
        public DepartmentLessonRepository(DatabaseContext context) : base(context)
        {
        }
    }
}