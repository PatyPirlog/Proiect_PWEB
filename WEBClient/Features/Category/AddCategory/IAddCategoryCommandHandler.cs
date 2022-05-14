namespace Proiect_PWEB.Api.Features.Category.AddCategory
{
    public interface IAddCategoryCommandHandler
    {
        public Task HandleAsync(AddCategoryCommand command, CancellationToken cancellationToken);
    }
}
