using Microsoft.EntityFrameworkCore;
using TeachersManagement.Models;

namespace TeachersManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
    }
}
