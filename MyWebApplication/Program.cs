using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Helpers.Middlewares;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container / register services with Builder.Services.AddDbContext<Datacontext>();
//
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews(); //tell service to use mvc
builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContexts>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;

    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
});



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
app.UseUserSessionValidation();
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
