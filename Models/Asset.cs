using System.Text.Json.Serialization;

namespace AssetTracking.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(Computer), typeDiscriminator: "computer")]
    [JsonDerivedType(typeof(MobilePhone), typeDiscriminator: "mobile")]
    [JsonDerivedType(typeof(Tablet), typeDiscriminator: "tablet")]
    public abstract class Asset
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal PriceLocal { get; set; }
        public string Office { get; set; }

        public Asset(string brand, string model, DateTime purchaseDate, decimal priceUSD, decimal priceLocal, string office)
        {
            Id = _nextId++;
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
            PriceLocal = priceLocal;
            Office = office;
        }

        public virtual string GetAssetType()
        {
            return "Asset";
        }

        public int GetAge()
        {
            return DateTime.Now.Year - PurchaseDate.Year;
        }

        // Needed for JSON deserialization
        public static void UpdateNextId(int maxId)
        {
            _nextId = maxId + 1;
        }
    }
}
