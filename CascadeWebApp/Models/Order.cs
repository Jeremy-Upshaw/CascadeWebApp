using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class OrdersList
    {
        [Key]
        public int OrdersID { get; set; }
        
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Studio { get; set; } = string.Empty;
        public DateTime EstShipDate { get; set; }
        public DateTime ShippingDeadline { get; set; }
        public string ShippingMethod { get; set; } = string.Empty;
        public bool Partial { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        // Foreign Keys
        public int CustomerID { get; set; }

        // Navigation properties
        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; } = null!;
        public virtual ICollection<OrderContents> OrderContents { get; set; } = new List<OrderContents>();
        public virtual ICollection<BatchAssignments> BatchAssignments { get; set; } = new List<BatchAssignments>();
    }
}
