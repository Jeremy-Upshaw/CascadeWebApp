public class Item
{
    public string ItemNumber { get; set; }
    public string Thread { get; set; }
    public string Gauge { get; set; }
    public string EndType { get; set; }
    public string EndMM { get; set; }
    public string EndInch { get; set; }
    public string Length { get; set; }
    public double OnOrder { get; set; }
    public double InProduction { get; set; }
    public double OnTheWall { get; set; }
    public double InTheShop { get; set; }
    public double Available { get; set; }
    public double MachiningLength { get; set; }
    public double CycleTime { get; set; }
    public double StockQty { get; set; }
    public double BuildQty { get; set; }
    public double MinStockSize { get; set; }
}