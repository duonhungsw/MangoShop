using Book.Core.Interfaces;
using Mango.Service.CartAPI.Models;
using Mango.Service.CartAPI.Repository;

namespace Mango.Service.CartAPI.Services;

public interface ICartService
{
    Task<Cart?> GetCartByAccountIdAsync(Guid id);
    void CreateCart(Cart cart);     

}
public class CartService(IUnitOfWork unitOfWork, ICartRepository cartRepository) : ICartService
{
	public void CreateCart(Cart cart) => unitOfWork.Repository<Cart>().Create(cart);

	public async Task<Cart?> GetCartByAccountIdAsync(Guid id) =>
        await cartRepository.GetObject<Cart>(x => x.AccountId == id);
}
