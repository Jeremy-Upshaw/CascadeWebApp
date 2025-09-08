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
        public string Ship_To_1 { get; set; } = string.Empty;
        public string Ship_To_2 { get; set; } = string.Empty;
        public string Ship_To_3 { get; set; } = string.Empty;
        public string Ship_To_4 { get; set; } = string.Empty;
        public string Ship_To_5 { get; set; } = string.Empty;
        public string Bill_To_1 { get; set; } = string.Empty;
        public string Bill_To_2 { get; set; } = string.Empty;
        public string Bill_To_3 { get; set; } = string.Empty;
        public string Bill_To_4 { get; set; } = string.Empty;
        public string Bill_To_5 { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<OrdersList> Orders { get; set; } = new List<OrdersList>();
    }
}
