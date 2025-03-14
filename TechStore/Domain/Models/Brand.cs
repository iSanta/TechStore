using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Domain.Models
{
    public class Brand : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
