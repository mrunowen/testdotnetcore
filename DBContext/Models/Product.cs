/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Product.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-21 18:06:52
 *
 *  Version:        V1.0.0
 ***********************************************/


namespace DB.Models
{
	public class Product : Entity
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

		public int OrderId { get; set; }

		public Order Order { get; set; }
	}
}
