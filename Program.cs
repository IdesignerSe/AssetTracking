using AssetTracking.Models;
using System.Text.Json;


List<Asset> assets = FileManager.LoadAssets();
Console.WriteLine($"Loaded {assets.Count} assets from file.");
Thread.Sleep(1000);

if (assets.Count == 0)
{
    assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2022, 8, 10), 1500, 15000, "Sweden"));
    assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2024, 04, 1), 1200, 13000, "USA"));
    assets.Add(new MobilePhone("Nokia", "XR20", new DateTime(2022, 9, 01), 900, 9500, "Sweden"));
    assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 900, 9500, "Sweden"));
    assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1100, 12000, "USA"));

    FileManager.SaveAssets(assets);

    Console.WriteLine("No assets found. Adding sample data...");
    Thread.Sleep(1000);
}

// =============================
// MAIN MENU LOOP
// =============================
while (true)
{
    Console.Clear();
    Console.WriteLine("=============================");
    Console.WriteLine("COMPANY ASSET TRACKING SYSTEM");
    Console.WriteLine("=============================\n");

    Console.WriteLine("1. Add Asset");
    Console.WriteLine("2. View Assets");
    Console.WriteLine("3. Search Asset");
    Console.WriteLine("4. Remove Asset");
    Console.WriteLine("5. Exit\n");

    Console.Write("Select option: ");
    string choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "1":
            AddAsset(assets);
            break;

        case "2":
            ViewAssets(assets);
            break;

        case "3":
            SearchAssets(assets);
            break;

        case "4":
            RemoveAsset(assets);
            break;

        case "5":
            Console.WriteLine("Exiting program...");
            return;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option.");
            Console.ResetColor();
            break;
    }

    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
}



// =============================
// METHODS
// =============================

static void AddAsset(List<Asset> assets)
{
    try
    {
        // TYPE
        string type;
        while (true)
        {
            Console.Write("Enter Type (Computer/Mobile/Tablet): ");
            type = Console.ReadLine().Trim().ToLower();

            if (type == "computer" || type == "mobile" || type == "tablet")
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid type. Must be Computer, Mobile or Tablet.");
            Console.ResetColor();
        }

        // BRAND
        string brand;
        while (true)
        {
            Console.Write("Enter Brand: ");
            brand = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(brand))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Brand cannot be empty.");
            Console.ResetColor();
        }

        // MODEL
        string model;
        while (true)
        {
            Console.Write("Enter Model: ");
            model = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(model))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Model cannot be empty.");
            Console.ResetColor();
        }

        // PURCHASE DATE
        DateTime purchaseDate;
        while (true)
        {
            Console.Write("Enter Purchase Date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out purchaseDate))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid date. Try again.");
            Console.ResetColor();
        }

        // PRICE USD
        decimal priceUSD;
        while (true)
        {
            Console.Write("Enter Price USD: ");
            if (decimal.TryParse(Console.ReadLine(), out priceUSD))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price. Try again.");
            Console.ResetColor();
        }

        // PRICE LOCAL
        decimal priceLocal;
        while (true)
        {
            Console.Write("Enter Price Local: ");
            if (decimal.TryParse(Console.ReadLine(), out priceLocal))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price. Try again.");
            Console.ResetColor();
        }

        // OFFICE
        string office;
        while (true)
        {
            Console.Write("Enter Office (Sweden/USA/Turkey): ");
            office = Console.ReadLine().Trim();

            if (office.Equals("Sweden", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("Turkey", StringComparison.OrdinalIgnoreCase))
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid office. Allowed: Sweden, USA, Turkey.");
            Console.ResetColor();
        }

        Asset asset;

        if (type == "computer")
            asset = new Computer(brand, model, purchaseDate, priceUSD, priceLocal, office);
        else if (type == "mobile")
            asset = new MobilePhone(brand, model, purchaseDate, priceUSD, priceLocal, office);
        else
            asset = new Tablet(brand, model, purchaseDate, priceUSD, priceLocal, office);

        assets.Add(asset);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nAsset added successfully with ID: {asset.Id}");
        Console.ResetColor();
        FileManager.SaveAssets(assets);
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unexpected error while adding asset.");
        Console.ResetColor();
    }
}



static void ViewAssets(List<Asset> assets)
{
    Console.Clear();
    Console.WriteLine("ASSET LIST\n");
    Console.WriteLine("_____________________________________________________________________________________________");
    Console.WriteLine($"{"ID",-5} {"Type",-12} {"Brand",-10} {"Model",-15} {"Office",-10} {"Price USD",-12} {"Purchase Date",-15} {"Status",-10}");
    Console.WriteLine("_____________________________________________________________________________________________");

    var sorted = assets.OrderBy(a => a.PurchaseDate).ToList();

    foreach (var a in sorted)
    {
        int age = a.GetAge();
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

        Console.WriteLine($"{a.Id,-5} {a.GetAssetType(),-12} {a.Brand,-10} {a.Model,-15} {a.Office,-10} {a.PriceUSD,-12:C} {a.PurchaseDate,-15:yyyy-MM-dd} {status,-10}");
        Console.ResetColor();
    }
}



static void SearchAssets(List<Asset> assets)
{
    Console.Write("Enter search term (Brand/Model/Office/Type): ");
    string term = Console.ReadLine().Trim().ToLower();

    var results = assets.Where(a =>
        a.Brand.ToLower().Contains(term) ||
        a.Model.ToLower().Contains(term) ||
        a.Office.ToLower().Contains(term) ||
        a.GetAssetType().ToLower().Contains(term)
    ).ToList();

    if (results.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No matching assets found.");
        Console.ResetColor();
        return;
    }

    Console.WriteLine("\nSearch Results:");
    Console.WriteLine("_____________________________________________________________________________________________");
    Console.WriteLine($"{"ID",-5} {"Type",-12} {"Brand",-10} {"Model",-15} {"Office",-10} {"Price USD",-12} {"Purchase Date",-15}");
    Console.WriteLine("_____________________________________________________________________________________________");

    foreach (var a in results)
    {
        Console.WriteLine($"{a.Id,-5} {a.GetAssetType(),-12} {a.Brand,-10} {a.Model,-15} {a.Office,-10} {a.PriceUSD,-12:C} {a.PurchaseDate,-15:yyyy-MM-dd}");
    }
}



static void RemoveAsset(List<Asset> assets)
{
    Console.Write("Enter Asset ID to remove: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID.");
        Console.ResetColor();
        return;
    }

    var asset = assets.FirstOrDefault(a => a.Id == id);

    if (asset == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Asset not found.");
        Console.ResetColor();
        return;
    }

    assets.Remove(asset);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Asset removed successfully.");
    Console.ResetColor();
    FileManager.SaveAssets(assets);
}
