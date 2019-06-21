using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestAspDotNet.Base
{
	public class MyExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{

			context.Result = new RedirectResult(string.Concat("/api/errors?message=", context.Exception.Message));
		}
	}
}
