using SearchFight.Domain.Interfaces.Repositories;
using SearchFight.Domain.Interfaces.UnitOfWork;
using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using SearchEngine.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SearchEngine.Infrastructure.Repositories
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        private IUnitOfWork<SearchEngineResult> unitOfWork;
        private List<SearchEngineResult> searchEngineResults { get; set; }

        public SearchEngineRepository(IUnitOfWork<SearchEngineResult> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            searchEngineResults = SeedData.SeedData.GetSearchEngineResults();
        }
        public async Task<List<SearchEngineResult>> GetSearchEngineResultByProgrammingLanguageAsync(string programmingLanguage)
        {
            var results = new List<SearchEngineResult>();
            foreach (var result in searchEngineResults)
            {
                var searchEngineResult = new SearchEngineResult();
                var matchedlanguages =
                    result.ProgrammingLanguages.Where(x => x.Keywords.Contains(programmingLanguage.ToLower()));
                searchEngineResult.Id = result.Id;
                searchEngineResult.ProgrammingLanguages = matchedlanguages.ToList();
                searchEngineResult.SearchEngine = result.SearchEngine;
                results.Add(searchEngineResult);
            }
            return await Task.FromResult(results);
        }
    }
}
