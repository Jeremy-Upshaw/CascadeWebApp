namespace CascadeWebApp.Models
{
    public class Item
    {
        public int ProductID { get; set; } // hidden, for sort/filter
        public string ItemNumber { get; set; } = string.Empty;
        public string Thread { get; set; } = string.Empty;
        public string Gauge { get; set; } = string.Empty;
        public string EndType { get; set; } = string.Empty;
        public string EndMM { get; set; } = string.Empty;
        public string EndInch { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public int OnOrder { get; set; }
        public int InProduction { get; set; }
        public int OnTheWall { get; set; }
        public int InTheShop { get; set; }
        public int Available { get; set; }

        // Modal-only fields
        public string MachiningLength { get; set; } = string.Empty;
        public string CycleTime { get; set; } = string.Empty;
        public int StockQty { get; set; }
        public int BuildQty { get; set; }
        public int MinStockSize { get; set; }
    }
}
