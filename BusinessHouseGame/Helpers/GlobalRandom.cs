using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame.Helpers
{
    internal static class GlobalRandom
    {
        private static System.Random randomInstance = null;

        internal static double NextDouble
        {
            get
            {
                if (randomInstance == null)
                    randomInstance = new System.Random();

                return randomInstance.NextDouble();
            }
        }
    }
}
