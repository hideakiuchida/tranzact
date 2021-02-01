using SearchFight.Domain.CQRS.Queries;
using SearchFight.Domain.Interfaces.Repositories;
using SearchFight.Domain.Interfaces.Services;
using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using SearchFight.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Application.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private ISearchEngineRepository searchEngineRepository;
        public SearchEngineService(ISearchEngineRepository searchEngineRepository)
        {
            this.searchEngineRepository = searchEngineRepository;
        }
        public async Task<FinalResultVM> SearchAsync(SearchEngineQuery searchEngineQuery)
        {
            
            if (searchEngineQuery == null || string.IsNullOrWhiteSpace(searchEngineQuery.Query))
                throw new Exception("The query value is invalid");
            searchEngineQuery.Query = searchEngineQuery.Query.Trim(new Char[] { '"', '/' });
            string[] words = searchEngineQuery.Query.Split(' ');
            var results = new List<SearchEngineResult>();
            foreach (var programmingLanguageQuery in words)
            {
                var searchEngineResults = await searchEngineRepository.GetSearchEngineResultByProgrammingLanguageAsync(programmingLanguageQuery);
                searchEngineResults.ForEach(x => ValidatingDuplicatingSearchEnginesResults(results, x));
            }
            
            var finalResultVM = new FinalResultVM(results);
            return finalResultVM;
        }

        private void ValidatingDuplicatingSearchEnginesResults(List<SearchEngineResult> finalResults, SearchEngineResult result)
        {
            var existingResult = finalResults.Where(x => x.Id == result.Id).FirstOrDefault();
            if (existingResult != null)
                existingResult.ProgrammingLanguages.AddRange(result.ProgrammingLanguages);
            else 
                finalResults.Add(result);
        }
    }
}
