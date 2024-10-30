using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mango.Service.ProductAPI.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must have ablest 10 character")]
        public  string Name { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Name must have ablest 50 character")]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
