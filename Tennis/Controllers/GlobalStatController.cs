using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Services;

namespace Tennis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlobalStatController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public GlobalStatController(IPlayerService playerService)
        {
            _playerService = playerService;
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
