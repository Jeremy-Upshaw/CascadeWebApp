using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class OrderContents
    {
        [Key]
        public int OrderContentsID { get; set; }

        // Foreign Keys
        public int OrdersID { get; set; }
        public int ProductID { get; set; }

        // Properties
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        [ForeignKey("OrdersID")]
        public virtual OrdersList Order { get; set; } = null!;
        
        [ForeignKey("ProductID")]
        public virtual Items Item { get; set; } = null!;
    }
}