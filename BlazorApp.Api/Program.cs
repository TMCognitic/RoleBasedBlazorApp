using BlazorApp.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEnumerable<User>>(new List<User>
{
    new User() { Id = 1, Nom = "Doe", Prenom = "John", Email = "john.doe@test.be", Role = "User", Passwd = "Test1234=" },
    new User() { Id = 2, Nom = "Doe", Prenom = "Jane", Email = "jane.doe@test.be", Role = "Moderator", Passwd = "Test1234=" },
    new User() { Id = 3, Nom = "Smith", Prenom = "Hannibal", Email = "hannibal.smith@test.be", Role = "Admin", Passwd = "Test1234=" }
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
