using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Referee
    {
        Random numGenerator;

        Team[] teams;

        int playerCount; // Total number of players in each team

        // Data members for determining a winner
        int[] rolls;
        List<TeamScore> winners;

        string tempString; // Temporary string for writing winners to console

        bool draw = false;
        bool finished = false;
        bool mPlayOn = true;

        public Referee(Random numGenerator, Team[] teams, int playerCount)
        {
            this.numGenerator = numGenerator;
            this.teams = teams;
            this.playerCount = playerCount;

            while(mPlayOn)
            {
                RunGame();

                Console.WriteLine("Would you like to play again? Y/N");

                while(true)
                {
                    string response = Console.ReadLine();

                    if (response == "N")
                    {
                        mPlayOn = false;

                        break;
                    }
                    else if (response != "Y")
                    {
                        Console.WriteLine("Please enter Y/N");
                    }
                    else
                    {
                        for (int i = 0; i < teams.Length; i++)
                        {
                            teams[i].Score = 0;
                        }

                        finished = false;

                        break;
                    }
                }
            }
        }

        public void RunGame()
        {
            while(!finished)
            {
                /// Determine the winning roll
                ////
                DetermineRolls(numGenerator.Next(0, playerCount));

                WriteRolls();

                winners = DetermineWinner(rolls);

                WriteWinner(winners);
                ////

                /// Determine the winning team, if any
                ////
                int[] teamScores = new int[teams.Length];

                for(int i = 0; i < teams.Length; i++)
                {
                    teamScores[i] = teams[i].Score;
                }

                winners = DetermineWinner(teamScores);

                // Game ends when any team has a total score greater than 10
                if (winners[0].Score >= 10)
                {
                    finished = true;
                }
                ////

                WriteScores();
            }

            WriteWinner(winners);
        }

        /// <summary>
        /// Instructs a player from every team to roll, storing their results in rolls[]
        /// </summary>
        /// <param name="playerIndex">Which player from each team to roll</param>
        private void DetermineRolls(int playerIndex)
        {
            Console.WriteLine($"The player number {playerIndex + 1} has been selected - Players roll your dice...");

            rolls = new int[teams.Length];

            for (int i = 0; i < teams.Length; i++)
            {
                rolls[i] = teams[i].Players[playerIndex].Roll();
            }
        }

        /// <summary>
        /// Writes the results of the rolls to console, concatenating the list of results into a human readable string
        /// </summary>
        private void WriteRolls()
        {
            tempString = "";

            // Counts backwards through the list of rolls, adding each roll to tempString depending on its position in the line
            for (int i = rolls.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    tempString = $"{teams[i].TeamName} rolled {rolls[i]}" + tempString;
                }
                else if (i == rolls.Length - 1)
                {
                    tempString = tempString + $" and {teams[i].TeamName} rolled {rolls[i]}";
                }
                else
                {
                    tempString = $", {teams[i].TeamName} rolled {rolls[i]}" + tempString;
                }
            }

            Console.WriteLine(tempString);
        }

        /// <summary>
        /// Calculates the winner out of a given set of scores 
        /// </summary>
        /// <param name="scores">List of scores to be checked</param>
        /// <returns>A list of the winning scores and their associated team</returns>
        private List<TeamScore> DetermineWinner(int[] scores)
        {
            List<TeamScore> highestScores = new List<TeamScore>();
            draw = false;

            // Steps through each score determining if it's higher than the last, drawing scores are both added to the list until a score is found that's higher
            for (int i = 0; i < scores.Length; i++)
            {
                if (highestScores.Count == 0)
                {
                    highestScores.Add(new TeamScore(teams[i], scores[i]));
                }
                else if (highestScores[0].Score < scores[i])
                {
                    highestScores = new List<TeamScore>() { new TeamScore(teams[i], scores[i]) };
                    draw = false;
                }
                else if (highestScores[0].Score == scores[i])
                {
                    highestScores.Add(new TeamScore(teams[i], scores[i]));

                    draw = true;
                }
            }

            return highestScores;
        }

        /// <summary>
        /// Writes the name of the winning team (or teams) to console
        /// </summary>
        /// <param name="scores">List of winning scores and their associated teams</param>
        private void WriteWinner(List<TeamScore> scores)
        {
            // If drawn, every drawing team is a winner, write them all to console
            if (draw)
            {
                Console.WriteLine("Draw");

                tempString = "";

                // Counts backwards through the list of teams, adding each team to tempString depending on its position in the line
                for (int i = scores.Count - 1; i >= 0; i--)
                {
                    scores[i].Team.Score += 1;

                    if (i == 0)
                    {
                        tempString = scores[i].Team.TeamName + tempString;
                    }
                    else if (i == scores.Count - 1)
                    {
                        tempString = tempString + $" and {scores[i].Team.TeamName}";
                    }
                    else
                    {
                        tempString = $", {scores[i].Team.TeamName}" + tempString;
                    }
                }

                tempString += " are the winners.";

                Console.WriteLine(tempString);
            }
            // Otherwise simply write the winning team
            else
            {
                scores[0].Team.Score += 2;

                Console.WriteLine($"The winner is {scores[0].Team.TeamName}.");
            }
        }

        private void WriteScores()
        {
            tempString = "Scores: ";

            for(int i = 0; i < teams.Length; i++)
            {
                if(i != 0)
                {
                    tempString += ", ";
                }

                tempString += $"{teams[i].TeamName} = {teams[i].Score}";
            }

            Console.WriteLine(tempString);
        }
    }
}
