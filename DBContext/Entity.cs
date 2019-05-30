/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Entity.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-21 18:05:49
 *
 *  Version:        V1.0.0
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
	public class Entity
	{
		public int Id { get; set; }

		public int Status { get; set; }

		public DateTimeOffset CreateDate { get; set; }
	}
}
