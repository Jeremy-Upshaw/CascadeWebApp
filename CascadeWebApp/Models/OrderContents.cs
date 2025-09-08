using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class OrderContents
    {
        [Key]
        [Column("OrderContentID")]
        public int OrderContentID { get; set; }

        // Foreign Keys
        [Column("OrderID")]
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }

        // Properties
        [Column("QtyOrdered")]
        public int? QtyOrdered { get; set; }
        public int? QtyRemaining { get; set; }
        public int? QtyPulled { get; set; }
        public int? QtyShipped { get; set; }
        public int? QtyAssigned { get; set; }
        public bool? NeedsAssigned { get; set; }

        // Navigation properties
        [ForeignKey("OrderID")]
        public virtual OrdersList Order { get; set; } = null!;
        
        [ForeignKey("ProductID")]
        public virtual Items Item { get; set; } = null!;
    }
}