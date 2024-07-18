using Microsoft.EntityFrameworkCore;
using Web.Database;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


await using var scope = app.Services.CreateAsyncScope();
await using (var db = scope.ServiceProvider.GetService<DatabaseContext>())
    await db!.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
