using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore.Session07.Common
{
    public class DateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => false;

        public override DateTime Next( EntityEntry entry)
        {
            return DateTime.Now.AddYears(-10);
        }
    }
    public class Person
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public DateTime BirthDate { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; private set; }
        public Address Home { get; set; }
        public BankAccount BankAccount { get; set; }
        [Timestamp]
        public byte[] Token{ get; set; }
    }
    public class PersonContext:DbContext
    {
        public DbSet<Person> People{ get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial catalog=PersonDb; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<BankAccount>().ToTable("People");
            modelBuilder.Entity<Person>().HasOne(c => c.BankAccount).WithOne(c => c.Person).HasForeignKey<Person>(c => c.Id);
            modelBuilder.Entity<Person>().Property(c => c.Year).HasComputedColumnSql("DatePart(yyyy, [DateOfBirth])");
            //modelBuilder.Entity<Person>().Property(c => c.Year).ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Person>().Property(c => c.BirthDate).HasValueGenerator(typeof(DateTimeValueGenerator));
            //modelBuilder.Entity<Person>().Property(c => c.BirthDate).HasDefaultValueSql('getdate()');
            modelBuilder.HasDbFunction(() => DbFunctions.MyFunction());
            modelBuilder.Entity<Person>().OwnsOne(c => c.Home);
            modelBuilder.Entity<Person>().Property(c => c.FirstName).IsConcurrencyToken();
            modelBuilder.Entity<Person>().Property(c => c.Token).IsRowVersion();
            modelBuilder.HasSequence<int>("TestIntSeq", c =>
            {
                
            });
            modelBuilder.Entity<Person>().HasData(new Person { });
            //modelBuilder.Entity<Person>().HasDiscriminator<int>("_DiscColumn").HasValue<Person>(1).HasValue<Teacher>(2)
        }

    }

}
