namespace Domain
{
    using System.Linq;

    public static class CatDbInitializer
    {
        public static void Initialize(CatDbContext context)
        {
            // Look for any Cats
            if (context.Cats.Any())
            {
                return;   // DB has been seeded
            }

            var cats = CatJsonDataLoader.LoadCats();

            context.Cats.AddRange(cats);

            context.SaveChanges();
        }


    }
}
