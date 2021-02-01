using System.Collections.Generic;

namespace SearchFight.Domain.Models.SearchEngineAggregate.ValueObjects
{
    public class ProgrammingLanguage
    {
        public string Name { get; set; }
        public List<string> Keywords { get; set; }
        public long PopularityAmount { get; set; }
    }
}
