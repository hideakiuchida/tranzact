using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Domain.ViewModels
{
    public class SearchEngineResultVM
    {
        public string SearchEngine { get; set; }
        public ProgrammingLanguageVM ProgrammingLanguageWinner { get; set; }
        public List<ProgrammingLanguageVM> ProgrammingLanguages { get; set; }
        public SearchEngineResultVM(SearchEngineResult searchEngineResult)
        {
            SearchEngine = searchEngineResult.SearchEngine;
            ProgrammingLanguages = new List<ProgrammingLanguageVM>();
            foreach (var item in searchEngineResult.ProgrammingLanguages)
            {
                var programmingLanguageVM = new ProgrammingLanguageVM(item);
                ProgrammingLanguages.Add(programmingLanguageVM);
            }
            ProgrammingLanguageWinner = ProgrammingLanguages
                .Where(x => x.PopularityAmount == ProgrammingLanguages.Max(y => y.PopularityAmount))
                .FirstOrDefault();
        }
    }
}
