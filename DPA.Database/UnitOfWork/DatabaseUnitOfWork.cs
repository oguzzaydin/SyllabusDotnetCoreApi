using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Database
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        private readonly DatabaseContext _context;

        public DatabaseUnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}