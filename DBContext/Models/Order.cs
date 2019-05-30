/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Order.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-21 18:06:36
 *
 *  Version:        V1.0.0
 ***********************************************/

using System.Collections.Generic;

namespace DBContext.Models
{
	public class Order : Entity
	{
		public string Title { get; set; }

		public decimal TotalPrice { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
