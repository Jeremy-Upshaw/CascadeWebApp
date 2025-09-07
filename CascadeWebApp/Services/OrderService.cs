using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class OrderService
    {
        private readonly CascadeDbContext _context;

        public OrderService(CascadeDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrdersList>> GetOrdersAsync()
        {
            return await _context.OrdersList
                .Include(o => o.Customer)
                .Include(o => o.OrderContents)
                .ThenInclude(oc => oc.Item)
                .Include(o => o.BatchAssignments)
                .ThenInclude(ba => ba.Batch)
                .ToListAsync();
        }

        public async Task<OrdersList?> GetOrderByIdAsync(int orderId)
        {
            return await _context.OrdersList
                .Include(o => o.Customer)
                .Include(o => o.OrderContents)
                .ThenInclude(oc => oc.Item)
                .Include(o => o.BatchAssignments)
                .ThenInclude(ba => ba.Batch)
                .FirstOrDefaultAsync(o => o.OrdersID == orderId);
        }

        public async Task<OrdersList> CreateOrderAsync(OrdersList order)
        {
            _context.OrdersList.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrdersList> UpdateOrderAsync(OrdersList order)
        {
            _context.OrdersList.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.OrdersList.FindAsync(orderId);
            if (order != null)
            {
                _context.OrdersList.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
