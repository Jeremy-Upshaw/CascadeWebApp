using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class ShopifyOrderService
    {
        private readonly CascadeDbContext _context;

        public ShopifyOrderService(CascadeDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShopifyOrder>> GetShopifyOrdersAsync()
        {
            return await _context.ShopifyOrders.ToListAsync();
        }

        public async Task<ShopifyOrder?> GetShopifyOrderByIdAsync(string orderId)
        {
            return await _context.ShopifyOrders
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<ShopifyOrder> CreateShopifyOrderAsync(ShopifyOrder order)
        {
            _context.ShopifyOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<ShopifyOrder> UpdateShopifyOrderAsync(ShopifyOrder order)
        {
            _context.ShopifyOrders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteShopifyOrderAsync(string orderId)
        {
            var order = await _context.ShopifyOrders.FindAsync(orderId);
            if (order != null)
            {
                _context.ShopifyOrders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}