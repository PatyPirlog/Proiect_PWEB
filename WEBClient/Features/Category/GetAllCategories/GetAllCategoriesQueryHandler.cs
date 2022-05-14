using Proiect_PWEB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Proiect_PWEB.Api.Features.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IGetAllCategoriesQueryHandler
    {
        private readonly PwebContext _context;

        public GetAllCategoriesQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> HandleAsync(CancellationToken cancellationToken)
        {
            var categoriesDTOs = await _context.Category
                .AsNoTracking()
                .Select(category => new CategoryDTO(
                    category.Id,
                    category.Name
                    )).ToListAsync(cancellationToken);

            return categoriesDTOs;
        }
    }
}
