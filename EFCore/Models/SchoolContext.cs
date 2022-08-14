using Microsoft.EntityFrameworkCore;

namespace Models;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Server={Config.server};Port={Config.port};Database={Config.dataBase};User Id={Config.userId};Password={Config.password}");
    }
}