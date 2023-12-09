using System.Collections.Generic;
using Tennis.Models;
using Tennis.Models.Views;
using Tennis.Repositories;

namespace Tennis.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetPlayerList()
        {
            return _playerRepository.GetAll();
        }

        public IEnumerable<Player> GetPlayerListByRank(string? order)
        {
            switch (order)
            {
                case "asc":
                    return GetPlayerListByRankAsc();

                case "desc":
                    return GetPlayerListByRankDesc();

                default:
                    // Just return 
                    return GetPlayerListByRankAsc();
            }
        }

        public IEnumerable<Player> GetPlayerListByRankAsc()
        {
            return _playerRepository.GetAll().OrderBy(p => p.Data.Rank);
        }

        public IEnumerable<Player> GetPlayerListByRankDesc()
        {
            return _playerRepository.GetAll().OrderByDescending(p => p.Data.Rank);
        }

        public Player GetPlayerById(int id)
        {
            return _playerRepository.Get(id);
        }

        public GlobalStat GetPlayerGlobalStat()
        {
            // Better to use list since we are going to iterate through it multiple times
            List<Player> playerList = _playerRepository.GetAll().ToList();

            return new GlobalStat
            {
                BestRatioCountry = CalculateBestRatioCountry(playerList),
                AverageBMI = CalculateAverageBMI(playerList),
                MedianHeight = CalculateMedianHeight(playerList)
            };
        }

        public PlayerCountry CalculateBestRatioCountry(List<Player> playerList)
        {
            if (playerList.Count == 0)
            {
                throw new InvalidOperationException("Error: Cannot calculate global stats as player list is empty");
            }

            // Init
            float bestRatio = 0;
            PlayerCountry bestRatioCountry = new PlayerCountry();

            // Group players by country
            var CountryList = playerList.GroupBy(p => p.Country, p => p.Data.Last, (key, group) => new
                {
                    Country = key,
                    LastList = group
                });

            // Loop on each group and get best ratio
            foreach (var country in CountryList)
            {
                float total = 0;
                float win = 0;

                foreach (bool[] last in country.LastList)
                {
                    total += last.Length;
                    win += last.Count(l => l);
                }

                float ratio = win / total;

                if (ratio > bestRatio)
                {
                    bestRatio = ratio;
                    bestRatioCountry = country.Country;
                }
            }

            return bestRatioCountry;
        }

        public float CalculateAverageBMI(List<Player> playerList)
        {
            if (playerList.Count == 0)
            {
                throw new InvalidOperationException("Error: Cannot calculate global stats as player list is empty");
            }

            float totalBMI = 0;

            foreach (Player player in playerList)
            {
                float weightKG = player.Data.Weight / 1000f;
                float heightM = player.Data.Height / 100f;

                // BMI = weight (kg) / height^2 (m)
                totalBMI += weightKG / (heightM * heightM);
            }

            return totalBMI / playerList.Count;
        }

        public float CalculateMedianHeight(List<Player> playerList)
        {
            if (playerList.Count() == 0)
            {
                throw new InvalidOperationException("Error: Cannot calculate global stats as player list is empty");
            }

            // Better than using OrderBy() & ToList()
            List<Player> orderedList = playerList;
            orderedList.Sort((x, y) => x.Data.Height.CompareTo(y.Data.Height));

            // Odd median
            if (orderedList.Count % 2 == 1)
            {
                return orderedList[orderedList.Count / 2].Data.Height;
            }
            // Even median
            else
            {
                float playerHeight1 = orderedList[orderedList.Count / 2 - 1].Data.Height;
                float playerHeight2 = orderedList[orderedList.Count / 2].Data.Height;

                return (playerHeight1 + playerHeight2) / 2;
            }
        }
    }
}
