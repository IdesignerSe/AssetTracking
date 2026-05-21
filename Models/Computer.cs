namespace AssetTracking.Models
{
    public class Computer : Asset
    {
        public Computer(
            string brand,
            string model,
            DateTime purchaseDate,
            decimal priceUSD,
            decimal priceLocal,
            string office
        )
        : base(brand, model, purchaseDate, priceUSD, priceLocal, office)
        {
        }

        public override string GetAssetType()
        {
            return "Computer";
        }
    }
}
