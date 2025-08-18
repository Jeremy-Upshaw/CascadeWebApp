namespace CascadeWebApp.Models
{
    public class Order
    {
        public int OrdersID { get; set; } // hidden, for sort/filter
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Studio { get; set; } = string.Empty;
        public DateTime EstShipDate { get; set; }
        public DateTime ShippingDeadline { get; set; }
        public string ShippingMethod { get; set; } = string.Empty;
        public bool Partial { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        // Modal fields for detail
        // (repeat as needed, can expand per future requirements)
    }
}
