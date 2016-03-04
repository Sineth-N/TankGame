using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace TankGame
{
    public class Main
    {
        private const String PLAYERS_FULL = "PLAYERS_FULL#";
        private const String ALREADY_ADDED = "ALREADY_ADDED#";
        private const String GAME_ALREADY_STARTED = "GAME_ALREADY_STARTED";
        private Player.Player player = new Player.Player();
        String[] brickWalls;
        String[] stone;
        String[] water;
        String[,] map=new String[10,10];
        private char[] CommacharArray={','};
        
        public String joinserver()
        {
            return "JOIN#";
        }
        public int serverJoinReply(String reply)
        {
            switch (reply)
            {
                case PLAYERS_FULL: return 1;
                case ALREADY_ADDED: return 2;
                case GAME_ALREADY_STARTED: return 3;
                default: return 0;
            }

        }
        public int acceptance(String acceptanceText)
        {
            if (acceptanceText.StartsWith("S") && acceptanceText.EndsWith("#"))
            {
                acceptanceText = acceptanceText.Remove(acceptanceText.Length - 1);
                char[] charArray = { ':' };
                String[] tokens = acceptanceText.Split(charArray);
                player.playerNumber = int.Parse(tokens[1].Substring(1, 1));
                player.playerLocationX = int.Parse(tokens[2].Substring(0, 1));
                player.playerLocationY = int.Parse(tokens[2].Substring(2, 1));
                player.direction = int.Parse(tokens[3]);
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
            if (initialtionText.StartsWith("I") && initialtionText.EndsWith("#"))
            {
                printArray();
                initialtionText = initialtionText.Remove(initialtionText.Length - 2, 2);
                char[] charArray = { ':' };
                String[] tokens = initialtionText.Split(charArray);

                if (tokens[1].Substring(1, 1).Equals(player.playerNumber.ToString()))
                {
                    char[] resCharArray = { ';' };
                    brickWalls = tokens[2].Split(resCharArray);
                    stone = tokens[3].Split(resCharArray);
                    water = tokens[4].Split(resCharArray);
                    for (int i = 0; i < brickWalls.Length; i++)
                    {
                        String[] a=brickWalls[i].Split(CommacharArray);
                        map[int.Parse(a[1]),int.Parse(a[0])] = "B";
                        
                    }
                    for (int i = 0; i < stone.Length; i++)
                    {
                        String[] b = stone[i].Split(CommacharArray);
                        map[int.Parse(b[1]), int.Parse(b[0])] = "S";

                    } 
                    for (int i = 0; i < water.Length; i++)
                    {
                        String[] c = water[i].Split(CommacharArray);
                        map[int.Parse(c[1]), int.Parse(c[0])] = "W";

                    }
                    ReadArray();
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

        private void ReadArray()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
        public void printArray()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = "0";
                }
            }
        }
    }

}
