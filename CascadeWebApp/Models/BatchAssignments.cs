using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class BatchAssignments
    {
        [Key]
        public int BatchAssignmentID { get; set; }

        // Foreign Keys
        public int BatchID { get; set; }
        public int OrdersID { get; set; }

        // Properties
        public int AssignedQuantity { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string AssignmentStatus { get; set; } = string.Empty; // e.g., "Assigned", "In Progress", "Completed"
        public DateTime? CompletionDate { get; set; }

        // Navigation properties
        [ForeignKey("BatchID")]
        public virtual BatchList Batch { get; set; } = null!;
        
        [ForeignKey("OrdersID")]
        public virtual OrdersList Order { get; set; } = null!;
    }
}