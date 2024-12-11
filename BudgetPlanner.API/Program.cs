using BudgetPlanner.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors();
}

app.MapEndpoints();
app.Run();

public partial class Program { }
