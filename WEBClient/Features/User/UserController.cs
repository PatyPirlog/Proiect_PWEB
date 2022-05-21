using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Authorization;
using Proiect_PWEB.Api.Features.User.AddUser;
using Proiect_PWEB.Api.Features.User.GetUserProfile;
using System.Net;

namespace Proiect_PWEB.Api.Features.User
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAddUserCommandHandler addUserCommandHandler;
        private readonly IUserProfileQueryHandler userProfileQueryHandler;

        public UserController(IAddUserCommandHandler addUserCommandHandler,
            IUserProfileQueryHandler userProfileQueryHandler)
        {
            this.addUserCommandHandler = addUserCommandHandler;
            this.userProfileQueryHandler = userProfileQueryHandler;
        }

        [HttpPost("addProfile")]
        [Authorize]
        public async Task<IActionResult> AddUserAsync([FromBody]AddUserCommand command, CancellationToken cancellationToken)
        {
            //var identityId = User.GetUserIdentityId();

            await addUserCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getUserProfile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile(string identityId, CancellationToken cancellationToken)
        {
            var user = await userProfileQueryHandler.HandleAsync(identityId, cancellationToken);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}
            return Ok(user);
        }
    }
}
