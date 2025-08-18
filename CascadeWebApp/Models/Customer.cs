namespace CascadeWebApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Studio { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DiscountLevel { get; set; } = string.Empty;
        public string PaymentTerms { get; set; } = string.Empty;

        // Modal fields for detail
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactSecondName { get; set; } = string.Empty;
        public string ShippingAddressLine1 { get; set; } = string.Empty;
        public string ShippingAddressLine2 { get; set; } = string.Empty;
        public string ShippingCity { get; set; } = string.Empty;
        public string ShippingState { get; set; } = string.Empty;
        public string ShippingZip { get; set; } = string.Empty;
        public string ShippingCountry { get; set; } = string.Empty;
        public string BillingAddressLine1 { get; set; } = string.Empty;
        public string BillingAddressLine2 { get; set; } = string.Empty;
        public string BillingCity { get; set; } = string.Empty;
        public string BillingState { get; set; } = string.Empty;
        public string BillingZip { get; set; } = string.Empty;
        public string BillingCountry { get; set; } = string.Empty;
    }
}
