using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    public class Main
    {
        private const String PLAYERS_FULL ="PLAYERS_FULL#" ;
        private const String ALREADY_ADDED= "ALREADY_ADDED#";
        private const String GAME_ALREADY_STARTED = "GAME_ALREADY_STARTED";
        private Player.Player player = new Player.Player();
        public String joinserver()
        {
            return "JOIN#";
        }
        public int serverJoinReply(String reply)
        {
            switch(reply){
                case PLAYERS_FULL :return 1;
                case ALREADY_ADDED : return 2;
                case GAME_ALREADY_STARTED : return 3;
                default: return 0;
            }
                            
        }
        public int acceptance(String acceptanceText) 
        {
            if (acceptanceText.EndsWith("#"))
            {
                acceptanceText=acceptanceText.Remove(acceptanceText.Length-1);
                char[] charArray = { ':' }; 
                String[] tokens=acceptanceText.Split(charArray);               
                player.playerNumber=int.Parse(tokens[1].Substring(1,1));
                player.playerLocationX=int.Parse(tokens[2].Substring(0, 1));
                player.playerLocationY=int.Parse(tokens[2].Substring(2, 1));
                player.direction=int.Parse(tokens[3]);
                Console.WriteLine(player.ToString());
            }
            else
            {
                Console.WriteLine("Error in message received..");
                return 0;
            }
            return 1;
        }
        public int initiation(String initialtionText)
        {
            if (initialtionText.EndsWith("#"))
            {
                initialtionText = initialtionText.Remove(initialtionText.Length - 1);
                char[] charArray = { ':' };
                String[] tokens = initialtionText.Split(charArray);

                if (tokens[1].Substring(1, 1).Equals(player.playerNumber.ToString()))
                {
                    char[] resCharArray = { ';' };
                    String[] brickWalls = tokens[2].Split(resCharArray);
                }
                else
                {
                    Console.WriteLine("There is an error with the initiation String player mismatch");
                }
            }
            else
            {
                Console.WriteLine("There is an error with the initiation String");
                return 0;
            }
            return 1;
        }

    }
}
