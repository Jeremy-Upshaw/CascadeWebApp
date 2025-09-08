using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class ItemService
    {
        private readonly CascadeDbContext _context;

        public ItemService(CascadeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Items>> GetItemsAsync()
        {
            return await _context.Items
                .ToListAsync();
        }

        public async Task<Items?> GetItemByIdAsync(int productId)
        {
            return await _context.Items
                .Include(i => i.OrderContents)
                .Include(i => i.BatchContents)
                .FirstOrDefaultAsync(i => i.ProductID == productId);
        }

        public async Task<Items> CreateItemAsync(Items item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Items> UpdateItemAsync(Items item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int productId)
        {
            var item = await _context.Items.FindAsync(productId);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
