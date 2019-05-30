using System;
using Microsoft.EntityFrameworkCore;

namespace DBModels
{
	public class DB : DbContext
	{

		public DbSet<Models.Order> Orders { get; set; }

		public DbSet<Models.Product> Products { get; set; }
		
	}
}
