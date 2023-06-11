using StudentApi.Contracts;
using StudentApi.Dto;
using StudentApi.EFC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentData, StudentDataAccess>();
builder.Services.AddScoped<IGradeData, GradeDataAccess>();
builder.Services.AddScoped<IStatisticsData, StatisticsDataAccess>();
builder.Services.AddDbContext<DataAccess>();
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
