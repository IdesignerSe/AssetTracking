namespace AssetTracking.Models
{
    public class MobilePhone : Asset
    {
        public MobilePhone(string brand, string model, DateTime purchaseDate,
                           decimal priceUSD, decimal priceLocal, string office)
            : base(brand, model, purchaseDate, priceUSD, priceLocal, office, "Phone")
        {
        }
    }
}
