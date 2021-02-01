using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Domain.Interfaces.Repositories
{
    public interface ISearchEngineRepository
    {
        Task<List<SearchEngineResult>> GetSearchEngineResultByProgrammingLanguageAsync(string programmingLanguage);
    }
}
