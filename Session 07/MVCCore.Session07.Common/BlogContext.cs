using Microsoft.EntityFrameworkCore;

namespace MVCCore.Session07.Common
{
    public class BlogContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial catalog=BlogDb; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasIndex(c => c.Name).IsUnique();

            //modelBuilder.Entity<Blog>().HasMany(c => c.Posts).WithOne().OnDelete(DeleteBehavior.ClientSetNull).IsRequired();
            //modelBuilder.Entity<Blog>().HasMany(c => c.Posts).WithOne().HasPrincipalKey(c=);
        }

    }

}
