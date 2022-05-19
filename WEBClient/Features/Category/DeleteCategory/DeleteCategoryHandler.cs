using Proiect_PWEB.Api.Web;
using Proiect_PWEB.Core.Domain.CategoryDomain;

namespace Proiect_PWEB.Api.Features.Category.DeleteCategory
{
    public class DeleteCategoryHandler : IDeleteCategoryHandler
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(id, cancellationToken);

            if(category == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, $"Couldn't find the category with id {id}");
            }

            await categoryRepository.DeleteCategoryAsync(id, cancellationToken);
            await categoryRepository.SaveAsync(cancellationToken);

        }
    }
}
