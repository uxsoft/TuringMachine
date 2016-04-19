using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Tests
{
    [TestClass]
    public class BubbleSort
    {
        public BubbleSort()
        {
            Func<int, char, Transition> f = (state, symbol) =>
            {



                return new Transition(int.MinValue, Direction.Right);//undefined transition = fail;
            };
            tm = new TuringMachine(f);
        }
        TuringMachine tm;
    }
}
