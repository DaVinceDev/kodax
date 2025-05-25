using System.Globalization;

public class Program
{
    const string ROOTDIR = "./Feature";

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("\nNo arguments where passed. Try a command.");
            return;
        }

        var command = args[0];

        if (command == "arch")
        {
            InitArch();
        }
        else if (command == "new")
        {
            try
            {
                var commandType = args[1];

                if (commandType == "list")
                {
                    Console.WriteLine("\nCreation Options:\n");
                    Console.WriteLine("ft | feature → Creates a new feature\n");
                    Console.WriteLine("sv | service → Creates a new service\n");
                    Console.WriteLine("\n\nFlags:\n");
                    Console.WriteLine("-nd | --no-docs → Not include documentation in creation\n");
                    Console.WriteLine("-nv | --no-val → Not include validator in creation\n");
                }
                else if (commandType == "ft" || commandType == "feature")
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    var featname = textInfo.ToTitleCase(args[2]);
                    bool isSimple = args.Contains("-s") || args.Contains("--simple");
                    bool withDocs = args.Contains("-nd") || args.Contains("--no-docs");
                    bool withValidator = args.Contains("-nv") || args.Contains("--no-val");
                    CreateFeature(featname, isSimple, withDocs, withValidator);
                }
                else if (commandType == "sv" || commandType == "simple")
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    var featname = textInfo.ToTitleCase(args[2]);
                    bool withDocs = args.Contains("-nd") || args.Contains("--no-docs");
                    bool withValidator = args.Contains("-nv") || args.Contains("--no-val");
                    CreateService(featname, withDocs, withValidator);
                }
                else
                {
                    Console.WriteLine(
                        "Unkown command. Try 'list' to list all possible creation options"
                    );
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No commands were passed. Try 'list'.");
            }
        }
        else if (command == "add-on")
        {
            try
            {
                var commandType = args[1];

                if (commandType == "list")
                {
                    Console.WriteLine("\nAdd-On Options:\n");
                    Console.WriteLine("md → Middleware\n");
                    Console.WriteLine("val → Validator\n");
                    Console.WriteLine("doc → Documentation\n");
                    Console.WriteLine(
                        "\nUsage:\n " + "kodax add-on <add-on-option> <feature-name>\n\n"
                    );
                }
                //TODO: WORK HERE
                else
                {
                    Console.WriteLine(
                        "Unkown command. Try 'list' to list all possible creation options"
                    );
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No commands were passed. Try 'list'.");
            }
        }
        else if (command == "help")
        {
            Console.WriteLine("\n\t\tThis is Kodax, your .NET project architect.");
            Console.WriteLine(
                "Heres a list of the current commands:\n"
                    + "arch → Ininiates a new 'feature architecture' to your current project \n"
                    + "new → Creates new features, services, configs, etc\n"
                    + "add-on → Adds stuff to your project \n"
                    + "help → Displays this message \n"
                    + "notes → Check Kodax notes \n"
            );
        }
        else if (command == "notes")
        {
            Console.WriteLine("\n\t\tKodax Notes.");
            Console.WriteLine(
                "Here's the current Kodax tool status:\n" + "\nHas 2 working commands."
            );
        }
        else
        {
            Console.WriteLine("\nUnkown command.");
            return;
        }
        return;
    }

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
}
