using CascadeWebApp.Models;

namespace CascadeWebApp.Services
{
    public class ItemService
    {
        public Task<List<Item>> GetItemsAsync()
        {
            // Placeholder data
            var items = new List<Item>
            {
                new Item{ ProductID=1, ItemNumber="A101", Thread="M8", Gauge="10", EndType="Flat", EndMM="12", EndInch="0.47", Length="100", OnOrder=5, InProduction=10, OnTheWall=8, InTheShop=2, Available=15, MachiningLength="95", CycleTime="1:30", StockQty=10, BuildQty=20, MinStockSize=5 },
                new Item{ ProductID=2, ItemNumber="B202", Thread="M10", Gauge="12", EndType="Round", EndMM="15", EndInch="0.59", Length="110", OnOrder=2, InProduction=5, OnTheWall=12, InTheShop=4, Available=18, MachiningLength="105", CycleTime="1:45", StockQty=12, BuildQty=18, MinStockSize=7 }
            };
            return Task.FromResult(items);
        }
    }
}
