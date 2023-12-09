using Tennis.Models;
using Tennis.Models.Views;

namespace Tennis.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerList();
        public IEnumerable<Player> GetPlayerListByRank(string? order);
        public IEnumerable<Player> GetPlayerListByRankAsc();
        public IEnumerable<Player> GetPlayerListByRankDesc();
        public Player GetPlayerById(int id);
        public GlobalStat GetPlayerGlobalStat();
    }
}
