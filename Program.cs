using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Repository;
using Profit_Homework_MvC.Repository.BookRepo;
using Profit_Homework_MvC.Repository.CheckoutRepo;
using Profit_Homework_MvC.Repository.CustomerRepo;
using Serilog;
using Microsoft.AspNetCore.Identity;
using System;
using Profit_Homework_MvC.CacheHelper;
using System.Configuration;
using Hangfire;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Profit_Homework_MvC.Services;
using Profit_Homework_MvC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using StackExchange.Redis;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.Enrich.FromLogContext()
	.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.Configure<CacheConfiguration>(builder.Configuration.GetSection("CacheConfiguration"));


builder.Services.AddMemoryCache();
builder.Services.AddTransient<MemoryCacheService>();
//builder.Services.AddTransient<RedisCacheService>();
builder.Services.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
{
    switch (key)
    {
        case CacheTech.Memory:
            return serviceProvider.GetService<MemoryCacheService>();
        case CacheTech.Redis:
            return serviceProvider.GetService<RedisCacheService>();
        default:
            return serviceProvider.GetService<MemoryCacheService>();
    }
});

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddRazorPages();
// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Appdbcontext>(options => options.UseSqlServer(
			  builder.Configuration.GetConnectionString("DefaultConnection")
			  ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddDefaultUI()
  .AddDefaultTokenProviders()
  .AddEntityFrameworkStores<Appdbcontext>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.ReturnUrlParameter = "returnUrl";
});


//IConfiguration configuration = builder.Configuration;
//var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
//builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

//builder.Services.AddSingleton<ICacheService, RedisCacheService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICheckoutRepository, CheckoutRepository>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<AdminRoleService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard("/jobs");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Book}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
