namespace Proiect_PWEB.Api.Features.Category.DeleteCategory
{
    public interface IDeleteCategoryHandler
    {
        public Task HandleAsync(Guid id, CancellationToken cancellationToken);
    }
}
