using Microsoft.Extensions.Configuration;
using Tennis.Data;
using Tennis.Models;

namespace Tennis.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IJsonReader _jsonReader;

        public PlayerRepository(IConfiguration configuration, IJsonReader jsonReader)
        {
            _configuration = configuration;
            _jsonReader = jsonReader;
        }

        public IEnumerable<Player> List()
        {
            PlayerList? playerList = _jsonReader.Read<PlayerList>(_configuration["Data:FilePath"]);

            if (playerList == null)
            {
                return new List<Player>();
            }

            return playerList.Players;
        }

        public Player Get(int id)
        {
            PlayerList? playerList = _jsonReader.Read<PlayerList>(_configuration["Data:FilePath"]);

            if (playerList == null || playerList.Players == null)
            {
                throw new ArgumentException($"Error: Id {id} not found");
            }

            Player? player = playerList.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                throw new ArgumentException($"Error: Id {id} not found");
            }

            return player;
        }

        public bool Create(Player item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Player item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
