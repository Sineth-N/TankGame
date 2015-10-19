using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame.Player
{
    class Player
    {
        private int playerNumber;
        private int playerLocationX;
        private int playerLocationY;
        private int direction;

        public void setPlayerNumber(int number)
        {
            this.playerNumber = number;
        }
        public int getPlayerNumber()
        {
            return playerNumber;
        }
        public void setPlayerLocationX(int x)
        {
            this.playerLocationX = x;
        }
        public int getPlayerLocationX()
        {
            return playerLocationX;
        }
        public void setPlayerLocationY(int y)
        {
            this.playerLocationY = y;
        }
        public int getPlayerLocationY()
        {
            return playerLocationY;
        }

        public void setDirection(int p)
        {
            this.direction = p;
        }
        public void ToString()
        {
            Console.WriteLine("Player Number:" + this.playerNumber + "\n X Coordinate" + this.playerLocationX
                + "\n Y Coordinate" + this.playerLocationY + "\n Current Direction " + this.direction
                );
        }

    }
}
