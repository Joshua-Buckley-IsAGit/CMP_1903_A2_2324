/* By: Joshua Buckley
   28465302@students.lincoln.ac.uk
   CMP1903_A2_2324
   Computer Science (Bsc)
   Assessment 2
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMP1903_A2_2324;
using CMP1903_A2_2324_Tests;

namespace CMP1903_A2_2324
{
   
    /// <summary>
    /// Main method serves as entry point for the program, initializes modes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SevensOut SevensOut_Mode = new SevensOut();
            ThreeOrMore ThreeOrMore_Mode = new ThreeOrMore();
            Statistics Stat_Mode = new Statistics(SevensOut_Mode, ThreeOrMore_Mode);


            Testing Test_Mode = new Testing(SevensOut_Mode, ThreeOrMore_Mode);


            Game game = new Game(Stat_Mode, SevensOut_Mode, ThreeOrMore_Mode, Test_Mode);
            game.Start();
        }
    }
}