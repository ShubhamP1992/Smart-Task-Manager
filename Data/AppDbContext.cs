using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SmartTaskManager.Models;

namespace SmartTaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
