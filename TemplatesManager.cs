public class TemplateManager
{
    private static string[] fullfeature = Directory.GetFiles("templates/full-feature");

    public static List<string> ApplyTemplate(Dictionary<string, string> values)
    {
        List<string> templates = [];

        for (int i = 0; i < fullfeature.Length; i++)
        {
            var content = File.ReadAllText(fullfeature[i]);
            foreach (var kv in values)
            {
                content = content.Replace($"{{{{{kv.Key}}}}}", kv.Value);
            }

            templates.Add(content);
        }

        return templates;
    }
}
