using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}