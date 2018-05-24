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

        public static List<string[]> ReadGameResults(string fileName)
        {
            var allValues = new List<string[]>();
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

                    allValues.Add(lineValues);
                }
            }
            return allValues;
        }
    }
}
