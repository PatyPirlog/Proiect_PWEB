using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CategoryDomain
{
    public class InsertCategoryCommand : ICreateAggregateCommand
    {
        public string Name { get; set; }

        public InsertCategoryCommand(string name)
        {
            Name = name;
        }
    }
}
