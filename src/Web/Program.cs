global using ApplicationCore.Interfaces;
global using Infrastructure.Data;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Infrastructure.Identity;
global using ApplicationCore.Entities;
using Web.Interfaces;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuartzContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("QuartzContext")));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("AppIdentityDbContext")));

//// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IHomeViewModelService, HomeViewModelService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<QuartzContext>();
    await QuartzContextSeed.SeedAsync(context);


    var appIdentityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await AppIdentityDbContextSeed.SeedAsync(appIdentityDbContext, roleManager, userManager);
}

app.Run();
