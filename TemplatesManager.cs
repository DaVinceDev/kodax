public class TemplateManager
{
    private static string[] fullfeature = Directory.GetFiles(
    Path.Combine([
    Environment.GetEnvironmentVariable("HOME") ?? throw new Exception("HOME env variable is not set."),
    ".config",
    "kodax",
    "templates",
    "full-feature"
    ]));

    public static void ApplyTemplate(string featpath, Dictionary<string, string> values)
    {
        for (int i = 0; i < fullfeature.Length; i++)
        {
            var content = File.ReadAllText(fullfeature[i]);
            foreach (var kv in values)
            {
                content = content.Replace($"{{{{{kv.Key}}}}}", kv.Value).Replace("//","");
            }
            File.WriteAllText($"{featpath}/{Path.GetFileName(fullfeature[i])}", content);
        }
    }
}
