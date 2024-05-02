/* By: Joshua Buckley
   28465302@students.lincoln.ac.uk
   CMP1903_A2_2324
   Computer Science (Bsc)
   Assessment 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    /// <summary>
    ///  Class serves to hold, and subsequently display certin statistics tracked in the 2 die games.
    ///  Class calls upon counters in the 'ThreeOrMore' and 'SevensOut' class that track relevant stats. 
    /// </summary>
    internal class Statistics
    {
        private SevensOut SevensOut_Mode;
        private ThreeOrMore ThreeOrMore_Mode;

        /// <summary>
        /// Constructor; Initialize the class
        /// Include instances of 'ThreeOrMore' and 'SevensOut' gametypes. 
        /// </summary>
        public Statistics(SevensOut Sevens_Out, ThreeOrMore Three_Or_More)
        {
            SevensOut_Mode = Sevens_Out ?? throw new ArgumentNullException(nameof(Sevens_Out));
            ThreeOrMore_Mode = Three_Or_More ?? throw new ArgumentNullException(nameof(Three_Or_More));
        }

        // Method to display certain stats based on case dependency. 
        public void StatDisplay(string GameMode)
        {
            switch (GameMode)
            {
                case "SevensOut":
                    Print_SevensOut_Stats();
                    break;
                case "ThreeOrMore":
                    Print_ThreeOrMore_Stats();
                    break;
                default:
                    Console.WriteLine("No data available");
                    break;
            }
        }

        // Blueprint for how 'SevensOut' stats should be displayed.
        public void Print_SevensOut_Stats()
        {
            Console.WriteLine();
            Console.WriteLine("SevensOut Statistics:");
            Console.WriteLine();
            Console.WriteLine($"Games Played: {SevensOut_Mode.Game_Count}");
            Console.WriteLine($"Played with Human (PvP): {SevensOut_Mode.HumanGame_Count}");
            Console.WriteLine($"Played with CPU (PvE): {SevensOut_Mode.CPUGame_Count}");
            Console.WriteLine();
            Console.WriteLine($"Wins - Player 1: {SevensOut_Mode.Player1_Wins}");
            Console.WriteLine($"Wins - Player 2: {SevensOut_Mode.Player2_Wins}");
            Console.WriteLine($"Wins - CPU: {SevensOut_Mode.CPU_Wins}");
            Console.WriteLine();
            Console.WriteLine($"High Score: {SevensOut.High_Score}");
            Console.WriteLine();
        }

        // Blueprint for how 'ThreeOrMore' stats should be displayed.
        public void Print_ThreeOrMore_Stats()
        {
            Console.WriteLine();
            Console.WriteLine("ThreeOrMore Statistics:");
            Console.WriteLine();
            Console.WriteLine($"Games Played: {ThreeOrMore_Mode.Game_Count}");
            Console.WriteLine($"Played with Human (PvP): {ThreeOrMore_Mode.HumanGame_Count}");
            Console.WriteLine($"Played with CPU (PvE): {ThreeOrMore_Mode.CPUGame_Count}");
            Console.WriteLine();
        }
    }
}