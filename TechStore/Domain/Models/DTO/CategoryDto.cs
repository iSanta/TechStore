namespace TechStore.Domain.Models.DTO
{
    public class CategoryBaseDto: BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CategoryDto: CategoryBaseDto
    {
        public IEnumerable<ProductBaseDto> Products { get; set; }
    }
}
