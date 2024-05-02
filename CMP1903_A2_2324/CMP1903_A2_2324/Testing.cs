/* By: Joshua Buckley
   28465302@students.lincoln.ac.uk
   CMP1903_A2_2324
   Computer Science (Bsc)
   Assessment 2
 */
using System;
using System.Diagnostics;
using CMP1903_A2_2324;

namespace CMP1903_A2_2324_Tests
{
    
    /// <summary>
    /// Debugging Class
    /// Designed to be non intrusive and editable for extensive debugging purposes
    /// </summary>
    internal class Testing
    {
        private SevensOut SevensOut_Mode;
        private ThreeOrMore ThreeOrMore_Mode;

        public Testing(SevensOut Sevens_Out, ThreeOrMore Three_Or_More)
        {
            this.SevensOut_Mode = Sevens_Out;
            this.ThreeOrMore_Mode = Three_Or_More;
        }

        public void Test_SevensOut()
        {
            SevensOut_Mode.PlayGame(false);

            
            Debug.Assert(SevensOut_Mode.Last_Roll_Sum == 7, "DEBUG ERROR: GameEnd sum != 7. Game must end when 7 is rolled!");

            
            Trace.Assert(SevensOut_Mode.Player1_Total_Score >= 0 && SevensOut_Mode.Player2_Total_Score >= 0, "TRACE ERROR: Player scores should not be negative.");

           
            Console.WriteLine($"Player 1 Score: {SevensOut_Mode.Player1_Total_Score}");
            Console.WriteLine($"Player 2 Score: {SevensOut_Mode.Player2_Total_Score}");

            
            Console.WriteLine("SevensOut Debug complete. All checks passed successfully!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }

        public void Test_ThreeOrMore()
        {
            ThreeOrMore_Mode.PlayGame(false);

            
            Debug.Assert(ThreeOrMore_Mode.Player1_Score >= 20 || ThreeOrMore_Mode.Player2_Score >= 20, "DEBUG ERROR: Final EndGame score < 20. One player must have a score of at least 20.");

            Trace.Assert(ThreeOrMore_Mode.Game_Count > 0, "TRACE ERROR: Game count should be incremented after playing the game!");

           
            Console.WriteLine($"Player 1 Score: {ThreeOrMore_Mode.Player1_Score}");
            Console.WriteLine($"Player 2 Score: {ThreeOrMore_Mode.Player2_Score}");

            
            Console.WriteLine("ThreeOrMore Debug complete! All checks passed successfully!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            

        }



        private int CalculateExpectedPoints(int sum)
        {
         
            if (sum == 7)
                return 0; 
            else
                return sum;
        }

        private int CalculateExpectedPoints(int player1Score, int player2Score)
        {
            
            return Math.Max(player1Score, player2Score); 
        }

        public void TestAll()
        {
            Console.WriteLine("Starting tests...");

            Test_SevensOut();
            Test_ThreeOrMore();

            Console.WriteLine("Debugging complete. Press any key to continue...");
            Console.ReadKey();
        }
    }
}