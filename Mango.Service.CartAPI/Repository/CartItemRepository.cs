using Core.Interfaces;
using Mango.Service.CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.CartAPI.Repository
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetShoppingCartByCartIdAsync(Guid Id);
		Task<IEnumerable<CartItem>> GetOrderAsync(Guid Id);


	}
	public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(CartDbContext context) : base(context)
        {
        }

		public async Task<IEnumerable<CartItem>> GetOrderAsync(Guid Id)
            => await _context.CartItems.Where(x =>  x.Status == true && x.CartId == Id).ToListAsync();
		public async Task<IEnumerable<CartItem>> GetShoppingCartByCartIdAsync(Guid Id)
            => await _context.CartItems.Where(x => x.CartId == Id).ToListAsync();
	}
}
