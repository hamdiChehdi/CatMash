namespace Domain.Services
{
    using System.Threading.Tasks;
    using System.Linq;
    using Domain.Model;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class CatsDataService : ICatsDataService
    {
        private readonly CatDbContext catDbContext;
        private readonly ILogger logger;

        public CatsDataService(CatDbContext catDbContext, ILogger<CatsDataService> logger)
        {
            this.catDbContext = catDbContext;
            this.logger = logger;
        }

        public async Task<Cat[]> GetCats()
        {
            return await catDbContext.Cats.OrderByDescending(c => c.Votes).ToArrayAsync();
        }

        public async Task<Cat> AddVote(int id)
        {
            Cat catToUpdate = null;
            
            try
            {
                catToUpdate = await catDbContext.Cats.FirstOrDefaultAsync(c => c.Id == id);
                catToUpdate.Votes++;
                await catDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to save changes for cate votes" + ex.Message);
            }

            return catToUpdate;
        }

    }
}
