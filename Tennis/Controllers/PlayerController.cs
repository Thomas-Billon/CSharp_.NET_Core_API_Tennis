using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using System.Text.Json;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;

namespace Tennis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Player>))]
        public ActionResult<IEnumerable<Player>> GetPlayerList()
        {
            try
            {
                IEnumerable<Player> playerList = _playerService.GetPlayerList();

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

        [HttpGet]
        [Produces(typeof(IEnumerable<Player>))]
        public ActionResult<IEnumerable<Player>> GetPlayerListByRank()
        {
            try
            {
                IEnumerable<Player> playerList = _playerService.GetPlayerListByRank();

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

        [HttpGet]
        [Produces(typeof(Player))]
        public ActionResult<Player> GetPlayerById(int id)
        {
            try
            {
                Player player = _playerService.GetPlayerById(id);

                return Ok(player);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(422, ex.Message);
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

        [HttpGet]
        [Produces(typeof(GlobalStat))]
        public ActionResult<GlobalStat> GetPlayerGlobalStat()
        {
            try
            {
                GlobalStat globalStat = _playerService.GetPlayerGlobalStat();

                return Ok(globalStat);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
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
