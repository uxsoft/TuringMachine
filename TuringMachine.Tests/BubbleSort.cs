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
                if (state == 0 && symbol == ' ')
                    return new Transition(int.MaxValue, Direction.Right);
                else if (state == 0 && symbol == 'a')
                    return new Transition(1, Direction.Right);
                else if (state == 0 && symbol == 'b')
                    return new Transition(2, Direction.Right);
                else if (state == 0 && symbol == 'c')
                    return new Transition(3, Direction.Right);
                else if (state == 0 && symbol == 'A')
                    return new Transition(8, 'a', Direction.Right);
                else if (state == 0 && symbol == 'B')
                    return new Transition(8, 'b', Direction.Right);
                else if (state == 0 && symbol == 'C')
                    return new Transition(8, 'c', Direction.Right);
                else if (state == 1 && symbol == 'a')
                    return new Transition(1, Direction.Right);
                else if (state == 1 && symbol == 'b')
                    return new Transition(2, Direction.Right);
                else if (state == 1 && symbol == 'c')
                    return new Transition(3, Direction.Right);
                else if (state == 1 && symbol.IsOneOf(" ABC"))
                    return new Transition(6, Direction.Left);
                else if (state == 2 && symbol == 'a')
                    return new Transition(4, 'b', Direction.Left);
                else if (state == 2 && symbol == 'b')
                    return new Transition(2, Direction.Right);
                else if (state == 2 && symbol == 'c')
                    return new Transition(3, Direction.Right);
                else if (state == 2 && symbol.IsOneOf(" ABC"))
                    return new Transition(6, Direction.Left);
                else if (state == 3 && symbol == 'a')
                    return new Transition(4, 'c', Direction.Left);
                else if (state == 3 && symbol == 'b')
                    return new Transition(5, 'c', Direction.Left);
                else if (state == 3 && symbol == 'c')
                    return new Transition(3, Direction.Right);
                else if (state == 3 && symbol.IsOneOf(" ABC"))
                    return new Transition(6, Direction.Left);
                else if (state == 4 && symbol.IsOneOf("abc"))
                    return new Transition(0, 'a', Direction.Right);
                else if (state == 5 && symbol.IsOneOf("abc"))
                    return new Transition(0, 'b', Direction.Right);
                else if (state == 6 && symbol == 'a')
                    return new Transition(7, 'A', Direction.Left);
                else if (state == 6 && symbol == 'b')
                    return new Transition(7, 'B', Direction.Left);
                else if (state == 6 && symbol == 'c')
                    return new Transition(7, 'C', Direction.Left);
                else if (state == 7 && symbol.IsOneOf("abc"))
                    return new Transition(7, Direction.Left);
                else if (state == 7 && symbol == ' ')
                    return new Transition(0, Direction.Right);
                else if (state == 8 && symbol == 'A')
                    return new Transition(8, 'a', Direction.Right);
                else if (state == 8 && symbol == 'B')
                    return new Transition(8, 'b', Direction.Right);
                else if (state == 8 && symbol == 'C')
                    return new Transition(8, 'c', Direction.Right);
                else if (state == 8 && symbol == ' ')
                    return new Transition(int.MaxValue, Direction.Right);


                return new Transition(int.MinValue, Direction.Right); //undefined transition = fail;
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
        public void cba()
        {
            tm.ProcessWord("cba").AssertProduced("abc");

        }

        [TestMethod]
        public void ccba()
        {
            tm.ProcessWord("ccba").AssertProduced("abcc");
        }

        [TestMethod]
        public void abc()
        {
            tm.ProcessWord("abc").AssertProduced("abc");
        }

        [TestMethod]
        public void aaa()
        {
            tm.ProcessWord("aaa").AssertProduced("aaa");
        }

        [TestMethod]
        public void caba()
        {
            tm.ProcessWord("caba").AssertProduced("aabc");
        }
    }
}
