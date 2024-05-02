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
    /// Class dictating the logic and gameflow of the 'ThreeOrMore' gametype
    /// Class talks to 'Statistics' and 'Die' class.
    /// </summary>
    internal class ThreeOrMore
    {
        /// <summary>
        /// Dice Array is established to hold 5 different Die values
        /// </summary>
        private Die[] Dice = new Die[5];

        // Random number generator
        private Random random = new Random();

        public int Player1_Score { get; private set; }
        public int Player2_Score { get; private set; }
        public int Game_Count { get; private set; }
        public int HumanGame_Count { get; private set; }
        public int CPUGame_Count { get; private set; }

        // Constructor to initialize die objects
        public ThreeOrMore()
        {
            for (int i = 0; i < Dice.Length; i++)
            {
                Dice[i] = new Die();
            }
        }

        /// <summary>
        /// Main method to implement gameplay and logic flow
        /// Takes boolean value 'V_CPU' to differentiate between PvP and PvE
        /// </summary>
        public void PlayGame(bool V_CPU)
        {

            // Conditions for the start of game.
            Console.Clear();

            /// bool taken to establish 50% chance of turn rollover at initialization and determines who goes first.
            bool isPlayer1_Turn = random.Next(2) == 0;

            // Win condition outlined
            int Win_Points = 20;

            // Control
            bool Game_Run = true;

            // Resets scores at start of game to prevent score permanance
            Player1_Score = 0;
            Player2_Score = 0;

            // Check which statistic should be invoked
            Game_Count++;
            if (V_CPU) CPUGame_Count++; else HumanGame_Count++;

            // Initial game visuals to aid user experience. 
            Console.WriteLine("Rules: 1ofKind=0pts, 2ofkind=Reroll, 3ofkind=3pts, 4ofkind=6pts, 5ofkind=12pts, first to 20 wins!");
            Console.WriteLine();
            Console.WriteLine($"\n{(isPlayer1_Turn ? "Player 1 is going first!" : (V_CPU ? "CPU is going first!" : "Player 2 is going first!"))}\n");

            // Turn by Turn logic nestled in while loop
            while (Game_Run)
            {

                bool isCPU_Turn = V_CPU && !isPlayer1_Turn;

                Console.WriteLine($"{(isPlayer1_Turn ? "Player 1's turn." : (V_CPU ? "CPU's turn." : "Player 2's turn."))}");
                if (!isCPU_Turn)
                {
                    Console.WriteLine("Press any key to roll...");
                    Console.ReadKey(true);
                }

                int[] Rolls = RollDice();
                int Turn_Points = CalculateScore(Rolls, isCPU_Turn);
                if (isPlayer1_Turn)
                {
                    Player1_Score += Turn_Points;
                    Console.WriteLine($"Player 1 scored {Turn_Points} points! Total Score: {Player1_Score}\n");
                    if (Player1_Score >= Win_Points)
                    {
                        Console.WriteLine("Player 1 wins!\n");
                        Game_Run = false;
                    }
                }
                else
                {
                    Player2_Score += Turn_Points;
                    Console.WriteLine($"{(isCPU_Turn ? "CPU" : "Player 2")} scored {Turn_Points} points! Total Score: {Player2_Score}\n");
                    if (Player2_Score >= Win_Points)
                    {
                        Console.WriteLine($"{(isCPU_Turn ? "CPU wins!\n" : "Player 2 wins!\n")}");
                        Game_Run = false;
                    }
                }

                isPlayer1_Turn = !isPlayer1_Turn;
            }
        }

        private int[] RollDice()
        {
            int[] Results = Dice.Select(d => d.Roll()).ToArray();
            Console.WriteLine($"Rolled: {string.Join(", ", Results)}");
            return Results;
        }
        private int CalculateScore(int[] Rolls, bool isCPU_Turn)
        {
            var Die_Groupings = Rolls.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int score = 0;

            if (Die_Groupings.Values.Contains(5))
            {
                score = 12;
            }
            else if (Die_Groupings.Values.Contains(4))
            {
                score = 6;
            }
            else if (Die_Groupings.Values.Contains(3))
            {
                score = 3;
            }
            else if (Die_Groupings.Values.Contains(2))
            {
                score = Die_Pair(Rolls, Die_Groupings, isCPU_Turn);
            }

            return score;
        }
        
        // Handling for instances where 2-of-a-kind is rolled
        private int Die_Pair(int[] Rolls, Dictionary<int, int> Die_Groupings, bool isCPU_Turn)
        {
            if (!isCPU_Turn)
            {
                bool Valid_Input = false;
                string Player_Choice;
                while (!Valid_Input)
                {
                    Console.WriteLine("2-of-a-kind! Do you want to: (1) roll all 5 dice or (2) roll the remaining three? Tough decisions...");
                    Player_Choice = Console.ReadLine();

                    if (Player_Choice == "1" || Player_Choice == "2")
                    {
                        Valid_Input = true;
                        return ProcessChoice(Rolls, Die_Groupings, Player_Choice.Equals("1"), isCPU_Turn);
                    }
                    else
                    {
                        Console.WriteLine("Please enter '1' or '2'.");
                    }
                }
            }
            else
            {

                bool Roll5 = random.Next(2) == 0;
                Console.WriteLine($"CPU re-rolled {(Roll5 ? "all 5 dice!" : "the remaining 3 dice!")}");
                return ProcessChoice(Rolls, Die_Groupings, Roll5, isCPU_Turn);
            }
            return 0;
        }
        private int ProcessChoice(int[] Rolls, Dictionary<int, int> Groupings, bool Roll5, bool isCPU_Turn)
        {
            if (Roll5)
            {
                Rolls = RollDice();
            }
            else
            {
                int Pair_Value = Groupings.FirstOrDefault(g => g.Value == 2).Key;
                int[] ReRolls = Dice.Where(d => d.Number != Pair_Value).Select(d => d.Roll()).ToArray();
                Rolls = Groupings.Where(g => g.Key == Pair_Value).SelectMany(g => Enumerable.Repeat(g.Key, g.Value)).Concat(ReRolls).ToArray();
                Console.WriteLine($"Rolled: {string.Join(", ", Rolls)}");
            }

            var Updated_Rolls = Rolls.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            if (Updated_Rolls.Values.Contains(2))
            {
                return Die_Pair(Rolls, Updated_Rolls, isCPU_Turn);
            }
            else
            {
                return CalculateScore(Rolls, isCPU_Turn);
            }
        }

    }
}