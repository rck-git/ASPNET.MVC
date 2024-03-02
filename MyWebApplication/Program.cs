var builder = WebApplication.CreateBuilder(args);
// Add services to the container / register services with Builder.Services.AddDbContext<Datacontext>();
//
builder.Services.AddControllersWithViews(); //tell service to use mvc

//builder.Services.AddDbContext<Datacontext>(x => x.UseSqlServer(filepath));
//builder.Services.AddScoped<ProductService>();


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
