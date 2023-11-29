using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Repositories;

namespace Tennis.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetPlayerList()
        {
            return _playerRepository.List();
        }

        public IEnumerable<Player> GetPlayerListByRank()
        {
            return new List<Player>();
        }

        public Player GetPlayerById(int id)
        {
            return new Player();
        }

        public GlobalStat GetPlayerGlobalStat()
        {
            return new GlobalStat();
        }

        public PlayerCountry CalculateBestRatioCountry(List<Player> playerList)
        {
            return new PlayerCountry();
        }

        public float CalculateAverageBMI(List<Player> playerList)
        {
            return 0;
        }

        public float CalculateMedianHeight(List<Player> playerList)
        {
            return 0;
        }
    }
}
