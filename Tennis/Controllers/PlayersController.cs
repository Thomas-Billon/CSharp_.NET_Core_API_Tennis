using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;

namespace Tennis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Player>))]
        public ActionResult<IEnumerable<Player>> GetPlayerList(string? sort, string? order)
        {
            try
            {
                IEnumerable<Player> playerList;

                switch (sort)
                {
                    case "rank":
                        playerList = _playerService.GetPlayerListByRank(order);
                        break;

                    default:
                        playerList = _playerService.GetPlayerList();
                        break;
                }

                return Ok(playerList);
            }
            catch (JsonException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
