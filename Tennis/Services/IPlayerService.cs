using Tennis.Models;

namespace Tennis.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerList();
    }
}
