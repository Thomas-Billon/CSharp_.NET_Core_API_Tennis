using Tennis.Models;
using Tennis.Models.Views;

namespace Tennis.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerList();
        public IEnumerable<Player> GetPlayerListByRank();
        public Player GetPlayerById(int id);
        public GlobalStat GetPlayerGlobalStat();
    }
}
