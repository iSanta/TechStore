namespace TechStore.Domain.Models.DTO
{
    public class BrandBaseDto: BaseEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
    public class BrandDto: BrandBaseDto
    {
        public IEnumerable<ProductBaseDto> Products { get; set; }
    }
}
