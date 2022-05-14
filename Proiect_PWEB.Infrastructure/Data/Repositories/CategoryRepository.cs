using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.CategoryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PwebContext _context;

        public CategoryRepository(PwebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsertCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category(command.Name);

            await _context.Category.AddAsync(category, cancellationToken);
            await SaveAsync(cancellationToken);
            //throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Category model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DomainOfAggregate<Category>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
