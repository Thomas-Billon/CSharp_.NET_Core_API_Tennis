using Microsoft.AspNetCore.Mvc;
using Moq;
using Tennis.Controllers;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;
using Xunit;

namespace TestTennis.Controllers
{
    public class PlayerControllerTest
    {
        private readonly Mock<IPlayerService> _playerService;

        public PlayerControllerTest()
        {
            _playerService = new Mock<IPlayerService>();
        }

        [Fact]
        public void GetPlayerById_ReturnsPlayer()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerById(10))
                .Returns(expectedPlayerList[3]);

            PlayerController playerController = new PlayerController(_playerService.Object);

            // Act
            var actionResult = playerController.GetPlayerById(10);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as Player;
            Assert.NotNull(actualPlayerList);
            Assert.Equal(expectedPlayerList[3], actualPlayerList);
            Assert.True(expectedPlayerList[3].Id == actualPlayerList.Id);
        }
    }
}