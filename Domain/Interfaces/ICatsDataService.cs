namespace Domain.Interfaces
{
    using Domain.Model;
    using System.Threading.Tasks;
    
    public interface ICatsDataService
    {
        Task<Cat[]> GetCats();

        Task<Cat> AddVote(int id);
    }
}