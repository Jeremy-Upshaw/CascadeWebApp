using System.ComponentModel.DataAnnotations;

namespace CascadeWebApp.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Required]
        public string Studio { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DiscountLevel { get; set; } = string.Empty;
        public string PaymentTerms { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        
        // Bill To fields for table display
        public string BillTo1 { get; set; } = string.Empty;
        public string BillTo2 { get; set; } = string.Empty;
        public string BillTo3 { get; set; } = string.Empty;
        public string BillTo4 { get; set; } = string.Empty;
        public string BillTo5 { get; set; } = string.Empty;
        
        // Ship To fields for table display  
        public string ShipTo1 { get; set; } = string.Empty;
        public string ShipTo2 { get; set; } = string.Empty;
        public string ShipTo3 { get; set; } = string.Empty;
        public string ShipTo4 { get; set; } = string.Empty;
        public string ShipTo5 { get; set; } = string.Empty;
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

        // Navigation properties
        public virtual ICollection<OrdersList> Orders { get; set; } = new List<OrdersList>();
    }
}
