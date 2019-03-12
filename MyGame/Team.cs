using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Team
    {
        Player[] players;
        public Player[] Players
        {
            get { return players; }
        }

        int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        string teamName;
        public string TeamName
        {
            get { return teamName; }
        }

        public Team(Player[] players, string teamName)
        {
            this.players = players;
            this.teamName = teamName;
        }
    }
}
