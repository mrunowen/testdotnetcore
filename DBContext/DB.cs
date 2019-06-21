/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       DB.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-21 18:05:25
 *
 *  Version:        V1.0.0
 ***********************************************/

using Microsoft.EntityFrameworkCore;

namespace DB
{
	public class DB : DbContext
	{
		public DB(DbContextOptions<DB> options) : base(options) { }

		public DbSet<Models.Users> Users { get; set; }

		public DbSet<Models.Order> Orders { get; set; }

		public DbSet<Models.Product> Products { get; set; }

		public DbSet<Models.Histories> Histories { get; set; }
	}
}
