using Common.Entities;
using Mango.Service.OrderAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Service.OrderAPI.Models
{
    public class Order : BaseEntity
    {
        [ForeignKey("AccountId")]
        public Guid AccountId { get; set; }
		[NotMapped]

		public AccountDto? AccountDto { get; set; }
		[ForeignKey("CouponId")]
		public Guid CouponId { get; set; }
		[NotMapped]
		public CouponDto? CouponDto { get; set; }
        [Required]
        public string? Address { get; set; }
		[Required]
		public string? Phone { get; set; }
		[Required]
		public string? Note { get; set; }
		[Required]
		public decimal TotalMoney { get; set; }
    }
}
