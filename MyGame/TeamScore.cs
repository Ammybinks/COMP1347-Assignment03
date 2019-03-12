using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    // Stores whatever score a team rolled, along with the associated team
    class TeamScore
    {
        Team team;
        public Team Team
        {
            get { return team; }
        }

        int score;
        public int Score
        {
            get { return score; }
        }

        public TeamScore(Team team, int score)
        {
            this.team = team;
            this.score = score;
        }
    }
}
