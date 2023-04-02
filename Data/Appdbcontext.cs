using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.Models;
using System;

namespace Profit_Homework_MvC.Data
{
	public class Appdbcontext : IdentityDbContext
	{
		public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
		{

		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Checkout> Checkouts { get; set; }
	}
}
