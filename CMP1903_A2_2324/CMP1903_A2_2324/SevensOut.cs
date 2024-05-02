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
    /// Class identifies identit of SevensOut GameMode. 
    /// Statistics handled by Statistic Class
    /// </summary>
    internal class SevensOut
    {
        private Die Die_1 = new Die();
        private Die Die_2 = new Die();
        private static Random random = new Random();

        public int Player1_Total_Score { get; private set; }
        public int Player2_Total_Score { get; private set; }
        public static int High_Score { get; private set; }
        public int Game_Count { get; private set; }
        public int HumanGame_Count { get; private set; }
        public int CPUGame_Count { get; private set; }
        public int Player1_Wins { get; private set; }
        public int Player2_Wins { get; private set; }
        public int CPU_Wins { get; private set; }
        public int Last_Roll_Sum { get; private set; }

        public void PlayGame(bool V_CPU)
        {
            Console.Clear();
            bool isPlayer1_Turn = random.Next(2) == 0;
            Console.WriteLine("Rules: Rolling sum of 7 ends game; highest score by the end wins! Rolling 7 on first turn of the game results in loss.");
            Console.WriteLine();
            Console.WriteLine("\n" + (isPlayer1_Turn ? "Player 1 is going first!" : (V_CPU ? "CPU is starting first!" : "Player 2 is starting first!")) + "\n");

            Reset_Game();

            Game_Count++;
            if (V_CPU)
            {
                CPUGame_Count++;
            }
            else
            {
                HumanGame_Count++;
            }

            bool Game_Run = true;
            bool Initial_Roll = true;

            while (Game_Run)
            {
                Console.WriteLine($"\n{(isPlayer1_Turn ? "Player 1" : (V_CPU ? "CPU" : "Player 2"))}'s turn. Current Score: {(isPlayer1_Turn ? Player1_Total_Score : Player2_Total_Score)}");
                if (!V_CPU || isPlayer1_Turn)
                {
                    Console.WriteLine("Press any key to roll...");
                    Console.ReadKey(true);
                }

                int Roll_1 = Die_1.Roll();
                int Roll_2 = Die_2.Roll();
                int sum = Roll_1 + Roll_2;
                Last_Roll_Sum = sum;

                if (Roll_1 == Roll_2)
                    sum *= 2;

                Console.WriteLine($"Rolled: {Roll_1} and {Roll_2}. Total: {sum}\n");

                if (Initial_Roll && sum == 7)
                {
                    Console.WriteLine("SEVENSOUT on first turn!\n");
                    Game_Run = false;
                    Print_Loser(isPlayer1_Turn, V_CPU);
                }
                else
                {
                    Update_Scores(isPlayer1_Turn, sum);
                    Console.WriteLine($"Score: {(isPlayer1_Turn ? Player1_Total_Score : Player2_Total_Score)}");

                    if (sum == 7)
                    {
                        Console.WriteLine("SEVENSOUT!\n");
                        Game_Run = false;
                        Print_Winner(V_CPU);
                    }
                    else
                    {
                        isPlayer1_Turn = !isPlayer1_Turn;
                        Initial_Roll = false;
                    }
                }
            }
        }

        private void Print_Winner(bool vsCPU)
        {
            if (Player1_Total_Score > Player2_Total_Score)
            {
                Player1_Wins++;
                Console.WriteLine("Player 1 Wins! \n");
            }
            else if (Player2_Total_Score > Player1_Total_Score)
            {
                if (vsCPU)
                {
                    CPU_Wins++;
                    Console.WriteLine("CPU Wins! \n");
                }
                else
                {
                    Player2_Wins++;
                    Console.WriteLine("Player 2 Wins! \n");
                }
            }
            else
            {
                Console.WriteLine("It's a tie!\n");
            }
        }

        private void Print_Loser(bool isPlayer1_Turn, bool vsCPU)
        {
            if (isPlayer1_Turn)
            {
                Console.WriteLine("Player 1 Loses! \n");
            }
            else
            {
                if (vsCPU)
                {
                    Console.WriteLine("CPU Loses! \n");
                }
                else
                {
                    Console.WriteLine("Player 2 Loses! \n");
                }
            }
        }

        private void Update_Scores(bool isPlayer1_Turn, int sum)
        {
            if (isPlayer1_Turn)
            {
                Player1_Total_Score += sum;
                if (Update_High_Score(Player1_Total_Score))
                    Console.WriteLine("NEW HIGH SCORE!\n");
            }
            else
            {
                Player2_Total_Score += sum;
                if (Update_High_Score(Player2_Total_Score))
                    Console.WriteLine("NEW HIGH SCORE!\n");
            }
        }

        private static bool Update_High_Score(int score)
        {
            if (score > High_Score)
            {
                High_Score = score;
                return true;
            }
            return false;
        }

        public void Reset_Game()
        {
            Player1_Total_Score = 0;
            Player2_Total_Score = 0;
            Last_Roll_Sum = 0;
        }

        public static void ResetHighScore()
        {
            High_Score = 0;
        }
    }
}