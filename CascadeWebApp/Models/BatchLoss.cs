using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class BatchLoss
    {
        [Key]
        public int BatchLossID { get; set; }

        // Foreign Key
        public int BatchID { get; set; }

        // Properties
        public string LossType { get; set; } = string.Empty; // e.g., "Scrap", "Rework", "Material"
        public string Description { get; set; } = string.Empty;
        public decimal LossQuantity { get; set; }
        public decimal LossWeight { get; set; }
        public DateTime DateReported { get; set; }
        public string ReportedBy { get; set; } = string.Empty;

        // Navigation property
        [ForeignKey("BatchID")]
        public virtual BatchList Batch { get; set; } = null!;
    }
}