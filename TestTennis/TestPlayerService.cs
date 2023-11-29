using Moq;
using Tennis.Models;
using Tennis.Repositories;
using Tennis.Services;

namespace TestTennis
{
    public class TestPlayerService
    {
        private readonly Mock<IPlayerRepository> _playerRepository;

        public TestPlayerService()
        {
            _playerRepository = new Mock<IPlayerRepository>();
        }

        [Fact]
        public void CalculateBestRatioCountry_ReturnsPlayerCountry()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList();
            PlayerCountry playerCountryExpected = new PlayerCountry
            {
                Picture = "https://en.wikipedia.org/wiki/England#/media/File:Flag_of_England.svg",
                Code = "GBR"
            };

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var playerCountryResult = playerService.CalculateBestRatioCountry(playerList);

            // Assert
            Assert.NotNull(playerCountryResult);
            Assert.Equal(playerCountryExpected, playerCountryResult);
            Assert.True(playerCountryExpected.Code == playerCountryResult.Code);
        }

        [Fact]
        public void CalculateAverageBMI_ReturnsFloat()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList();
            float expected = 24.151660927841f;

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var result = playerService.CalculateAverageBMI(playerList);

            // Assert
            Assert.True(expected == result);
        }

        [Fact]
        public void CalculateMedianHeight_ReturnsFloat()
        {
            // Arrange
            List<Player> playerList = TestPlayerModel.GenerateFakePlayerList();
            float expected = 170;

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var result = playerService.CalculateMedianHeight(playerList);

            // Assert
            Assert.True(expected == result);
        }
    }
}