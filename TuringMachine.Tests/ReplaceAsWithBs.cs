using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TuringMachine.Tests
{
    [TestClass]
    public class ReplaceAsWithBs
    {
        public ReplaceAsWithBs()
        {
            Func<int, char, Transition> f = (state, symbol) =>
            {

                if (state == 0 && symbol == ' ')
                    return new Transition(int.MaxValue, Direction.Right);
                else if (state == 0 && symbol == 'a')
                    return new Transition(0, 'b', Direction.Right);
                return new Transition(0, Direction.Right);
            };
            tm = new TuringMachine(f);
        }

        TuringMachine tm;

        [TestMethod]
        public void EmptyWord()
        {
            tm.ProcessWord("").AssertProduced("");
        }

        [TestMethod]
        public void SimpleWord()
        {
            tm.ProcessWord("a").AssertProduced("b");
        }

        [TestMethod]
        public void MediumWord()
        {
            tm.ProcessWord("abab").AssertProduced("bbbb");
        }

        [TestMethod]
        public void ComplexWord()
        {
            tm.ProcessWord("akjsdjdajisiaijdioaodiosad").AssertProduced("bkjsdjdbjisibijdiobodiosbd");
        }
    }
}
