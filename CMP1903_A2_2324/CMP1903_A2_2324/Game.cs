/* By: Joshua Buckley
   28465302@students.lincoln.ac.uk
   CMP1903_A2_2324
   Computer Science (Bsc)
   Assessment 2
 */
using CMP1903_A2_2324_Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Class to make game user friendly by providing basic UI and menu features. Allows player to navigate game
    /// </summary>
    internal class Game
    {
        private Statistics Stat_Mode;
        private SevensOut SevensOut_Mode;
        private ThreeOrMore ThreeOrMore_Mode;
        private Testing Test_Mode;

        public Game(Statistics Stat_Mode, SevensOut SevensOut_Mode, ThreeOrMore ThreeOrMore_Mode, Testing Test_Mode)
        {
            this.Stat_Mode = Stat_Mode;
            this.SevensOut_Mode = SevensOut_Mode;
            this.ThreeOrMore_Mode = ThreeOrMore_Mode;
            this.Test_Mode = Test_Mode;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Game created by: Joshua Buckley (28765302)");
                Console.WriteLine("Welcome to the wacky world of dice! Make yourself at home...");
                Console.WriteLine();
                Console.WriteLine("What would you like to play?");
                Console.WriteLine();
                Console.WriteLine("1) Play SevensOut");
                Console.WriteLine("2) Play ThreeOrMore");
                Console.WriteLine("3) View Game Statistics");
                Console.WriteLine("4) Debug");
                Console.WriteLine("5) Exit\n");

                Console.Write("Select using the number keys (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out int Player_Choice) || Player_Choice < 1 || Player_Choice > 5)
                {
                    Console.WriteLine("\nPlease enter a number from 1-5.\n");
                    Console.ReadKey();
                    continue;
                }

                switch (Player_Choice)
                {
                    case 1:
                        Play_SevensOut();
                        break;
                    case 2:
                        Play_ThreeOrMore();
                        break;
                    case 3:
                        View_Stats();
                        break;
                    case 4:
                        Game_Test();
                        break;
                    case 5:
                        Console.WriteLine("\nLeaving so soon?\n");
                        return;
                    default:
                        Console.WriteLine("\nPlease enter a number from 1 - 5.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Play_SevensOut()
        {
            Console.Clear();
            Console.WriteLine("SevensOut:");
            Console.WriteLine();
            Console.WriteLine("1) PvP (Local game)");
            Console.WriteLine("2) PvE (Face the CPU!)");
            Console.WriteLine("3) SevensOut statistics");
            Console.WriteLine("4) SevensOut Debug mode");
            Console.WriteLine("5) Return to main menu");
            Console.WriteLine();
            Console.Write("Select using the number keys (1-5): ");

            while (Console.KeyAvailable)
                Console.ReadKey(intercept: true);

            if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > 5)
            {
                Console.WriteLine("Please enter a number from 1-5.");
                Console.ReadKey();
                return;
            }

            switch (option)
            {
                case 1:
                    SevensOut_Mode.PlayGame(false);
                    break;
                case 2:
                    SevensOut_Mode.PlayGame(true);
                    break;
                case 3:
                    Stat_Mode.Print_SevensOut_Stats();
                    break;
                case 4:
                    Test_Mode.Test_SevensOut();
                    break;
                case 5:
                    return;
            }
            Pause();
        }

        private void Play_ThreeOrMore()
        {
            Console.Clear();
            Console.WriteLine("ThreeOrMore:");
            Console.WriteLine();
            Console.WriteLine("1) PvP (Local Game)");
            Console.WriteLine("2) PvE (Face the CPU!)");
            Console.WriteLine("3) ThreeOrMore statistics");
            Console.WriteLine("4) ThreeOrMore Debug mode");
            Console.WriteLine("5) Return to main menu");
            Console.WriteLine();
            Console.Write("Select using the number keys (1-5): ");

            while (Console.KeyAvailable)
                Console.ReadKey(intercept: true);

            if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > 5)
            {
                Console.WriteLine("Please enter a number from 1-5.");
                Console.ReadKey();
                return;
            }

            switch (option)
            {
                case 1:
                    ThreeOrMore_Mode.PlayGame(false);
                    break;
                case 2:
                    ThreeOrMore_Mode.PlayGame(true);
                    break;
                case 3:
                    Stat_Mode.Print_ThreeOrMore_Stats();
                    break;
                case 4:
                    Test_Mode.Test_ThreeOrMore();
                    break;
                case 5:
                    return;
            }
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        private void View_Stats()
        {
            Console.Clear();
            Console.WriteLine("What statistics would you like to see?");
            Console.WriteLine();
            Console.WriteLine("1) SevensOut");
            Console.WriteLine("2) ThreeOrMore");

            while (Console.KeyAvailable)
                Console.ReadKey(intercept: true);

            if (!int.TryParse(Console.ReadLine(), out int Stat_Choice) || Stat_Choice < 1 || Stat_Choice > 2)
            {
                Console.WriteLine("Please enter either 1 or 2");
                Console.ReadKey();
                return;
            }

            switch (Stat_Choice)
            {
                case 1:
                    Stat_Mode.StatDisplay("SevensOut");
                    break;
                case 2:
                    Stat_Mode.StatDisplay("ThreeOrMore");
                    break;
                default:
                    Console.WriteLine("Please enter either 1 or 2");
                    Console.ReadKey();
                    return;
            }


            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }


        private void Game_Test()
        {
            Console.Clear();
            Console.WriteLine("Debug Options");
            Console.WriteLine();
            Console.WriteLine("1. Debug SevensOut");
            Console.WriteLine("2. Debug ThreeOrMore");
            Console.WriteLine("3. Return to the Main Menu");
            Console.WriteLine();
            Console.Write("Select an option using the number keys (1-3): ");
            while (Console.KeyAvailable)
                Console.ReadKey(intercept: true);

            if (!int.TryParse(Console.ReadLine(), out int Test_Choice) || Test_Choice < 1 || Test_Choice > 3)
            {
                Console.WriteLine("Please enter a number from 1-5.");
                Console.ReadKey();
                return;
            }

            switch (Test_Choice)
            {
                case 1:
                    Test_Mode.Test_SevensOut();
                    Console.WriteLine("SevensOut debugging complete.");
                    break;
                case 2:
                    Test_Mode.Test_ThreeOrMore();
                    Console.WriteLine("ThreeOrMore debugging complete.");
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;
            }
        }
    }
}