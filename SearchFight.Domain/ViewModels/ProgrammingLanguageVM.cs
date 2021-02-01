using SearchFight.Domain.Models.SearchEngineAggregate.ValueObjects;

namespace SearchFight.Domain.ViewModels
{
    public class ProgrammingLanguageVM
    {
        public string Name { get; set; }
        public long PopularityAmount { get; set; }
        public ProgrammingLanguageVM(ProgrammingLanguage programmingLanguage)
        {
            Name = programmingLanguage.Name;
            PopularityAmount = programmingLanguage.PopularityAmount;
        }
    }
}
