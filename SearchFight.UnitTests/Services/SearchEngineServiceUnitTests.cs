using Moq;
using NUnit.Framework;
using SearchEngine.Application.Services;
using SearchEngine.Infrastructure.SeedData;
using SearchFight.Domain.CQRS.Queries;
using SearchFight.Domain.Interfaces.Repositories;
using SearchFight.Domain.Interfaces.Services;
using SearchFight.Domain.Models.SearchEngineAggregate.Entities;
using System.Threading.Tasks;

namespace SearchFight.UnitTests.Services
{
    public class SearchEngineServiceUnitTests
    {
        private ISearchEngineService service;
        private Mock<ISearchEngineRepository> mockRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<ISearchEngineRepository>();
            service = new SearchEngineService(mockRepository.Object);
        }

        [Test]
        public async Task Given_ValidParametersJavaAndDotNet_When_SearchAsync_Then_ReturnDotnetAsTotalWinner()
        {
            //Arrange
            var searchEngineResults = SeedData.GetSearchEngineResults();
            mockRepository.Setup(x => x.GetSearchEngineResultByProgrammingLanguageAsync(It.IsAny<string>()))
                .ReturnsAsync(searchEngineResults);
            var query = new SearchEngineQuery { Query = "java .net" };
            //Act
            var result = await service.SearchAsync(query);
            //Assert
            Assert.AreEqual("DotNet", result.TotalWinner);
        }
    }
}