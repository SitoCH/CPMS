using CPMS.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Common.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Name = "Compagnia 40"
            });

            modelBuilder.Entity<Section>().HasData(new Section
            {
                Id = 1,
                Name = "Sezione 1",
                CompanyId = 1
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 1,
                Name = "Gruppo 1",
                SectionId = 1
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 2,
                Name = "Gruppo 2",
                SectionId = 1
            });
        }
    }
}