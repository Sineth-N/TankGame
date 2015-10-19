using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    public class Main
    {
        public String joinserver()
        {
            return "JOIN#";
        }
        public int serverJoinReply(String reply)
        {
            switch(reply){
                case "PLAYERS_FULL#" :return 1;
                case "ALREADY_ADDED#" : return 2;
                case "GAME_ALREADY_STARTED#": return 3;
                default: return 0;
            }
                            
        }


    }
}
