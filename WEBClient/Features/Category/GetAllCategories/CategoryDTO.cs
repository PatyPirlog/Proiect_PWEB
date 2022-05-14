namespace Proiect_PWEB.Api.Features.Category.GetAllCategories
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
