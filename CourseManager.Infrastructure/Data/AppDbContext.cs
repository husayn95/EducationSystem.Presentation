using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CourseManager.Infrastructure.Data;

//DbContext ansvarar för kopplingen till databasen
//Entity Framework använder denna klass för att göra tabeller
public class AppDbContext : DbContext
{
    //konstruktor som tar emot databas inställningar
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    //representerar tabellen "Courses" i databasen
    public DbSet<Course> Courses => Set<Course>();
}