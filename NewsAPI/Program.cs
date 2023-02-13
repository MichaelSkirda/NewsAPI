using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NewsAPI;
using NewsAPI.Database;
using NewsAPI.Database.Services.Implementations;
using NewsAPI.Database.Services;
using NewsAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<ApplicationContext>(options => { options.UseSqlServer(connection); });
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connection)); 


builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<INewsSourceService, NewsSourceService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Да, это не самое элегантное и верное решение
// Думаю более правильным было бы разбить это на микросервисы
// Или запустить как отдельный процесс, но для тестового задания думаю такая реализация пойдет
var dbContextFactory = app.Services.GetService<IDbContextFactory<ApplicationContext>>();

TimerCallback tm = new TimerCallback(ParseNewsSourcesTimer.Parse);
Timer timer = new Timer(tm, dbContextFactory, 0, 60000);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
