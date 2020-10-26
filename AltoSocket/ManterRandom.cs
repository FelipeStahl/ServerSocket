using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoSocket
{
    internal static class ManterRandom
    {
        public static Random Rand;
        public static int proximo()
        {
            if (Rand == null)
            {
                Rand = new Random();
            }
            return Rand.Next();
        }
    }
}
