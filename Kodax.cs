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

        Directory.CreateDirectory($"{ROOTDIR}/{serviceName}");
        File.Create($"{ROOTDIR}/{serviceName}/{serviceName}Service.cs");
        File.Create($"{ROOTDIR}/{serviceName}/I{serviceName}Service.cs");
        if (validator)
            File.Create($"{ROOTDIR}/{serviceName}/{serviceName}Validator.cs");
        if (docs)
            File.Create($"{ROOTDIR}/{serviceName}/{serviceName}Documentation.md");

        Console.WriteLine($"Service {serviceName} was created!");
    }

    public static void CreateFeature(string featname, bool fullFeature, bool docs, bool validator)
    {
        if (!Directory.Exists(ROOTDIR))
        {
            Console.WriteLine("Error! This directory does not exist!");
            return;
        }

        if (!fullFeature)
        {
            Directory.CreateDirectory($"{ROOTDIR}/{featname}");

            var output = TemplateManager.ApplyTemplate(
                new() { { "FeatureName", featname }, { "Namespace", $"Feature.{featname}" } }
            );

            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}Controller.cs", output[0]);
            if (docs)
                File.WriteAllTextAsync(
                    $"{ROOTDIR}/{featname}/{featname}Documentation.cs",
                    output[1]
                );
            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}DTO.cs", output[2]);
            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/I{featname}Repository.cs", output[3]);
            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}.cs", output[4]);
            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}Repository.cs", output[5]);
            File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}Service.cs", output[6]);
            if (validator)
                File.WriteAllTextAsync($"{ROOTDIR}/{featname}/{featname}Validator.cs", output[7]);
        }
        else
        {
            Directory.CreateDirectory($"{ROOTDIR}/{featname}");
            File.Create($"{ROOTDIR}/{featname}/{featname}.cs");
            File.Create($"{ROOTDIR}/{featname}/{featname}Controller.cs");
            File.Create($"{ROOTDIR}/{featname}/{featname}DTO.cs");
            if (docs)
                File.Create($"{ROOTDIR}/{featname}/{featname}Documentation.md");
        }
        Console.WriteLine($"Feature {featname} was created!");
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
        Directory.Delete(path);
        Console.WriteLine("Feature deleted.");
    }

    public static void RmKodax()
    {
        Directory.Delete(ROOTDIR, true);
        Directory.Delete("./Common", true);
        Console.WriteLine("Kodax changes were removed sucessfuly.");
    }
}
