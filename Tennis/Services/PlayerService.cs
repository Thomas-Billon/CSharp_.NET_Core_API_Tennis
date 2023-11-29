using Tennis.Models;
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
    }
}
