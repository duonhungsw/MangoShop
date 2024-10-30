using Core.Interfaces;
using Mango.Service.CartAPI.Models;

namespace Mango.Service.CartAPI.Repository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
    }
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(CartDbContext context) : base(context)
        {
        }
    }
   
}
