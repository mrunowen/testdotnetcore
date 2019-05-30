/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Orders.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-21 08:38:43
 *
 *  Version:        V1.0.0
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
	public class Orders
	{
		private readonly DBModels.DB _db;

		public Orders()
		{
			_db = new DBModels.DB();
		}


	}
}
