using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Game
    {
        Random numGenerator = new Random();

        Player[] players;
        Team[] teams;

        Referee referee;

        int playerCount = 3;
        int teamCount = 2;

        public Game()
        {
            StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome, let the games begin.");

            teams = new Team[teamCount];

            // Create each team, populating them with players
            for (int i = 0; i < teamCount; i++)
            {
                players = new Player[playerCount];

                // Create each player, adding them to the team
                for (int o = 0; o < playerCount; o++)
                {
                    // Every second player will be a super player
                    if(o == 1)
                    {
                        players[o] = new SuperPlayer(numGenerator, o + 1, i + 1);
                    }
                    else
                    {
                        players[o] = new Player(numGenerator, o + 1, i + 1);
                    }
                }

                string name = $"Team {i + 1}";

                teams[i] = new Team(players, name);
            }

            referee = new Referee(numGenerator, teams, playerCount);
        }
    }
}
