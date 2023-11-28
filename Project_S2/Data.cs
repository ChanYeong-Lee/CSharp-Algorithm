using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S2
{
    public class Data
    {
        public Map map;
        public Player player;
        public Data(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }
    }
}
