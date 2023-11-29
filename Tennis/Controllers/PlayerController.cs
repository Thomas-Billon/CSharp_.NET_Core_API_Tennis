using Microsoft.AspNetCore.Mvc;
using Tennis.Models;
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
    }
}
