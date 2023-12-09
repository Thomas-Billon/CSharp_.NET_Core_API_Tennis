using Tennis.Models.Views;
using Tennis.Models;

namespace TestTennis
{
    public class DataSource
    {
        internal static List<Player> GenerateFakePlayerList()
        {
            List<Player> playerList = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Sawyer",
                    ShortName = "T.SAW",
                    Sex = "M",
                    Country = new PlayerCountry
                    {
                        Picture = "https://data.latelier.co/training/tennis_stats/resources/USA.png",
                        Code = "USA"
                    },
                    Picture = "https://en.wikipedia.org/wiki/Tom_Sawyer#/media/File:Tom_Sawyer_1876_frontispiece.jpg",
                    Data = new PlayerData
                    {
                        Rank = 1001,
                        Points = 42,
                        Weight = 48000,
                        Height = 142,
                        Age = 12,
                        Last = new bool[5] { false, true, false, false, false }
                    }
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "Poppins",
                    ShortName = "M.POP",
                    Sex = "F",
                    Country = new PlayerCountry
                    {
                        Picture = "https://en.wikipedia.org/wiki/England#/media/File:Flag_of_England.svg",
                        Code = "GBR"
                    },
                    Picture = "https://en.wikipedia.org/wiki/Mary_Poppins_(character)#/media/File:Mary_Poppins_screen_2.jpg",
                    Data = new PlayerData
                    {
                        Rank = 1003,
                        Points = 100,
                        Weight = 52000,
                        Height = 168,
                        Age = 50,
                        Last = new bool[5] { true, true, true, true, true }
                    }
                },
                new Player
                {
                    Id = 5,
                    FirstName = "Louis",
                    LastName = "De Funès",
                    ShortName = "L.DEF",
                    Sex = "M",
                    Country = new PlayerCountry
                    {
                        Picture = "https://en.wikipedia.org/wiki/France#/media/File:Flag_of_France.svg",
                        Code = "FRA"
                    },
                    Picture = "https://fr.wikipedia.org/wiki/Louis_de_Fun%C3%A8s#/media/Fichier:Louis_de_Fun%C3%A8s_%E2%80%94_L'Homme_orchestre_(1970)_(recadr%C3%A9).jpg",
                    Data = new PlayerData
                    {
                        Rank = 1002,
                        Points = 1000000,
                        Weight = 70000,
                        Height = 172,
                        Age = 68,
                        Last = new bool[5] { true, false, true, false, false }
                    }
                },
                new Player
                {
                    Id = 10,
                    FirstName = "Dwayne",
                    LastName = "Johnson",
                    ShortName = "D.JOH",
                    Sex = "M",
                    Country = new PlayerCountry
                    {
                        Picture = "https://data.latelier.co/training/tennis_stats/resources/USA.png",
                        Code = "USA"
                    },
                    Picture = "https://en.wikipedia.org/wiki/Dwayne_Johnson#/media/File:Dwayne_Johnson_2014_(cropped).jpg",
                    Data = new PlayerData
                    {
                        Rank = 1004,
                        Points = 12,
                        Weight = 118000,
                        Height = 196,
                        Age = 51,
                        Last = new bool[5] { false, true, true, true, true }
                    }
                }
            };

            return playerList;
        }

        internal static GlobalStat GenerateFakeGlobalStat()
        {
            GlobalStat globalStat = new GlobalStat
            {
                BestRatioCountry = new PlayerCountry
                {
                    Picture = "https://en.wikipedia.org/wiki/England#/media/File:Flag_of_England.svg",
                    Code = "GBR"
                },
                AverageBMI = 24.151660927841f,
                MedianHeight = 170
            };

            return globalStat;
        }
    }
}
