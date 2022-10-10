namespace _01_Fazli_MarketQuery.Contracts.Electrical_System.Box_Meter
{
    public class Meter_Op
    {
        public int Meter_Id { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public string Meter_Cod { get; set; }
        public string Location_M { get; set; }
        public string Location_S { get; set; }
        public string ShopKeeper { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public decimal Complete { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
        public string Total_Persian { get; set; }
    }
}