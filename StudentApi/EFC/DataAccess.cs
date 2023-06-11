using Microsoft.EntityFrameworkCore;
using StudentApi.Dto;

namespace StudentApi.EFC; 

public class DataAccess : DbContext{
    public DbSet<Student> Students { get; set; }
    public DbSet<GradeInCourse> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite(@"Data Source=studentDatabase.db;");
        base.OnConfiguring(optionsBuilder);
    }

}