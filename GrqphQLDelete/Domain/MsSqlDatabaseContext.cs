using System;
using System.Collections.Generic;
using System.Linq;
using GrqphQLDelete.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GrqphQLDelete.Domain
{
    public class MsSqlDatabaseContext : DbContext, IDatabaseContext
    {
        public MsSqlDatabaseContext()
        {
            Database.EnsureCreated();

            if (!Students.Any())
            {
                Students.AddRange(new List<Student>
                {
                    new Student()
                    {
                        StudentName = "Name",
                        Surname = "Surname",
                        BenefitCategory = "ATO",
                        BirthDate = DateTime.Now,
                        Dormitory = 1,
                        Faculty = 1
                    }
                });
                SaveChanges();
            }
            
            if (!Dormitories.Any())
            {
                Dormitories.AddRange(new List<Dormitory>
                {
                    new Dormitory
                    {
                        Number = "1"
                    },
                    new Dormitory
                    {
                        Number = "2"
                    },
                    new Dormitory
                    {
                        Number = "3"
                    },
                    new Dormitory
                    {
                        Number = "4"
                    }
                });
                SaveChanges();
            }
            
            if (!Faculties.Any())
            {
                Faculties.AddRange(new List<Faculty>
                {
                    new Faculty
                    {
                        FacultyName = "FICT"
                    },
                    new Faculty
                    {
                        FacultyName = "FPM"
                    },
                    new Faculty
                    {
                        FacultyName = "IASA"
                    }
                });
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-B69V4OT;Initial Catalog=ReportsAppDbGraphQL;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Dormitory> Dormitories { get; set; }
        
        public DbSet<Faculty> Faculties { get; set; }
    }
}