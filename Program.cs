using AssetTracking.Models;

List<Asset> assets = new List<Asset>();

assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 3, 15), 1500, 15000, "Sweden"));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2023, 10, 1), 1200, 13000, "USA"));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 900, 9500, "Sweden"));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1100, 12000, "USA"));

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("ASSET LIST\n");
Console.WriteLine("______________________________________________________");
Console.WriteLine($"{"Type",-10} {"Brand",-10} {"Model",-15} {"Purchase Date",-12}");
Console.WriteLine("______________________________________________________");
foreach (var a in assets)
{
    Console.WriteLine($"{a.AssetType,-10} {a.Brand,-10} {a.Model,-15} {a.PurchaseDate:yyyy-MM-dd}");
}
