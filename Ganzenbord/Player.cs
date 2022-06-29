using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    class Player
    {
        public string Name { get; set; }
        public int SpotNum { get; set; }

        public int Score { get; set; }

        public Player(string name, int spotNum)
        {
            Name = name.ToUpper();
            SpotNum = spotNum;
            Score = 0;
        }
    }
}
