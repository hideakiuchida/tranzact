using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using SearchFight.Domain.Models.SearchEngineAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Infrastructure.SeedData
{
    public static class SeedData
    {
        public static List<SearchEngineResult> GetSearchEngineResults()
        {
            var results = new List<SearchEngineResult>();
            results.Add(GetGoogleResult());
            results.Add(GetMsnSearchResult());
            return results;
        }

        private static SearchEngineResult GetGoogleResult()
        {
            return
                new SearchEngineResult
                {
                    Id = 1,
                    SearchEngine = "Google",
                    ProgrammingLanguages = GetProgrammingLanguagesForGoogle()
                };

        }
        private static SearchEngineResult GetMsnSearchResult()
        {
            return
                new SearchEngineResult
                {
                    Id = 2,
                    SearchEngine = "Msn Search",
                    ProgrammingLanguages = GetProgrammingLanguagesForMsnSearch()
                };

        }

        private static List<ProgrammingLanguage> GetProgrammingLanguagesForGoogle()
        {
            var progLanguagesForGoogle = new List<ProgrammingLanguage>();

            var javaForGoogle = new ProgrammingLanguage
            {
                Name = "Java",
                Keywords = GetJavaKeywords(),
                PopularityAmount = 966000000
            };
            progLanguagesForGoogle.Add(javaForGoogle);

            var netForGoogle = new ProgrammingLanguage
            {
                Name = "DotNet",
                Keywords = GetDotNetKeywords(),
                PopularityAmount = 4450000000
            };
            progLanguagesForGoogle.Add(netForGoogle);

            var javascriptForGoogle = new ProgrammingLanguage
            {
                Name = "Javascript",
                Keywords = GetJavascriptKeywords(),
                PopularityAmount = 786786878
            };
            progLanguagesForGoogle.Add(javascriptForGoogle);

            return progLanguagesForGoogle;
        }

        private static List<ProgrammingLanguage> GetProgrammingLanguagesForMsnSearch()
        {
            var progLanguagesForMsnSearch = new List<ProgrammingLanguage>();
            var javaForMsnSearch = new ProgrammingLanguage
            {
                Name = "Java",
                Keywords = GetJavaKeywords(),
                PopularityAmount = 94381485
            };
            progLanguagesForMsnSearch.Add(javaForMsnSearch);

            var netForMsnSearch = new ProgrammingLanguage
            {
                Name = "DotNet",
                Keywords = GetDotNetKeywords(),
                PopularityAmount = 12354420
            };
            progLanguagesForMsnSearch.Add(netForMsnSearch);

            var javascriptForMsnSearch = new ProgrammingLanguage
            {
                Name = "Javascript",
                Keywords = GetJavascriptKeywords(),
                PopularityAmount = 23425235
            };
            progLanguagesForMsnSearch.Add(javascriptForMsnSearch);

            return progLanguagesForMsnSearch;
        }

        private static List<string> GetJavaKeywords()
        {
            var keywords = new List<string>();
            keywords.Add("java");
            return keywords;
        }
        private static List<string> GetDotNetKeywords()
        {
            var keywords = new List<string>();
            keywords.Add("dotnet");
            keywords.Add(".net");
            keywords.Add("c#");
            return keywords;
        }

        private static List<string> GetJavascriptKeywords()
        {
            var keywords = new List<string>();
            keywords.Add("javascript");
            keywords.Add("script");
            return keywords;
        }
    }
}
