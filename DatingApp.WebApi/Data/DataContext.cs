using DatingApp.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<ApplicationUser> Users { get; set; }
    }
}