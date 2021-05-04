using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019v2 
{
    internal static class Program
    {
        private static readonly Dictionary<string, double> Records = new Dictionary<string, double>() {
            {"Male World Record Time", 9.58},
            {"Female World Record Time", 10.49},

            {"Male European Record Time", 9.86},
            {"Female European Record Time", 10.73},

            {"Male British Record Time", 9.87},
            {"Female British Record Time", 10.89},
        };
        private static string FindRecord(bool isMale, double time)
        {
            var result = Records.FirstOrDefault(x => time < x.Value &&
                                    ((x.Key.StartsWith("M") && isMale) ||
                                     (x.Key.StartsWith("F") && !isMale)));
            
            return result.Equals(default(KeyValuePair<string, double>)) ? null : $"{result.Key} by {Math.Round(result.Value-time, 2):0.00}s";
        }

        private static void ConsoleWriteColour(string input, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        private static void Main(string[] args)
        {
            bool brokenRecord = false;
            var athleteDict = new Dictionary<string, double>();
            Console.WriteLine("0: Female Athletes\n" +
                              "1: Male Athletes");
            Console.Write("Enter group : ");

            if (!int.TryParse(Console.ReadLine(), out int groupOption) || !(groupOption > -1 && groupOption < 2))
            {
                ConsoleWriteColour("Invalid group.", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }

            bool isMale = groupOption == 1;
            Console.Clear();
            
            Console.Write("How many athletes / lanes: ");
            if (!int.TryParse(Console.ReadLine(), out int athleteCount) || !(athleteCount > 3 && athleteCount < 9))
            {
                ConsoleWriteColour("Invalid athlete count specified.", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Input times in lane order ");

            for (int i = 1; i < athleteCount + 1; i++)
            {
                Console.Write($"Lane {i} time: ");

                if (float.TryParse(Console.ReadLine(), out float time))
                    athleteDict.Add($"Athlete {i}", Math.Round(time, 2));
            }
            Console.Clear();
            ConsoleWriteColour("-----Leaderboard-----", ConsoleColor.Blue);

            foreach (var athlete in athleteDict.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{athlete.Key}: {athlete.Value}s");

                string record = FindRecord(isMale, athlete.Value);
                if (record != null && brokenRecord == false)
                {
                    brokenRecord = true;
                    ConsoleWriteColour($"[!] {athlete.Key} broke the '{record}'!", ConsoleColor.DarkYellow);
                }
            }

            Console.ReadKey();
        }
    }
}
