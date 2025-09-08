using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        
        public string? Studio { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? DiscountLevel { get; set; }
        public string? PaymentTerms { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        [Column("Ship To 1")]
        public string? Ship_To_1 { get; set; }
        [Column("Ship To 2")]
        public string? Ship_To_2 { get; set; }
        [Column("Ship To 3")]
        public string? Ship_To_3 { get; set; }
        [Column("Ship To 4")]
        public string? Ship_To_4 { get; set; }
        [Column("Ship To 5")]
        public string? Ship_To_5 { get; set; }
        
        [Column("Bill To 1")]
        public string? Bill_To_1 { get; set; }
        [Column("Bill To 2")]
        public string? Bill_To_2 { get; set; }
        [Column("Bill To 3")]
        public string? Bill_To_3 { get; set; }
        [Column("Bill To 4")]
        public string? Bill_To_4 { get; set; }
        [Column("Bill To 5")]
        public string? Bill_To_5 { get; set; }

        // Navigation properties
        public virtual ICollection<OrdersList> Orders { get; set; } = new List<OrdersList>();
    }
}
