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

        public Player(string name)
        {
            Name = name.ToUpper();
            SpotNum = 0;
            Score = 0;
        }
    }
}
