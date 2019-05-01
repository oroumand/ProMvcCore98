using Microsoft.EntityFrameworkCore;
using Session08.Entities;

namespace Session08.EfDal
{
    public class LogContext:DbContext
    {
        public DbSet<DataChangeHistory> DataChangeHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = .; initial catalog= session08.LogDb;integrated security =true");
        }
    }
}
