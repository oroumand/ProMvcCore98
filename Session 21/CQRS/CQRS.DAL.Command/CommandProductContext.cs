using Microsoft.EntityFrameworkCore;

namespace CQRS.DAL
{
    public class CommandProductContext : ProductContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\MSSQLSERVER2017; initial catalog=DBCommand;integrated security=true");
        }

    }
}
