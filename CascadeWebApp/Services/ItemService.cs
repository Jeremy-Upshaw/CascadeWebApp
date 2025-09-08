using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class ItemService
    {
        private readonly CascadeDbContext? _context;

        public ItemService(CascadeDbContext? context = null)
        {
            _context = context;
        }

        public async Task<List<Items>> GetItemsAsync()
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                await Task.Delay(10);
                return new List<Items>
                {
                    new Items { ProductID = 1, ItemNumber = "IT001", Thread = "M8x1.25", Gauge = "10", EndType = "Flat", EndMM = "12", EndInch = "0.47", Length = "100", OnOrder = 20, InProduction = 15, OnTheWall = 50, InTheShop = 25, Available = 35, MachiningLength = 95, CycleTime = 2.5, StockQty = 100, BuildQty = 50, MinStockSize = 25 },
                    new Items { ProductID = 2, ItemNumber = "IT002", Thread = "M10x1.5", Gauge = "12", EndType = "Round", EndMM = "15", EndInch = "0.59", Length = "120", OnOrder = 15, InProduction = 10, OnTheWall = 40, InTheShop = 30, Available = 25, MachiningLength = 115, CycleTime = 3.0, StockQty = 80, BuildQty = 40, MinStockSize = 20 },
                    new Items { ProductID = 3, ItemNumber = "IT003", Thread = "M12x1.75", Gauge = "14", EndType = "Hex", EndMM = "18", EndInch = "0.71", Length = "150", OnOrder = 25, InProduction = 20, OnTheWall = 60, InTheShop = 35, Available = 45, MachiningLength = 145, CycleTime = 4.0, StockQty = 120, BuildQty = 60, MinStockSize = 30 },
                    new Items { ProductID = 4, ItemNumber = "IT004", Thread = "M6x1.0", Gauge = "8", EndType = "Square", EndMM = "10", EndInch = "0.39", Length = "80", OnOrder = 30, InProduction = 25, OnTheWall = 70, InTheShop = 40, Available = 55, MachiningLength = 75, CycleTime = 2.0, StockQty = 150, BuildQty = 75, MinStockSize = 35 },
                    new Items { ProductID = 5, ItemNumber = "IT005", Thread = "M14x2.0", Gauge = "16", EndType = "Oval", EndMM = "20", EndInch = "0.79", Length = "180", OnOrder = 18, InProduction = 12, OnTheWall = 45, InTheShop = 28, Available = 32, MachiningLength = 175, CycleTime = 5.0, StockQty = 90, BuildQty = 45, MinStockSize = 22 },
                    new Items { ProductID = 6, ItemNumber = "IT006", Thread = "M16x2.5", Gauge = "18", EndType = "Tapered", EndMM = "25", EndInch = "0.98", Length = "200", OnOrder = 12, InProduction = 8, OnTheWall = 35, InTheShop = 20, Available = 27, MachiningLength = 195, CycleTime = 6.0, StockQty = 70, BuildQty = 35, MinStockSize = 18 },
                    new Items { ProductID = 7, ItemNumber = "IT007", Thread = "M5x0.8", Gauge = "6", EndType = "Chamfered", EndMM = "8", EndInch = "0.31", Length = "60", OnOrder = 40, InProduction = 35, OnTheWall = 80, InTheShop = 50, Available = 65, MachiningLength = 55, CycleTime = 1.5, StockQty = 200, BuildQty = 100, MinStockSize = 50 },
                    new Items { ProductID = 8, ItemNumber = "IT008", Thread = "M18x2.5", Gauge = "20", EndType = "Knurled", EndMM = "28", EndInch = "1.10", Length = "220", OnOrder = 8, InProduction = 5, OnTheWall = 25, InTheShop = 15, Available = 18, MachiningLength = 215, CycleTime = 7.0, StockQty = 50, BuildQty = 25, MinStockSize = 12 }
                };
            }

            return await _context.Items
                .ToListAsync();
        }

        public async Task<Items?> GetItemByIdAsync(int productId)
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                var items = await GetItemsAsync();
                return items.FirstOrDefault(i => i.ProductID == productId);
            }

            return await _context.Items
                .Include(i => i.OrderContents)
                .Include(i => i.BatchContents)
                .FirstOrDefaultAsync(i => i.ProductID == productId);
        }

        public async Task<Items> CreateItemAsync(Items item)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return item;
            }

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Items> UpdateItemAsync(Items item)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return item;
            }

            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int productId)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return;
            }

            var item = await _context.Items.FindAsync(productId);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
