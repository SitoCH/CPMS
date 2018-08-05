using CPMS.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Common.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<Section> Sections { get; set; }
        
        public DbSet<Company> Companies { get; set; }
    }
}