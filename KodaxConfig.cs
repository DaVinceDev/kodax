public static class KodaxConfig
{
    public static void Setup()
    {
        string home = Environment.GetEnvironmentVariable("HOME") ?? throw new Exception("HOME environment var not set.");

        string configDir = Path.Combine(home, ".config", "kodax");
        if (!Directory.Exists(configDir))
        {
            string templatesDir = Path.Combine(configDir, "templates/full-feature");

            Directory.CreateDirectory(configDir);
            Directory.CreateDirectory(templatesDir);

            var fullFeatureTemp = Directory.GetFiles("templates/full-feature");

            foreach (var i in fullFeatureTemp)
            {
                File.Copy(i, Path.Combine(configDir, i));
            }

        }

        else Console.WriteLine("Configuration path already set.");
    }
}
