using AssetTracking.Models;

List<Asset> assets = new List<Asset>();

assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2022, 8, 10), 1500, 15000, "Sweden"));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2024, 04, 1), 1200, 13000, "USA"));
assets.Add(new MobilePhone("Nokia", "XR20", new DateTime(2022, 9, 01), 900, 9500, "Sweden"));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 900, 9500, "Sweden"));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1100, 12000, "USA"));


while (true)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("DO YOU WANT TO ADD A NEW ASSET? (Y/N): ");
    Console.ResetColor();

    string answer = Console.ReadLine().Trim().ToLower();

    if (answer != "y")
        break;

    try
    {
        // BRAND VALIDATION
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

        // MODEL VALIDATION
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

        // DATE VALIDATION
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

        // OFFICE VALIDATION
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

        // TYPE VALIDATION
        string type;
        while (true)
        {
            Console.Write("Enter Type (Laptop/Phone): ");
            type = Console.ReadLine().Trim().ToLower();

            if (type == "laptop" || type == "phone")
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid type. Must be Laptop or Phone.");
            Console.ResetColor();
        }

        // CREATE OBJECT
        if (type == "laptop")
            assets.Add(new Computer(brand, model, purchaseDate, priceUSD, priceLocal, office));
        else
            assets.Add(new MobilePhone(brand, model, purchaseDate, priceUSD, priceLocal, office));
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unexpected error occurred. Please try again.");
        Console.ResetColor();
    }
}
assets = assets.OrderBy(a => a.PurchaseDate).ToList();

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("ASSET LIST\n");
Console.WriteLine("______________________________________________________________________________________");
Console.WriteLine("");
Console.WriteLine($"{"Type",-10} {"Brand",-10} {"Model",-15} {"Office",-10} {"Price USD",-12} {"Purchase Date",-15} {"Status",-10}");
Console.WriteLine("______________________________________________________________________________________");
Console.WriteLine("");

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

    Console.WriteLine($"{a.AssetType,-10} {a.Brand,-10} {a.Model,-15} {a.Office,-10} {a.PriceUSD,-12:C} {a.PurchaseDate, -15:yyyy-MM-dd} {status,-10}");
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
Console.WriteLine();


