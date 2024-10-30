using Book.Core.Interfaces;
using Common.Extensions;
using Mango.Service.OrderAPI.Models;
using Mango.Service.OrderAPI.Repository;
using Microsoft.Identity.Client;

namespace Mango.Service.OrderAPI.Services;

public interface IOrderService
{
	Task<Order?> GetByIdAsync(Guid id);
	Task<Order?> GetOrderByAccountIdAsync(string token);

	Task<IEnumerable<Order>> GetAllAsync();
	void Delete(Order entity);
	void Update(Order entity);
	void Create(Order entity);
	void AddOrderItem(OrderItem entity);
	bool Exist(Guid id);

	Task<IEnumerable<OrderItem>> GetPurchase(string token);	

}
public class OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : IOrderService
{
	public void AddOrderItem(OrderItem entity)
	{
		orderRepository.AddOrderItem(entity);
	}

	public void Create(Order entity) 
	{
		entity.Id = Guid.NewGuid();
		unitOfWork.Repository<Order>().Create(entity);
	} 
	public void Delete(Order entity) => unitOfWork.Repository<Order>().Delete(entity);
	public bool Exist(Guid id) => unitOfWork.Repository<Order>().Exist(id);
	public async Task<IEnumerable<Order>> GetAllAsync() => await unitOfWork.Repository<Order>().GetAllAsync();
	public async Task<Order?> GetByIdAsync(Guid id) => await unitOfWork.Repository<Order>().GetByIdAsync(id);

	public async Task<Order?> GetOrderByAccountIdAsync(string token) 
	{
		string? accountId = JwtExtension.GetToken(token);

		var order =  await orderRepository.GetObject<Order>(x => x.AccountId == Guid.Parse(accountId));
		
		return order;

	} 

	public async Task<IEnumerable<OrderItem>> GetPurchase(string token)
	{
		var order = await GetOrderByAccountIdAsync(token);
		if (order == null)
		{
			return null;
		}
		return await orderRepository.GetPurchase(order.Id);
	}

	public void Update(Order entity) => unitOfWork.Repository<Order>().Update(entity);
}
