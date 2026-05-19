namespace AssetTracking.Models
{
    public class Asset
    {
        public Asset()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
    
}
