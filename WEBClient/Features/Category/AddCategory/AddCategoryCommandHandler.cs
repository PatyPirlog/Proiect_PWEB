using Proiect_PWEB.Core.Domain.CategoryDomain;

namespace Proiect_PWEB.Api.Features.Category.AddCategory
{
    public class AddCategoryCommandHandler : IAddCategoryCommandHandler
    {
        private readonly ICategoryRepository categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task HandleAsync(AddCategoryCommand command, CancellationToken cancellationToken) => categoryRepository.AddAsync(new InsertCategoryCommand(command.Name), cancellationToken);
        
    }
}
