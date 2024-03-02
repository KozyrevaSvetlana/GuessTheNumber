using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    /// <summary>
    /// Контекст
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){
            Database.Migrate();
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}