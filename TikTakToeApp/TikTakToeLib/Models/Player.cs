namespace TikTakToeLib.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Cell CellType { get; set; }
        public Player(string name, Cell cellType)
        {
            Name = name;
            CellType = cellType;
        }


    }
}
