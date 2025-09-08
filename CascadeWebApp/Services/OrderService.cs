using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class OrderService
    {
        private readonly CascadeDbContext? _context;

        public OrderService(CascadeDbContext? context = null)
        {
            _context = context;
        }

        public async Task<List<OrdersList>> GetOrdersAsync()
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                await Task.Delay(10);
                return new List<OrdersList>
                {
                    new OrdersList 
                    { 
                        OrdersID = 1, 
                        OrderNumber = "ORD-001", 
                        OrderDate = DateTime.Now.AddDays(-10), 
                        EstShipDate = DateTime.Now.AddDays(-2), 
                        ShippingDeadline = DateTime.Now.AddDays(1), 
                        ShippingMethod = "UPS Ground", 
                        Partial = false, 
                        OrderStatus = "Processing",
                        CustomerID = 1,
                        Customer = new Customers { Studio = "Acme Photography Studio" }
                    },
                    new OrdersList 
                    { 
                        OrdersID = 2, 
                        OrderNumber = "ORD-002", 
                        OrderDate = DateTime.Now.AddDays(-8), 
                        EstShipDate = DateTime.Now.AddDays(1), 
                        ShippingDeadline = DateTime.Now.AddDays(3), 
                        ShippingMethod = "FedEx Express", 
                        Partial = true, 
                        OrderStatus = "Pending",
                        CustomerID = 2,
                        Customer = new Customers { Studio = "Creative Vision Labs" }
                    },
                    new OrdersList 
                    { 
                        OrdersID = 3, 
                        OrderNumber = "ORD-003", 
                        OrderDate = DateTime.Now.AddDays(-15), 
                        EstShipDate = DateTime.Now.AddDays(-5), 
                        ShippingDeadline = DateTime.Now.AddDays(-3), 
                        ShippingMethod = "DHL Standard", 
                        Partial = false, 
                        OrderStatus = "Shipped",
                        CustomerID = 3,
                        Customer = new Customers { Studio = "Artisan Works" }
                    },
                    new OrdersList 
                    { 
                        OrdersID = 4, 
                        OrderNumber = "ORD-004", 
                        OrderDate = DateTime.Now.AddDays(-5), 
                        EstShipDate = DateTime.Now.AddDays(3), 
                        ShippingDeadline = DateTime.Now.AddDays(5), 
                        ShippingMethod = "USPS Priority", 
                        Partial = true, 
                        OrderStatus = "In Production",
                        CustomerID = 4,
                        Customer = new Customers { Studio = "Digital Dreams" }
                    },
                    new OrdersList 
                    { 
                        OrdersID = 5, 
                        OrderNumber = "ORD-005", 
                        OrderDate = DateTime.Now.AddDays(-3), 
                        EstShipDate = DateTime.Now.AddDays(4), 
                        ShippingDeadline = DateTime.Now.AddDays(7), 
                        ShippingMethod = "UPS Next Day", 
                        Partial = false, 
                        OrderStatus = "Confirmed",
                        CustomerID = 5,
                        Customer = new Customers { Studio = "Pro Photo Services" }
                    }
                };
            }

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
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                var orders = await GetOrdersAsync();
                return orders.FirstOrDefault(o => o.OrdersID == orderId);
            }

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
            if (_context == null)
            {
                await Task.Delay(10);
                return order;
            }

            _context.OrdersList.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrdersList> UpdateOrderAsync(OrdersList order)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return order;
            }

            _context.OrdersList.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return;
            }

            var order = await _context.OrdersList.FindAsync(orderId);
            if (order != null)
            {
                _context.OrdersList.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
