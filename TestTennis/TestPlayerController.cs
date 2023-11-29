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
            var playerResult = playerController.GetPlayerList();

            // Assert
            Assert.NotNull(playerResult);
            Assert.NotEmpty(playerResult);
            Assert.Equal(playerList.Count, playerResult.Count());
            Assert.Equal(playerList, playerResult);
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
            var playerResult = playerController.GetPlayerListByRank();

            // Assert
            Assert.NotNull(playerResult);
            Assert.NotEmpty(playerResult);
            Assert.Equal(playerList.Count, playerResult.Count());
            Assert.Equal(playerList, playerResult);

            for (int i = 0; i < playerList.Count - 1; i++)
            {
                Assert.True(playerList[i].Data.Rank < playerList[i + 1].Data.Rank);
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
            var playerResult = playerController.GetPlayerById(10);

            // Assert
            Assert.NotNull(playerResult);
            Assert.Equal(playerList[3], playerResult);
            Assert.True(playerList[3].Id == playerResult.Id);
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
            var globalStatResult = playerController.GetPlayerGlobalStat();

            // Assert
            Assert.NotNull(globalStatResult);
            Assert.True(globalStat.BestRatioCountry.Code == globalStatResult.BestRatioCountry.Code);
            Assert.True(globalStat.AverageBMI == globalStatResult.AverageBMI);
            Assert.True(globalStat.MedianHeight == globalStatResult.MedianHeight);
        }
    }
}