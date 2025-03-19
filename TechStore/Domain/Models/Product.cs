using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechStore.Core.Entities;

namespace TechStore.Domain.Models
{
    public class Product(): BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public int? IDCategory { get; set; } = 0;
        public int? IDBrand { get; set; } = 0;

        [ForeignKey(nameof(IDCategory))]
        public virtual Category? Category { get; set; }

        [ForeignKey(nameof(IDBrand))]
        public virtual Brand? Brand { get; set; }
    }
}
