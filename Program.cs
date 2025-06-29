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

        if (command == "setup")
        {
            KodaxConfig.Setup();
        }
        else if (command == "init")
        {
            Kodax.InitArch();
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
                    // Kodax.CreateFeature(featname, isSimple, withDocs, withValidator);
                    Kodax.CreateFeatureCopy(featname);
                    
                }
                else if (commandType == "sv" || commandType == "simple")
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    var featname = textInfo.ToTitleCase(args[2]);
                    bool withDocs = args.Contains("-nd") || args.Contains("--no-docs");
                    bool withValidator = args.Contains("-nv") || args.Contains("--no-val");
                    Kodax.CreateService(featname, withDocs, withValidator);
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
        else if (command == "deinit")
        {
            char option = 'N';
            Console.Write("Are you sure you want to remove kodax project changes?[y/N]:");
            option = (char)Console.Read();

            if (option == 'y' || option == 'Y') Kodax.RmKodax();
        }
        else if (command == "rm"){
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var featname = textInfo.ToTitleCase(args[1]);
            Kodax.RmFeature(featname);
        }
        else
        {
            Console.WriteLine("\nUnkown command.");
            return;
        }
        return;
    }
}
