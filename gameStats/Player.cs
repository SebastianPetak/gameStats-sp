using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameStats
{

    public class RootObject
    {
        public Player[] Player { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int goals_scored { get; set; }
        public string team_name { get; set; }
        public string favorite_percentage { get; set; }
        public string photo { get; set; }
        public bool good_player { get; set; }
    }

}
