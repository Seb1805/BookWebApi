using Microsoft.EntityFrameworkCore;
using WebApiBook.Data;
using WebApiBook.Models;
using WebApiBook.Repositories;
using WebApiBook.Repositories.Interfaces;
using WebApiBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add context and get connection string from appsettings.json file
builder.Services.AddDbContext<BookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb")));

//Register service(s) and repos
builder.Services.AddScoped<IParagraphService, ParagraphService>();
builder.Services.AddScoped<INumberOfUniqueWords,NumberOfUniqueWordRepo>();
builder.Services.AddScoped<IUniqueWord,UniqueWordsRepo>();
builder.Services.AddScoped<IWatchlist, WatchlistRepo>();


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
