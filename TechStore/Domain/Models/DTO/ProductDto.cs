using System.ComponentModel.DataAnnotations.Schema;
using TechStore.Core.Entities;

namespace TechStore.Domain.Models.DTO
{
    public class ProductDtoBase
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int IDCategory { get; set; }
        public int IDBrand { get; set; }
    }

    public class ProductDto: ProductDtoBase
    {
        public CategoryDtoBase Category { get; set; }
        public BrandDtoBase Brand { get; set; }

    }
}
