using ExampleWebApp.Services;
using ExampleWebApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllersWithViews();

services.AddSingleton<IEmployeeService, EmployeeService>();
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
