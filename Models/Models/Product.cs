/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Product.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-20 17:03:49
 *
 *  Version:        V1.0.0
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DBModels.Models
{
	public class Product : Entity
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

		public int OrderId { get; set; }
	}
}
