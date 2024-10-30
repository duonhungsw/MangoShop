using Core.Interfaces;
using Mango.Service.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.OrderAPI.Repository;

public interface IOrderRepository : IGenericRepository<Order>
{
	void AddOrderItem(OrderItem item);
	Task<IEnumerable<OrderItem>> GetPurchase(Guid orderId);

}
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
	public OrderRepository(OrderDbContext context) : base(context)
	{
	}

	public void AddOrderItem(OrderItem item) => _context.OrderItems.Add(item);

	public async Task<IEnumerable<OrderItem>> GetPurchase(Guid orderId)
	{
		return await _context.OrderItems.Where(x => x.OrderId == orderId).ToListAsync();
	}
}
