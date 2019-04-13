using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database
{
    public interface IDepartmentRepository : IRelationalRepository<DepartmentEntity>
    {
        Task<IEnumerable<LessonEntity>> GetDepartmentLessons(long facultyId, long departmentId, SemesterType semesterType);
    }
}