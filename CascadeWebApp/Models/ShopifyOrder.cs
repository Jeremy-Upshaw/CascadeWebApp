using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    [Table("shopify_orders")]
    public class ShopifyOrder
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Email { get; set; }
        public string? FinancialStatus { get; set; }
        public string? FulfillmentStatus { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? SubtotalPrice { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalShippingPrice { get; set; }
        public bool? Confirmed { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancelReason { get; set; }
        public string? Tags { get; set; }
        public int? OrderNumber { get; set; }
        public string? Note { get; set; }
        
        // Customer fields
        public string? Customer_Id { get; set; }
        public string? Customer_Email { get; set; }
        public string? Customer_FirstName { get; set; }
        public string? Customer_LastName { get; set; }
        public string? Customer_Phone { get; set; }
        public DateTime? Customer_CreatedAt { get; set; }
        public int? Customer_OrdersCount { get; set; }
        public string? Customer_State { get; set; }
        
        // Shipping Address fields
        public string? ShippingAddress_Address1 { get; set; }
        public string? ShippingAddress_Address2 { get; set; }
        public string? ShippingAddress_City { get; set; }
        public string? ShippingAddress_Company { get; set; }
        public string? ShippingAddress_Country { get; set; }
        public string? ShippingAddress_CountryCode { get; set; }
        public string? ShippingAddress_FirstName { get; set; }
        public string? ShippingAddress_LastName { get; set; }
        public string? ShippingAddress_Phone { get; set; }
        public string? ShippingAddress_Province { get; set; }
        public string? ShippingAddress_ProvinceCode { get; set; }
        public string? ShippingAddress_Zip { get; set; }
        
        // Billing Address fields
        public string? BillingAddress_Address1 { get; set; }
        public string? BillingAddress_Address2 { get; set; }
        public string? BillingAddress_City { get; set; }
        public string? BillingAddress_Company { get; set; }
        public string? BillingAddress_Country { get; set; }
        public string? BillingAddress_CountryCode { get; set; }
        public string? BillingAddress_FirstName { get; set; }
        public string? BillingAddress_LastName { get; set; }
        public string? BillingAddress_Phone { get; set; }
        public string? BillingAddress_Province { get; set; }
        public string? BillingAddress_ProvinceCode { get; set; }
        public string? BillingAddress_Zip { get; set; }
        
        // Line Item fields
        public string? LineItem_Id { get; set; }
        public string? LineItem_Title { get; set; }
        public string? LineItem_Sku { get; set; }
        public string? LineItem_VariantId { get; set; }
        public int? LineItem_Quantity { get; set; }
        public decimal? LineItem_Price { get; set; }
        public string? LineItem_FulfillmentStatus { get; set; }
        public string? LineItem_Vendor { get; set; }
        
        // Discount fields
        public string? Discount_Code { get; set; }
        public string? Discount_Type { get; set; }
        public decimal? Discount_Value { get; set; }
        
        // Shipping Line fields
        public string? ShippingLine_Code { get; set; }
        public decimal? ShippingLine_Price { get; set; }
        public string? ShippingLine_Title { get; set; }
        
        // Transaction fields
        public string? Transaction_Id { get; set; }
        public decimal? Transaction_Amount { get; set; }
        public string? Transaction_Kind { get; set; }
        public string? Transaction_Status { get; set; }
    }
}