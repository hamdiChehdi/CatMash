namespace Domain.Test
{
    using Domain.Interfaces;
    using Domain.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class CatDataServiceTest
    {
        private readonly CatDbContext context;
        private ILogger<CatsDataService> logger;

        public CatDataServiceTest()
        {
            var options = new DbContextOptionsBuilder<CatDbContext>()
                .UseInMemoryDatabase(databaseName: "CatVotes")
                .Options;

            context = new CatDbContext(options);
            CatDbInitializer.Initialize(context);

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
            });

            logger = loggerFactory.CreateLogger<CatsDataService>();
        }

        [Fact]
        public async void getCats()
        {
            ICatsDataService catsDataService = new CatsDataService(context, logger);
            var cats = await catsDataService.GetCats();

            Assert.NotNull(cats);
            Assert.Equal(23, cats.Length);
        }

        [Fact]
        public async void AddVote()
        {
            ICatsDataService catsDataService = new CatsDataService(context, logger);
            var cat = await catsDataService.AddVote(1);

            Assert.NotNull(cat);
            Assert.Equal(1, cat.Votes);
        }
    }
}
