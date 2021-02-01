using SearchFight.Domain.Models.SearchEngineAggregate.ValueObjects;
using System.Collections.Generic;

namespace SearchFight.Domain.Models.SearchEngineAggregate.Entities
{
    public class SearchEngineResult
    {
        public int Id { get; set; }
        public string SearchEngine { get; set; }
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
