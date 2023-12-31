﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
                return StatusCode(404, ex.Message);
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
