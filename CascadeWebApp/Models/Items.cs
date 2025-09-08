using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadeWebApp.Models
{
    public class Items
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ItemNumber { get; set; } = string.Empty;
        public string Thread { get; set; } = string.Empty;
        public string Gauge { get; set; } = string.Empty;
        public string EndType { get; set; } = string.Empty;
        public string EndMM { get; set; } = string.Empty;
        public string EndInch { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public double? OnOrder { get; set; }
        public double? InProduction { get; set; }
        public double? OnTheWall { get; set; }
        public double? InTheShop { get; set; }
        public double? Available { get; set; }
        public double? MachiningLength { get; set; }
        public double? CycleTime { get; set; }
        public double? StockQty { get; set; }
        public double? BuildQty { get; set; }
        public double? MinStockSize { get; set; }
        public virtual ICollection<OrderContents> OrderContents { get; set; } = new List<OrderContents>();
        public virtual ICollection<BatchContents> BatchContents { get; set; } = new List<BatchContents>();
    }
}
