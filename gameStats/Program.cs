using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gameStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "gameStats.csv");
            var fileContents = ReadGameResults(fileName);
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<GameResult> ReadGameResults(string fileName)
        {
            var allValues = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                // Remove the heading row from the CSV file
                reader.ReadLine();
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] lineValues = line.Split(',');

                    DateTime gameDate;
                    if (DateTime.TryParse(lineValues[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = lineValues[1];

                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(lineValues[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(lineValues[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse(lineValues[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse(lineValues[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }
                    if (int.TryParse(lineValues[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if (double.TryParse(lineValues[7], out possessionPercent))
                    {
                        gameResult.PossessionPercent = possessionPercent;
                    }
                    allValues.Add(gameResult);
                }
            }
            return allValues;
        }
    }
}
