public class TemplateManager
{
    private static string[] fullfeature =
    [
        // /home/davincedev/Documents/csharp/kodax/templates/full-feature/ControllerTemplate.txt
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/ControllerTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/DocumentationTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/DTOTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/InterfaceTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/ModelTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/RepositoryTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/ServiceTemplate.txt",
        "/home/davincedev/Documents/csharp/kodax/templates/full-feature/ValidatorTemplate.txt",
    ];

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
