using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Repositories;
using DPA.Model;
using DPA.Model.Models.SyllabusModel.Dtos;

namespace DPA.Database
{
    public interface ILessonRepository : IRelationalRepository<LessonEntity>
    {
        List<SyllabusForLessonWithGroupListDto> GetDepartmentLessons(long facultyId, long departmentId, SemesterType semesterType);
    }
}