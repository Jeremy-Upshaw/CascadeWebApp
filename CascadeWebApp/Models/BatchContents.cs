using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class BatchContents
    {
        [Key]
        public int BatchContentsID { get; set; }

        // Foreign Keys
        public int BatchID { get; set; }
        public int ProductID { get; set; }

        // Properties
        public int Quantity { get; set; }
        public int CompletedQuantity { get; set; }
        public decimal EstimatedWeight { get; set; }
        public decimal ActualWeight { get; set; }

        // Navigation properties
        [ForeignKey("BatchID")]
        public virtual BatchList Batch { get; set; } = null!;
        
        [ForeignKey("ProductID")]
        public virtual Items Item { get; set; } = null!;
    }
}