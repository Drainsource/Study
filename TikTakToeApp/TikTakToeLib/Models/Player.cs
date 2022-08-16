using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
