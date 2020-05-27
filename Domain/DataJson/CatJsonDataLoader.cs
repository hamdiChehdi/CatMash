namespace Domain
{
    using Domain.Model;
    using System.IO;
    using System.Reflection;
    using System.Text.Json;

    public class CatJsonDataLoader
    {
        public static Cat[] LoadCats()
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var jsonString = File.ReadAllText($@"{directory}\DataJson\cats.json");

            var cats = JsonSerializer.Deserialize<Cat[]>(jsonString);

            return cats;
        }
    }
}
