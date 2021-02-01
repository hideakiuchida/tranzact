using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Domain.ViewModels
{
    public class FinalResultVM
    {
        public List<SearchEngineResultVM> Results { get; set; }
        public string TotalWinner { get; set; }
        public FinalResultVM(List<SearchEngineResult> searchEngineResults)
        {
            Results = new List<SearchEngineResultVM>();
            foreach (var item in searchEngineResults)
            {
                var searchEngineResultVM = new SearchEngineResultVM(item);
                Results.Add(searchEngineResultVM);
            }
            TotalWinner = Results
                .Where(x => x.ProgrammingLanguageWinner.PopularityAmount == Results.Max(y => y.ProgrammingLanguageWinner.PopularityAmount))
                .FirstOrDefault().ProgrammingLanguageWinner.Name;
        }
    }
}
