public static class Kodax
{
    public static string ROOTDIR { get; set; } = "./Feature";

    public static void CreateService(string serviceName, bool docs = true, bool validator = true)
    {
        if (!Directory.Exists(ROOTDIR))
        {
            Console.WriteLine("Error! This directory does not exist!");
            return;
        }
        Console.WriteLine($"Service {serviceName} was created!");
    }

    public static void CreateFeatureCopy(string featname)
    {

        if (!Directory.Exists(ROOTDIR))
        {
            Console.WriteLine("Error! This directory does not exist!");
            return;
        }

        Directory.CreateDirectory($"{ROOTDIR}/{featname}");

        TemplateManager.ApplyTemplate($"{ROOTDIR}/{featname}", new(){ {"FeatureName", featname }, { "Namespace", $"Feature.{featname}" } });
    }
    
    public static void AddOns(string featname, string type)
    {
        if (!File.Exists($"{ROOTDIR}/{featname}"))
        {
            Console.WriteLine("\nThis feature does not exist!\n");
            return;
        }
        if (type == "md")
            File.Create($"{ROOTDIR}/{featname}/{featname}Middleware.cs");
        else if (type == "val")
            File.Create($"{ROOTDIR}/{featname}/{featname}Validator.cs");
        else if (type == "doc")
            File.Create($"{ROOTDIR}/{featname}/{featname}Documentation.cs");
        else
            Console.WriteLine("\n Invalid add-on. Try 'add-on list' to see the options.\n");
    }

    // public static void NewConfig();
    // public static void NewException();
    // public static void NewHelper();

    public static void InitArch()
    {
        Directory.CreateDirectory(ROOTDIR);
        Directory.CreateDirectory("./Common");
        Directory.CreateDirectory("./Common/Shared");
        Directory.CreateDirectory("./Common/Shared/Exceptions");
        Directory.CreateDirectory("./Common/Shared/Helpers");
        Directory.CreateDirectory("./Common/Config");

        Console.WriteLine("Feature architecture was initiated.");
    }

    public static void RmFeature(string featname)
    {
        string path = $"{ROOTDIR}/{featname}";
        Directory.Delete(path, true);
        Console.WriteLine("Feature deleted.");
    }

    public static void RmKodax()
    {
        Directory.Delete(ROOTDIR, true);
        Directory.Delete("./Common", true);
        Console.WriteLine("Kodax changes were removed sucessfuly.");
    }
}
