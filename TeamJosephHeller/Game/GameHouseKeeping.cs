using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaWars
{
    public static class GameHouseKeeping
    {
        private static readonly Random randomGenerator = new Random();

        public static Random RandomGenerator
        {
            get
            {
                return randomGenerator;
            }
        }

        public static bool GetProbabilityPercentage(double percentage)
        {
            if (RandomGenerator.Next(0, 101) < percentage)
            {
                return true;
            }

            return false;
        }
    }
}
