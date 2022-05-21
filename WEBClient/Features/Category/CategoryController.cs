using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Category.AddCategory;
using Proiect_PWEB.Api.Features.Category.DeleteCategory;
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
        private readonly IDeleteCategoryHandler deleteCategoryHandler;

        public CategoryController(IAddCategoryCommandHandler addCategoryCommandHandler,
            IGetAllCategoriesQueryHandler getAllCategoriesQueryHandler,
            IDeleteCategoryHandler deleteCategoryHandler)
        {
            this.addCategoryCommandHandler = addCategoryCommandHandler;
            this.getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
            this.deleteCategoryHandler = deleteCategoryHandler;
        }

        [HttpPost("addCategory")]
        [Authorize("AdminAccess")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommand command, CancellationToken cancellationToken)
        {
            await addCategoryCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllCategories")]
        //[Authorize]
        //[Authorize("AdminAccess")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await getAllCategoriesQueryHandler.HandleAsync(cancellationToken);

            return Ok(categories);
        }

        [HttpPost("deleteCategory")]
        [Authorize("AdminAccess")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await deleteCategoryHandler.HandleAsync(id, cancellationToken);

            return NoContent();
        }
        
    }
}
