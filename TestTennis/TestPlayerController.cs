using Microsoft.AspNetCore.Mvc;
using Moq;
using Tennis.Controllers;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;

namespace TestTennis
{
    public class TestPlayerController
    {
        private readonly Mock<IPlayerService> _playerService;

        public TestPlayerController()
        {
            _playerService = new Mock<IPlayerService>();
        }

        [Fact]
        public void GetPlayerList_ReturnsPlayerList()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerList())
                .Returns(playerList);

            PlayerController playerController = new PlayerController(_playerService.Object);

            // Act
            var actionResult = playerController.GetPlayerList();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actual = result.Value as IEnumerable<Player>;
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(playerList.Count, actual.Count());
            Assert.Equal(playerList, actual);
        }

        [Fact]
        public void GetPlayerListByRank_ReturnsPlayerList()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList()
                .OrderBy(p => p.Data.Rank)
                .ToList();

            _playerService
                .Setup(x => x.GetPlayerListByRank())
                .Returns(playerList);

            PlayerController playerController = new PlayerController(_playerService.Object);

            // Act
            var actionResult = playerController.GetPlayerListByRank();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actual = result.Value as IEnumerable<Player>;
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(playerList.Count, actual.Count());
            Assert.Equal(playerList, actual);

            List<Player> actualList = actual.ToList();
            for (int i = 0; i < actualList.Count - 1; i++)
            {
                Assert.True(actualList[i].Data.Rank < actualList[i + 1].Data.Rank);
            }
        }

        [Fact]
        public void GetPlayerById_ReturnsPlayer()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerById(10))
                .Returns(playerList[3]);

            PlayerController playerController = new PlayerController(_playerService.Object);

            // Act
            var actionResult = playerController.GetPlayerById(10);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actual = result.Value as Player;
            Assert.NotNull(actual);
            Assert.Equal(playerList[3], actual);
            Assert.True(playerList[3].Id == actual.Id);
        }

        [Fact]
        public void GetPlayerGlobalStat_ReturnsGlobalStat()
        {
            // Arrange
            GlobalStat globalStat = TestPlayerModel.GenerateFakeGlobalStat();

            _playerService
                .Setup(x => x.GetPlayerGlobalStat())
                .Returns(globalStat);

            PlayerController playerController = new PlayerController(_playerService.Object);

            // Act
            var actionResult = playerController.GetPlayerGlobalStat();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actual = result.Value as GlobalStat;
            Assert.NotNull(actual);
            Assert.True(globalStat.BestRatioCountry.Code == actual.BestRatioCountry.Code);
            Assert.True(globalStat.AverageBMI == actual.AverageBMI);
            Assert.True(globalStat.MedianHeight == actual.MedianHeight);
        }
    }
}