using GrqphQLDelete.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GrqphQLDelete.Domain
{
    public interface IDatabaseContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Dormitory> Dormitories { get; set; }

        int SaveChanges();
    }
}