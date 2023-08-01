using Microsoft.EntityFrameworkCore;
using StarWarsCharacters;
using StarWarsCharacters.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<SwapiService>();
builder.Services.AddDbContext<CharacterContext>(o =>
{
    o.UseSqlServer("data source=DESKTOP-T0H6I91;initial catalog=master;user id=sa;password=123; Encrypt=False");
});
builder.Services.AddScoped<StarwarsDatabase>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();