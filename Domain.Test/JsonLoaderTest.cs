using System;
using Xunit;

namespace Domain.Test
{
    public class JsonLoaderTest
    {
        [Fact]
        public void LoadCats()
        {
            var cats = CatJsonDataLoader.LoadCats();

            Assert.NotNull(cats);
            Assert.Equal(23, cats.Length);
        }
    }
}
