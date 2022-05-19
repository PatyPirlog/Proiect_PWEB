using Proiect_PWEB.Api.Features.Category.AddCategory;
using Proiect_PWEB.Api.Features.Category.DeleteCategory;
using Proiect_PWEB.Api.Features.Category.GetAllCategories;

namespace Proiect_PWEB.Api.Features.Category
{
    public static class CategoryModule
    {
        public static void AddCategoriesHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddCategoryCommandHandler, AddCategoryCommandHandler>();
            services.AddTransient<IGetAllCategoriesQueryHandler, GetAllCategoriesQueryHandler>();
            services.AddTransient<IDeleteCategoryHandler, DeleteCategoryHandler>();
        }
    }
}
