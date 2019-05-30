/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Order.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-20 17:29:10
 *
 *  Version:        V1.0.0
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DBModels.Models
{
	public class Order : Entity
	{
		public string Title { get; set; }

		public decimal TotalPrise { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
