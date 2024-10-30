using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Entities;
using Mango.Service.CartAPI.Models.Dto;

namespace Mango.Service.CartAPI.Models
{
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        [NotMapped]
        public Cart? Cart { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        [NotMapped]
        public ProductDto ProductDto { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Total_money { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
