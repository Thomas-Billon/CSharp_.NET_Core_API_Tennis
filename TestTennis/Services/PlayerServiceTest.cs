using Moq;
using Tennis.Models;
using Tennis.Repositories;
using Tennis.Services;
using Xunit;

namespace TestTennis.Services
{
    public class PlayerServiceTest
    {
        private readonly Mock<IPlayerRepository> _playerRepository;

        public PlayerServiceTest()
        {
            _playerRepository = new Mock<IPlayerRepository>();
        }

        [Fact]
        public void CalculateBestRatioCountry_ReturnsPlayerCountry()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();
            PlayerCountry expectedPlayerCountry = new PlayerCountry
            {
                Picture = "https://en.wikipedia.org/wiki/England#/media/File:Flag_of_England.svg",
                Code = "GBR"
            };

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var result = playerService.CalculateBestRatioCountry(expectedPlayerList);

            // Assert
            Assert.NotNull(result);
            Assert.True(expectedPlayerCountry.Code == result.Code);
        }

        [Fact]
        public void CalculateAverageBMI_ReturnsFloat()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();
            float expected = 24.151660927841f;

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var result = playerService.CalculateAverageBMI(expectedPlayerList);

            // Assert
            Assert.True(expected == result);
        }

        [Fact]
        public void CalculateMedianHeight_ReturnsFloat()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();
            float expected = 170;

            PlayerService playerService = new PlayerService(_playerRepository.Object);

            // Act
            var result = playerService.CalculateMedianHeight(expectedPlayerList);

            // Assert
            Assert.True(expected == result);
        }
    }
}