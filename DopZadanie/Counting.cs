using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DopZadanie
{
    public static class Counting
    {
        public static int CountZeros(string input)
        {
            int count = input.Count(x => x == '0');
            return count;
        }
    }
}
