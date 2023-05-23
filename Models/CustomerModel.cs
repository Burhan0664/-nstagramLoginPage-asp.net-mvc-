using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Web.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
	}
	public class ShopContext : DbContext
	{
		public DbSet<Customer>? Customs { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

         optionsBuilder.UseMySQL(@"server=localhost;port=3306;database=custom;user=root;password=mysql1234;");
         base.OnConfiguring(optionsBuilder);
		}
	}
}