using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class UserLessonRepository : EntityFrameworkCoreRepository<UserLessonEntity>, IUserLessonRepository
    {
        public UserLessonRepository(DatabaseContext context) : base(context)
        {
        }
    }
}