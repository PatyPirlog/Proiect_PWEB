using Proiect_PWEB.Core.Domain.CategoryDomain;

namespace Proiect_PWEB.Api.Features.Category.AddCategory
{
    public class AddCategoryCommand : InsertCategoryCommand
    {
        public AddCategoryCommand(string name) : base(name)
        {
        }
    }
}
