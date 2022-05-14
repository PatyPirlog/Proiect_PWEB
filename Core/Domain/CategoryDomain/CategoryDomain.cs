using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CategoryDomain
{
    public class CategoryDomain : DomainOfAggregate<Category>
    {
        public CategoryDomain(Category aggregate) : base(aggregate)
        {
        }
    }
}
