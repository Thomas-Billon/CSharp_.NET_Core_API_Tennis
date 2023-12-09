using Microsoft.AspNetCore.Mvc;
using Moq;
using Tennis.Controllers;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;
using Xunit;

namespace TestTennis.Controllers
{
    public class GlobalStatControllerTest
    {
        private readonly Mock<IPlayerService> _playerService;

        public GlobalStatControllerTest()
        {
            _playerService = new Mock<IPlayerService>();
        }

        [Fact]
        public void GetPlayerGlobalStat_ReturnsGlobalStat()
        {
            // Arrange
            GlobalStat expectedGlobalStat = DataSource.GenerateFakeGlobalStat();

            _playerService
                .Setup(x => x.GetPlayerGlobalStat())
                .Returns(expectedGlobalStat);

            GlobalStatController globalStatController = new GlobalStatController(_playerService.Object);

            // Act
            var actionResult = globalStatController.GetPlayerGlobalStat();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualGlobalStat = result.Value as GlobalStat;
            Assert.NotNull(actualGlobalStat);
            Assert.True(expectedGlobalStat.BestRatioCountry.Code == actualGlobalStat.BestRatioCountry.Code);
            Assert.True(expectedGlobalStat.AverageBMI == actualGlobalStat.AverageBMI);
            Assert.True(expectedGlobalStat.MedianHeight == actualGlobalStat.MedianHeight);
        }
    }
}