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
    /// Die class; serves to simulate RNG in the context of a six-sided die.
    /// </summary> 
    internal class Die
    {
        /// <summary>
        /// Random number generator to simulate die roll. 
        /// </summary>
        private Random rand;

        // int type to hold current value of die
        private int Num;

        /// <summary>
        /// Property established for subsequent referencing of current die value.
        /// </summary>
        public int Number
        {
            get { return Num; }
            private set { Num = value; }
        }

        /// <summary>
        /// Random object is initialised and an initial roll is performed
        /// </summary>
        public Die()
        {
            rand = new Random();

            Roll();
        }

        /// <summary>
        /// Roll Die, return value. 
        /// Random number between 1-6 becomes new Die value, and is returned. 
        /// </summary>
        public int Roll()
        {
            int Die_Roll = rand.Next(1, 7);
            Number = Die_Roll;
            return Die_Roll;
        }


    }
}