using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tennis.Models;
using Tennis.Utilities;

namespace Tennis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private List<Player> GetPlayerList()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Data/headdtohead.json"))
                {
                    string json = reader.ReadToEnd();
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new BoolConverter() },
                        PropertyNameCaseInsensitive = true
                    };

                    PlayerList? playerList = JsonSerializer.Deserialize<PlayerList>(json, options);

                    return (playerList == null) ? new List<Player>() : playerList.Players;
                }
            }
            catch (Exception)
            {
                // Exception thrown:
                //  - The json file is missing
                //  - The json file doesn't have the proper read access
                //  - The json file has a typo in it
                // In any case we return an empty player list
                return new List<Player>();
            }
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return GetPlayerList();
        }
    }
}
