using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Repository;
using Profit_Homework_MvC.Repository.BookRepo;
using Profit_Homework_MvC.Repository.CheckoutRepo;
using Profit_Homework_MvC.Repository.CustomerRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Appdbcontext>(options => options.UseSqlServer(
			  builder.Configuration.GetConnectionString("DefaultConnection")
			  ));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICheckoutRepository, CheckoutRepository>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
