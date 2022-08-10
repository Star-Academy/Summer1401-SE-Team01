using Microsoft.EntityFrameworkCore;

namespace Models;

public class SchoolContext : DbContext
{
    private readonly string _password;
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public SchoolContext(string password)
    {
        _password = password;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            $"Server=127.0.0.1;Port=5432;Database=school;User Id=postgres;Password={_password};");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasOne(t => t.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentNumber)
                .HasConstraintName("FK_Grade_Student");

        });
    }
}