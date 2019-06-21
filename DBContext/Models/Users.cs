/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Users.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-06-21 08:54:54
 *
 *  Version:        V1.0.0
 ***********************************************/


namespace DB.Models
{
	public class Users : Entity
	{
		public string UserName { get; set; }

		public string Password { get; set; }
	}
}
