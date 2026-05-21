using AssetTracking.Models;

List<Asset> assets = new List<Asset>();

assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2022, 8, 10), 1500, 15000, "Sweden"));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2024, 04, 1), 1200, 13000, "USA"));
assets.Add(new MobilePhone("Nokia", "XR20", new DateTime(2022, 9, 01), 900, 9500, "Sweden"));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 900, 9500, "Sweden"));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1100, 12000, "USA"));

assets = assets.OrderBy(a => a.PurchaseDate).ToList();

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("ASSET LIST\n");
Console.WriteLine("_______________________________________________________________");
Console.WriteLine("");
Console.WriteLine($"{"Type",-10} {"Brand",-10} {"Model",-15} {"Purchase Date",-15} {"Status",-25}");
Console.WriteLine("_______________________________________________________________");

foreach (var a in assets)
{
    int age = DateTime.Now.Year - a.PurchaseDate.Year;

    string status;

    if (age > 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        status = "RED";
    }
    else if (age >= 2)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        status = "YELLOW";
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        status = "GREEN";
    }

    Console.WriteLine($"{a.AssetType,-10} {a.Brand,-10} {a.Model,-15} {a.PurchaseDate, -15:yyyy-MM-dd} {status,-25}");
    Console.ResetColor();
    
}
Console.WriteLine();
Console.WriteLine("LEGEND");
Console.WriteLine("----------------------------------------------------------");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("RED    = Older than 3 years");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("YELLOW = Between 2 and 3 years");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("GREEN  = Less than 2 years");
Console.ResetColor();

