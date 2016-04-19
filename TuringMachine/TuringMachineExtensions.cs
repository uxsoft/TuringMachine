using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public static class TuringMachineExtensions
    {
        public static bool IsOneOf(this char c, string options)
        {
            return options.ToCharArray().Contains(c);
        }
    }
}
