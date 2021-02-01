using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchEngine.Application.Services;
using SearchEngine.Infrastructure.Repositories;
using SearchEngine.Infrastructure.UnitOfWork;
using SearchFight.Domain.CQRS.Queries;
using SearchFight.Domain.Interfaces.Repositories;
using SearchFight.Domain.Interfaces.Services;
using SearchFight.Domain.Interfaces.UnitOfWork;
using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using System;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static Task Main(string[] args)
        {
            Console.WriteLine("Search the program languages!");
            using IHost host = CreateHostBuilder(args).Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var service = provider.GetRequiredService<ISearchEngineService>();
            var queryText = Console.ReadLine();
            var query = new SearchEngineQuery { Query = queryText};
            var result = service.SearchAsync(query).Result;

            foreach (var item in result.Results)
            {
                Console.WriteLine($"SearchEngine: {item.SearchEngine}");
                Console.WriteLine($"Programming Language Winner by Search Engine - Name: {item.ProgrammingLanguageWinner.Name}");
                Console.WriteLine($"Programming Language Winner by Search Engine - PopularityAmount: {item.ProgrammingLanguageWinner.PopularityAmount}");
            }
            Console.WriteLine($"TotalWinner: {result.TotalWinner}");

            return host.RunAsync();   
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ISearchEngineService, SearchEngineService>()
                            .AddTransient<ISearchEngineRepository, SearchEngineRepository>()
                            .AddTransient<IUnitOfWork<SearchEngineResult>, UnitOfWork<SearchEngineResult>>());
    }
}
