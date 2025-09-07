using System.ComponentModel.DataAnnotations;

namespace CascadeWebApp.Models
{
    public class BatchList
    {
        [Key]
        public int BatchID { get; set; }
        
        [Required]
        public string BatchNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int PartsCount { get; set; }
        public double PluggedWeight { get; set; }
        public DateTime EstFinishDate { get; set; }

        // Navigation properties
        public virtual ICollection<BatchContents> BatchContents { get; set; } = new List<BatchContents>();
        public virtual ICollection<BatchLoss> BatchLoss { get; set; } = new List<BatchLoss>();
        public virtual ICollection<BatchAssignments> BatchAssignments { get; set; } = new List<BatchAssignments>();
    }
}
