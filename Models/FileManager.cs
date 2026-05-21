using System.Text.Json;
using System.Text.Json.Serialization;
using AssetTracking.Models;

public static class FileManager
{
    private static string filePath = "assets.json";

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers =
            {
                ti =>
                {
                    if (ti.Type == typeof(Asset))
                    {
                        ti.PolymorphismOptions = new JsonPolymorphismOptions
                        {
                            TypeDiscriminatorPropertyName = "type",
                            IgnoreUnrecognizedTypeDiscriminators = true,
                            UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType
                        };

                        ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(Computer), "computer"));
                        ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(MobilePhone), "mobile"));
                        ti.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(typeof(Tablet), "tablet"));
                    }
                }
            }
        }
    };

    public static List<Asset> LoadAssets()
    {
        if (!File.Exists(filePath))
            return new List<Asset>();

        string json = File.ReadAllText(filePath);

        var assets = JsonSerializer.Deserialize<List<Asset>>(json, options) ?? new List<Asset>();

        // Update next ID so no duplicates occur
        if (assets.Count > 0)
        {
            int maxId = assets.Max(a => a.Id);
            Asset.UpdateNextId(maxId);
        }

        return assets;
    }

    public static void SaveAssets(List<Asset> assets)
    {
        string json = JsonSerializer.Serialize(assets, options);
        File.WriteAllText(filePath, json);
    }

    public static void ExportReport(List<Asset> assets)
    {
        string reportPath = "asset_report.txt";

        using StreamWriter sw = new StreamWriter(reportPath);

        sw.WriteLine("ASSET REPORT");
        sw.WriteLine("====================================");

        foreach (var a in assets)
        {
            sw.WriteLine($"ID: {a.Id}");
            sw.WriteLine($"Type: {a.GetAssetType()}");
            sw.WriteLine($"Brand: {a.Brand}");
            sw.WriteLine($"Model: {a.Model}");
            sw.WriteLine($"Office: {a.Office}");
            sw.WriteLine($"Price USD: {a.PriceUSD}");
            sw.WriteLine($"Purchase Date: {a.PurchaseDate:yyyy-MM-dd}");
            sw.WriteLine("------------------------------------");
        }
    }
}
