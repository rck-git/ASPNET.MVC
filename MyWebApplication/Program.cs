using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container / register services with Builder.Services.AddDbContext<Datacontext>();
//
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews(); //tell service to use mvc


builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();



var app = builder.Build();

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
