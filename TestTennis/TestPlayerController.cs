using Moq;
using Tennis.Controllers;
using Tennis.Models;
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
    }
}