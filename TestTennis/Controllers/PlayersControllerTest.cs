using Microsoft.AspNetCore.Mvc;
using Moq;
using Tennis.Controllers;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;
using Xunit;

namespace TestTennis.Controllers
{
    public class PlayersControllerTest
    {
        private readonly Mock<IPlayerService> _playerService;

        public PlayersControllerTest()
        {
            _playerService = new Mock<IPlayerService>();
        }

        [Fact]
        public void GetPlayerListNull_ReturnsPlayerListUnsorted()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerList())
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList(null, null);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count, actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);
        }

        [Fact]
        public void GetPlayerListEmpty_ReturnsPlayerListUnsorted()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerList())
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList("", "");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count, actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);
        }

        [Fact]
        public void GetPlayerListSortWrong_ReturnsPlayerListUnsorted()
        {
            // Arrange
            List<Player> expectedPlayerList = DataSource.GenerateFakePlayerList();

            _playerService
                .Setup(x => x.GetPlayerList())
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList("abc", "xyz");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count, actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);
        }

        [Fact]
        public void GetPlayerListSortRankOrderAsc_ReturnsPlayerListSortedAsc()
        {
            // Arrange
            IEnumerable<Player> expectedPlayerList = DataSource.GenerateFakePlayerList()
                .OrderBy(p => p.Data.Rank);

            _playerService
                .Setup(x => x.GetPlayerListByRank("asc"))
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList("rank", "asc");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count(), actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);

            int previousRank = int.MinValue;
            foreach (Player player in actualPlayerList)
            {
                Assert.True(previousRank <= player.Data.Rank);
                previousRank = player.Data.Rank;
            }
        }

        [Fact]
        public void GetPlayerListSortRankOrderDesc_ReturnsPlayerListSortedDesc()
        {
            // Arrange
            IEnumerable<Player> expectedPlayerList = DataSource.GenerateFakePlayerList()
                .OrderByDescending(p => p.Data.Rank);

            _playerService
                .Setup(x => x.GetPlayerListByRank("desc"))
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList("rank", "desc");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count(), actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);

            int previousRank = int.MaxValue;
            foreach (Player player in actualPlayerList)
            {
                Assert.True(previousRank >= player.Data.Rank);
                previousRank = player.Data.Rank;
            }
        }

        [Fact]
        public void GetPlayerListSortRankOrderWrong_ReturnsPlayerListSortedAsc()
        {
            // Arrange
            IEnumerable<Player> expectedPlayerList = DataSource.GenerateFakePlayerList()
                .OrderBy(p => p.Data.Rank);

            _playerService
                .Setup(x => x.GetPlayerListByRank("xyz"))
                .Returns(expectedPlayerList);

            PlayersController playersController = new PlayersController(_playerService.Object);

            // Act
            var actionResult = playersController.GetPlayerList("rank", "xyz");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var actualPlayerList = result.Value as IEnumerable<Player>;
            Assert.NotNull(actualPlayerList);
            Assert.NotEmpty(actualPlayerList);
            Assert.Equal(expectedPlayerList.Count(), actualPlayerList.Count());
            Assert.Equal(expectedPlayerList, actualPlayerList);

            int previousRank = int.MinValue;
            foreach (Player player in actualPlayerList)
            {
                Assert.True(previousRank <= player.Data.Rank);
                previousRank = player.Data.Rank;
            }
        }
    }
}