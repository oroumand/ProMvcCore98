﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Session08.EfDal;

namespace Session08.EfDal.Migrations
{
    [DbContext(typeof(Session08Context))]
    partial class Session08ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Session08.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId");

                    b.HasKey("ContactId");

                    b.HasIndex("PersonId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Session08.Entities.JobData", b =>
                {
                    b.Property<int>("JobDataId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobTitle");

                    b.Property<int>("PersonId");

                    b.HasKey("JobDataId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("JobDatas");
                });

            modelBuilder.Entity("Session08.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Session08.Entities.Contact", b =>
                {
                    b.HasOne("Session08.Entities.Person", "Person")
                        .WithMany("Contact")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Session08.Entities.JobData", b =>
                {
                    b.HasOne("Session08.Entities.Person", "Person")
                        .WithOne("JobData")
                        .HasForeignKey("Session08.Entities.JobData", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
