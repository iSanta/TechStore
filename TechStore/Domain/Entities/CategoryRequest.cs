using System.ComponentModel.DataAnnotations;


namespace TechStore.Domain.Entities
{
    public class CategoryRequest
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryCreateRequest : CategoryRequest
    {
        [Required(ErrorMessage = "CategoryName is required")]
        public string? CategoryName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }

    public class CategoryUpdateRequest: CategoryRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }
 
    }
}
