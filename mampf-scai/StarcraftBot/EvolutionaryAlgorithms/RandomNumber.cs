using System;
using System.Collections.Generic;

namespace StarcraftBot.EvolutionaryAlgorithms
{
    /// <summary>
    /// Random Number Generator class...
    /// @author (Thomas Willer Sandberg) 
    /// @version (1.0, January 2011)
    /// </summary>
    class RandomNumber
    {
        private static readonly FastRandom FastRand = new FastRandom();

        /// <summary>
        /// Generates a random int over the range low to high-1, and not including high.
        /// high must be >= low. low may be negative.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>Random int between the 2 specified numbers</returns>
        public static int RandomInt(int low, int high)
        {
            return FastRand.Next(low, high); //return new Random(  new Random(). nextLong()).nextInt((high + 1) - low) + low;
        }

        /// <summary>
        /// Generates a random float over the range low to high-1, and not including high.
        /// high must be >= low. low may be negative.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>Random float between the 2 specified numbers</returns>
        public static float RandomFloat(float low, float high)
        {
            //http://msdn.microsoft.com/en-us/library/kk426x2b.aspx
            return Convert.ToSingle(FastRand.NextDouble() * 1000000 % (high - low -1) + low);
        }

        /// <summary>
        /// Generates a random double over the range low to high-1, and not including high.
        /// high must be >= low. low may be negative.
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>Random double between the 2 specified numbers</returns>
        public static double RandomDouble(double low, double high)
        {
            return FastRand.NextDouble() * 1000000 % (high - low - 1) + low;
        }

        // odd/even
        public static Boolean Odd(int o)
        {
            return ((o & 1) == 1);
        }

        public static Boolean Even(int e)
        {
            return ((e & 1) == 0);
        }

        /// <summary>
        /// Shuffle a generic List of objecs.
        /// Borrowed from: http://www.vcskicks.com/code-snippet/shuffle-array.php
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="list"></param>
        public static void ShuffleList<E>(IList<E> list)
        {
            if (list.Count > 1)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    E tmp = list[i];
                    int randomIndex = FastRand.Next(i + 1);

                    //Swap elements
                    list[i] = list[randomIndex];
                    list[randomIndex] = tmp;
                }
            }
        }
    }
}
