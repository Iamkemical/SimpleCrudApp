using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrudApp.Models
{
    public class ProductModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [Display(Name ="Amount/Item ($)")]
        public double AmountPurchased { get; set; }
    }
}
