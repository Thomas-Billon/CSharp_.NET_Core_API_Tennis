using Microsoft.AspNetCore.Mvc;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;

namespace Tennis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> GetPlayerList()
        {
            return _playerService.GetPlayerList();
        }

        // TODO: Créer un endpoint qui retourne les joueurs. La liste doit être triée du meilleur au moins bon.
        // => [HttpGet] Returns a IEnumerable<Player> ordered by Data.Rank (& then by Data.Points?)
        [HttpGet]
        public IEnumerable<Player> GetPlayerListByRank()
        {
            return _playerService.GetPlayerListByRank();
        }

        // TODO: Créer un endpoint qui permet de retourner les informations d’un joueur grâce à son ID.
        // => [HttpGet] Returns a Player based on Id
        [HttpGet]
        public Player GetPlayerById(int id)
        {
            return _playerService.GetPlayerById(id);
        }

        // TODO: Créer un endpoint qui retourne les statistiques suivantes :
        // - Pays qui a le plus grand ratio de parties gagnées
        // - IMC moyen de tous les joueurs
        // - La médiane de la taille des joueurs
        // => [HttpGet] Returns a custom view model with all stuff calculated above
        [HttpGet]
        public GlobalStat GetPlayerGlobalStat()
        {
            return _playerService.GetPlayerGlobalStat();
        }
    }
}
