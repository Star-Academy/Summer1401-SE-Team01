using Microsoft.EntityFrameworkCore;

namespace Models;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=school;User Id=postgres;Password=password;");
        
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