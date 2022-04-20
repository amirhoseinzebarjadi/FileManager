using FileManager.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MyFile> Files { get; set; }
    }
}
