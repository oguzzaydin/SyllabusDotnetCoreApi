using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database
{
    public interface ILessonRepository : IRelationalRepository<LessonEntity>
    {
         
    }
}