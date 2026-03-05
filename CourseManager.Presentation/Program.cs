using Microsoft.EntityFrameworkCore;
using CourseManager.Infrastructure.Data;
using CourseManager.Infrastructure.Repositories;
using CourseManager.Domain.Interfaces;
using CourseManager.Application.Services;
using CourseManager.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



//Registrerar SQLite databas
//Entity Framework skapar automatiskt databasen
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=courses.db"));

//Dependency Injection
//Här kopplas interface till implementation
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//registrerar service i DI container
builder.Services.AddScoped<CourseService>();
var app = builder.Build();

app.UseCors("AllowAll");

//skapar databasen automatiskt första gången programmet startas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

//API endpoint som hämtar alla kurser
app.MapGet("/courses", (CourseService service) =>
{
    return service.GetCourses();
});

//API endpoint för att skapa en kurs
app.MapPost("/courses", (CourseService service, Course course) =>
{
    return service.CreateCourse(course);
});

//API endpoint för att uppdatera en kurs
app.MapPut("/courses/{id}", (CourseService service, int id, Course course) =>
{
    return service.UpdateCourse(id, course);
});

//API endpoint för att ta bort en kurs
app.MapDelete("/courses/{id}", (CourseService service, int id) =>
{
    service.DeleteCourse(id);
});

app.Run();
