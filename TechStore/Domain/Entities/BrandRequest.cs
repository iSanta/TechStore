using System.ComponentModel.DataAnnotations;

namespace TechStore.Domain.Entities
{
    public class BrandRequest
    {
            public string? BrandName { get; set; }
            public string? Description { get; set; }
    }

    public class BrandCreateRequest : BrandRequest
    {
        [Required(ErrorMessage = "BrandName is required")]
        public string? BrandName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }

    public class BrandUpdateRequest : BrandRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }

    }


}
