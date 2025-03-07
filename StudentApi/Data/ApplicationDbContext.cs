using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}