using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Player
    {
        internal Random numGenerator;

        internal int playerNum;
        internal int teamNum;

        public Player(Random numGenerator, int playerNum, int teamNum)
        {
            this.numGenerator = numGenerator;
            this.playerNum = playerNum;
            this.teamNum = teamNum;
        }

        public virtual int Roll()
        {
            Console.WriteLine($"I am player {playerNum} on team {teamNum} and I am rolling");

            return numGenerator.Next(1, 1);
        }
    }
}
