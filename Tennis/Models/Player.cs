namespace Tennis.Models
{
    public class Player
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public PlayerCountry Country { get; set; } = null!;
        public string Picture { get; set; } = string.Empty;
        public PlayerData Data { get; set; } = null!;
    }

    public class PlayerList
    {
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
