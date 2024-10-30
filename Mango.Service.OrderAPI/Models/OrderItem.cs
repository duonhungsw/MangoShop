using Common.Entities;
using Mango.Service.OrderAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Service.OrderAPI.Models
{
    public class OrderItem : BaseEntity
    {
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
		[ForeignKey("ProductId")]
		public Guid ProductId { get; set; }
		[NotMapped]
		public ProductDto? ProductDto { get; set; }
        [Required]
        public decimal? Price { get; set; }
		[Required]
		public decimal? PriceTotal { get; set; }
		[Required]
		public int Quantity { get; set; }
    }
}
