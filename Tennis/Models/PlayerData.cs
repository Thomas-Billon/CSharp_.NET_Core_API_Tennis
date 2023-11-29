namespace Tennis.Models
{
    public class PlayerData
    {
        public int Rank { get; set; } = 0;
        public int Points { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int Age { get; set; } = 0;
        public bool[] Last { get; set; } = new bool[0];
    }
}
