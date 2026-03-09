using CourseManager.Application.Services;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Data;
using CourseManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// CORS
// Tillåter frontend (React) att kommunicera med backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



// Konfigurerar JSON så att cirkulära referenser ignoreras
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Registrerar SQLite databas
// Entity Framework skapar automatiskt databasen
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=courses.db"));



// Dependency Injection
// Kopplar interface till implementation
builder.Services.AddScoped<ICourseRepository, CourseRepository>();



// Registrerar service i DI container
builder.Services.AddScoped<CourseService>();



var app = builder.Build();



// Aktiverar CORS
app.UseCors("AllowAll");



// Skapar databasen automatiskt första gången programmet startas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}



// API endpoint som hämtar alla kurser
app.MapGet("/courses", (CourseService service) =>
{
    var courses = service.GetCourses();

    // Returnerar HTTP 200 OK
    return Results.Ok(courses);
});



// API endpoint för att skapa en kurs
app.MapPost("/courses", (CourseService service, Course course) =>
{
    var createdCourse = service.CreateCourse(course);

    // Returnerar HTTP 201 Created
    return Results.Created($"/courses/{createdCourse.Id}", createdCourse);
});



// API endpoint för att uppdatera en kurs
app.MapPut("/courses/{id}", (CourseService service, int id, Course updatedCourse) =>
{
    var result = service.UpdateCourse(id, updatedCourse);

    // Om kursen inte finns
    if (result == null)
        return Results.NotFound();

    // Annars returneras 200 OK
    return Results.Ok(result);
});



// API endpoint för att ta bort en kurs
app.MapDelete("/courses/{id}", (CourseService service, int id) =>
{
    var deleted = service.DeleteCourse(id);

    // Om kursen inte finns
    if (!deleted)
        return Results.NotFound();

    // Returnerar 204 No Content
    return Results.NoContent();
});



app.Run();