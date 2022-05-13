using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.User.AddUser;
using System.Net;

namespace Proiect_PWEB.Api.Features.User
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAddUserCommandHandler addUserCommandHandler;

        public UserController(IAddUserCommandHandler addUserCommandHandler)
        {
            this.addUserCommandHandler = addUserCommandHandler;
        }

        [HttpPost("addUser")]
        //[Authorize]
        public async Task<IActionResult> AddUserAsync([FromBody]AddUserCommand command, CancellationToken cancellationToken)
        {
            await addUserCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
