using Book.Core.Interfaces;
using Mango.Service.CartAPI.Models;
using Mango.Service.CartAPI.Repository;

namespace Mango.Service.CartItemAPI.Services;

public interface ICartItemService
{
    Task<CartItem?> GetByIdAsync(Guid id);
    Task<CartItem?> GetByProductIdAsync(Guid id, Guid CartId);
    Task<IEnumerable<CartItem>> GetAllAsync();
    void Delete(CartItem entity);
    void UpdateCartItem(CartItem entity);
    void AddToCart(CartItem entity);
    bool Exist(Guid id);
	Task<IEnumerable<CartItem>> GetShoppingCartByCartIdAsync(Guid Id);
	Task<IEnumerable<CartItem>> GetOrderAsync(Guid id);

}
public class CartItemService(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository) : ICartItemService
{
    public void AddToCart(CartItem entity)=>unitOfWork.Repository<CartItem>().Create(entity);
    public void Delete(CartItem entity) => unitOfWork.Repository<CartItem>().Delete(entity);
    public bool Exist(Guid id) => unitOfWork.Repository<CartItem>().Exist(id);
    public Task<IEnumerable<CartItem>> GetAllAsync() => unitOfWork.Repository<CartItem>().GetAllAsync();


	public async Task<CartItem?> GetByIdAsync(Guid id) => await unitOfWork.Repository<CartItem>().GetByIdAsync(id);

    public async Task<CartItem?> GetByProductIdAsync(Guid id, Guid CartId) => await cartItemRepository.GetObject<CartItem>(x => x.ProductId == id && x.CartId == CartId);

    public async Task<IEnumerable<CartItem>> GetOrderAsync(Guid id)
        => await cartItemRepository.GetOrderAsync(id);
        
	public async Task<IEnumerable<CartItem>> GetShoppingCartByCartIdAsync(Guid Id)
        => await cartItemRepository.GetShoppingCartByCartIdAsync(Id);

	public void UpdateCartItem(CartItem entity) => unitOfWork.Repository<CartItem>().Update(entity);
}
