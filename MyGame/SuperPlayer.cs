using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class SuperPlayer:Player
    {
        public SuperPlayer(Random numGenerator, int playerNum, int teamNum):base(numGenerator, playerNum, teamNum)
        {

        }

        public override int Roll()
        {
            Console.WriteLine($"I am the super player on team {teamNum} and I am rolling");

            return numGenerator.Next(1, 101);
        }
    }
}
