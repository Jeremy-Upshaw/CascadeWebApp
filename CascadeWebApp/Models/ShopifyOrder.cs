using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    [Table("shopify_orders")]
    public class ShopifyOrder
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FinancialStatus { get; set; } = string.Empty;
        public string FulfillmentStatus { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SubtotalPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalTax { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalShipping { get; set; }
        
        public bool? Confirmed { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string CancelReason { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        
        // Customer Information
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public DateTime? CustomerCreatedAt { get; set; }
        public int? CustomerOrdersCount { get; set; }
        public string CustomerState { get; set; } = string.Empty;
        
        // Shipping Address
        public string ShippingAddress1 { get; set; } = string.Empty;
        public string ShippingAddress2 { get; set; } = string.Empty;
        public string ShippingCity { get; set; } = string.Empty;
        public string ShippingCompany { get; set; } = string.Empty;
        public string ShippingCountry { get; set; } = string.Empty;
        public string ShippingCountryCode { get; set; } = string.Empty;
        public string ShippingFirstName { get; set; } = string.Empty;
        public string ShippingLastName { get; set; } = string.Empty;
        public string ShippingPhone { get; set; } = string.Empty;
        public string ShippingProvince { get; set; } = string.Empty;
        public string ShippingProvinceCode { get; set; } = string.Empty;
        public string ShippingZip { get; set; } = string.Empty;
        
        // Billing Address
        public string BillingAddress1 { get; set; } = string.Empty;
        public string BillingAddress2 { get; set; } = string.Empty;
        public string BillingCity { get; set; } = string.Empty;
        public string BillingCompany { get; set; } = string.Empty;
        public string BillingCountry { get; set; } = string.Empty;
        public string BillingCountryCode { get; set; } = string.Empty;
        public string BillingFirstName { get; set; } = string.Empty;
        public string BillingLastName { get; set; } = string.Empty;
        public string BillingPhone { get; set; } = string.Empty;
        public string BillingProvince { get; set; } = string.Empty;
        public string BillingProvinceCode { get; set; } = string.Empty;
        public string BillingZip { get; set; } = string.Empty;
        
        // Line Items
        public string LineItemsId { get; set; } = string.Empty;
        public string LineItemsTitle { get; set; } = string.Empty;
        public string LineItemsSku { get; set; } = string.Empty;
        public string LineItemsVariantId { get; set; } = string.Empty;
        public int? LineItemsQuantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? LineItemsPrice { get; set; }
        
        public string LineItemsFulfillmentStatus { get; set; } = string.Empty;
        public string LineItemsVendor { get; set; } = string.Empty;
        
        // Discount Applications
        public string DiscountApplicationsCode { get; set; } = string.Empty;
        public string DiscountApplicationsType { get; set; } = string.Empty;
        public string DiscountApplicationsValue { get; set; } = string.Empty;
        
        // Shipping Lines
        public string ShippingLinesCode { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingLinesPrice { get; set; }
        
        public string ShippingLinesTitle { get; set; } = string.Empty;
        
        // Transactions
        public string TransactionsId { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TransactionsAmount { get; set; }
        
        public string TransactionsKind { get; set; } = string.Empty;
        public string TransactionsStatus { get; set; } = string.Empty;
    }
}