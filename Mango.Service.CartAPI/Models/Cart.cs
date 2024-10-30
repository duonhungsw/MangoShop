using Common.Entities;

namespace Mango.Service.CartAPI.Models
{
    public class Cart : BaseEntity
    {
        public Guid AccountId { get; set; }
    }
}
