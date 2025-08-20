namespace CascadeWebApp.Models
{
    public class Batch
    {
        public int BatchID { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int PartsCount { get; set; }
        public double PluggedWeight { get; set; }
        public DateTime EstFinishDate { get; set; }

        // Modal-only fields can be added here
    }
}
