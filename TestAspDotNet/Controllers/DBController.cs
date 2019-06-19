using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAspDotNet.Controllers
{
	[Route("api/[controller]")]
	public class DBController : Controller
	{
		public string Index()
		{
			return "IN DB";
		}

		//[HttpGet("add")]
		//public void Add()
		//{
		//	using (DB db = new DB())
		//	{
		//		Order order = new Order
		//		{
		//			Title = "订单标题",
		//			TotalPrise = 100,
		//			State = 1,
		//			CreateDate = DateTimeOffset.Now
		//		};

		//		db.Add(order);
		//		db.SaveChanges();
		//	}
		//}

		//[HttpGet()]
		//public void Get()
		//{
		//	using (DB db = new DB())
		//	{
		//		List<Order> list = db.Orders.ToList();
		//		int count = list.Count();
		//	}
		//}
	}
}
