using Microsoft.EntityFrameworkCore;
using WebApplicationLibrary.DataConnection;
using WebApplicationLibrary.Repository;
using WebApplicationLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LibraryContext>
    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB")));

builder.Services.AddScoped<AuthorServices>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<BookServices>();
builder.Services.AddScoped<BookRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
