using System.ComponentModel.DataAnnotations;

namespace TechStore.Domain.Entities
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? IDCategory { get; set; }
        public int? IDBrand { get; set; }
    }
    public class ProductCreateRequest: ProductRequest
    {
        [Required(ErrorMessage = "ProductName is required")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int? Price { get; set; }

    }
    public class ProductUpdateRequest : ProductRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }

    }
}
