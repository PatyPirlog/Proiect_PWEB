namespace Proiect_PWEB.Api.Features.Category.GetAllCategories
{
    public interface IGetAllCategoriesQueryHandler
    {
        public Task<IEnumerable<CategoryDTO>> HandleAsync(CancellationToken cancellationToken);
    }
}
