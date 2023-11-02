using Microsoft.EntityFrameworkCore;
using DSCC.Data;
using DSCC.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseString")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<EmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<DepartmentRepository, DepartmentRepository>();



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

