using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Pocky.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController(SignInManager<IdentityUser> signInManager) : ControllerBase
	{
		[Authorize]
		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] object empty)
		{
			if(empty is not null)
			{
				await signInManager.SignOutAsync();
				return Ok();
			}
			return Unauthorized();

		}
	}
}
