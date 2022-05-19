using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Category.AddCategory;
using Proiect_PWEB.Api.Features.Category.GetAllCategories;
using System.Net;

namespace Proiect_PWEB.Api.Features.Category
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IAddCategoryCommandHandler addCategoryCommandHandler;
        private readonly IGetAllCategoriesQueryHandler getAllCategoriesQueryHandler;

        public CategoryController(IAddCategoryCommandHandler addCategoryCommandHandler, IGetAllCategoriesQueryHandler getAllCategoriesQueryHandler)
        {
            this.addCategoryCommandHandler = addCategoryCommandHandler;
            this.getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
        }

        [HttpPost("addCategory")]
        [Authorize]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommand command, CancellationToken cancellationToken)
        {
            await addCategoryCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllCategories")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await getAllCategoriesQueryHandler.HandleAsync(cancellationToken);

            return Ok(categories);
        }
    }
}
