using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspDotNet.Filter
{
	public class JWTAuthticationAttribute : Attribute, IAsyncAuthorizationFilter
	{
		public Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			context.Result = new ContentResult
			{
				ContentType = "application/json",
				Content = "斯图尔特"
			};
			return Task.CompletedTask;
		}
	}
}
