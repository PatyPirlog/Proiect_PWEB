namespace Proiect_PWEB.Api.Features.Category.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
