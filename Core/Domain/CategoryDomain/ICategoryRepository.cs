using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CategoryDomain
{
    public interface ICategoryRepository : IRepositoryOfAggregate<Category, InsertCategoryCommand>
    {
        public Task DeleteUserAsync(Category model, CancellationToken cancellationToken);
    }
}
