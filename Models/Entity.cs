/*  RELEASE NOTE
 *  Copyright (C) 2018 BIRENCHENS
 *  All right reserved
 *
 *  Filename:       Entity.cs
 *  Desctiption:    
 *
 *  CreateBy:       BIRENCHENS
 *  CreateDate:     2019-05-20 17:03:17
 *
 *  Version:        V1.0.0
 ***********************************************/


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
	public abstract class Entity
	{
		[Key]
		public int Id { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int State { get; set; }

		public DateTimeOffset CreateDate { get; set; }
	}
}
