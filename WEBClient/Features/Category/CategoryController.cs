using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Category.AddCategory;
using System.Net;

namespace Proiect_PWEB.Api.Features.Category
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IAddCategoryCommandHandler addCategoryCommandHandler;

        public CategoryController(IAddCategoryCommandHandler addCategoryCommandHandler)
        {
            this.addCategoryCommandHandler = addCategoryCommandHandler;
        }

        [HttpPost("addCategory")]
        //[Authorize]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommand command, CancellationToken cancellationToken)
        {
            await addCategoryCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
