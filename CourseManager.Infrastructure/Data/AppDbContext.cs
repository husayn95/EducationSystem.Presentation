using Microsoft.EntityFrameworkCore;
using CourseManager.Domain.Entities;

namespace CourseManager.Infrastructure.Data;

/*
 DbContext representerar databasen i Entity Framework.
 Här registrerar vi alla tabeller som ska skapas i databasen.
*/
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tabell för kurser
    public DbSet<Course> Courses { get; set; }

    // Tabell för lärare
    public DbSet<Teacher> Teachers { get; set; }

    // Tabell för kurstillfällen
    public DbSet<CourseInstance> CourseInstances { get; set; }

    // Tabell för deltagare
    public DbSet<Participant> Participants { get; set; }

    // Tabell för kursregistreringar
    public DbSet<Registration> Registrations { get; set; }
}