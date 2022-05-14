using Proiect_PWEB.Api.Features.Category.AddCategory;

namespace Proiect_PWEB.Api.Features.Category
{
    public static class CategoryModule
    {
        public static void AddCategoryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddCategoryCommandHandler, AddCategoryCommandHandler>();
        }
    }
}
