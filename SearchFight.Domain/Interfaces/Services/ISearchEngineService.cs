using SearchFight.Domain.CQRS.Queries;
using SearchFight.Domain.ViewModels;
using System.Threading.Tasks;

namespace SearchFight.Domain.Interfaces.Services
{
    public interface ISearchEngineService
    {
        Task<FinalResultVM> SearchAsync(SearchEngineQuery searchEngineQuery);
    }
}
