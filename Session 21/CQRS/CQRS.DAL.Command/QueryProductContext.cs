using Microsoft.EntityFrameworkCore;

namespace CQRS.DAL
{
    public class QueryProductContext : ProductContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\MSSQLSERVER2017; initial catalog=DBQuery;integrated security=true");
        }
    }
}
