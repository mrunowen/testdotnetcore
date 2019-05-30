using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspDotNet.Authorization
{
	public class JWTHandler : AuthorizationHandler<JWTRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JWTRequirement requirement)
		{
			context.Succeed(requirement);
			return Task.CompletedTask;
		}
	}
}
