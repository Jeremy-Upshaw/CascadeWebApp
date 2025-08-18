using CascadeWebApp.Models;

namespace CascadeWebApp.Services
{
    public class OrderService
    {
        public Task<List<Order>> GetOrdersAsync()
        {
            // Placeholder data
            var orders = new List<Order>
            {
                new Order{ OrdersID=1, OrderNumber="ORD1001", OrderDate=DateTime.Now.AddDays(-5), Studio="Studio A", EstShipDate=DateTime.Now.AddDays(2), ShippingDeadline=DateTime.Now.AddDays(3), ShippingMethod="UPS", Partial=true, OrderStatus="Processing" },
                new Order{ OrdersID=2, OrderNumber="ORD1002", OrderDate=DateTime.Now.AddDays(-2), Studio="Studio B", EstShipDate=DateTime.Now.AddDays(4), ShippingDeadline=DateTime.Now.AddDays(5), ShippingMethod="FedEx", Partial=false, OrderStatus="Pending" }
            };
            return Task.FromResult(orders);
        }
    }
}
