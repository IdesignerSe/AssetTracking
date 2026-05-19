namespace AssetTracking.Models
{
    public class Asset
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceLocal { get; set; }
        public string Office { get; set; }
        public string AssetType { get; set; }

        public Asset(string brand, string model, DateTime purchaseDate,
                     decimal priceUSD, decimal priceLocal, string office, string assetType)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
            PriceLocal = priceLocal;
            Office = office;
            AssetType = assetType;
        }
    }
}
