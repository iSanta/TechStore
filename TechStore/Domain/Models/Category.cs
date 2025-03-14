﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechStore.Domain.Models;

namespace TechStore.Core.Entities
{
    public class Category(): BaseEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;

        public virtual ICollection<Product> Products { get; set; }
    }
}
