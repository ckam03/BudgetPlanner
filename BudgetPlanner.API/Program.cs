using BudgetPlanner.API.Data;
using BudgetPlanner.API.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BudgetPlannerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialManagementDb"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();
app.MapEndpoints();
app.UseCors();
app.Run();
