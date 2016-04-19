using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Tests
{
    [TestClass]
    public class AcceptsWordInFormat
    {
        public AcceptsWordInFormat()
        {
            Func<int, char, Transition> f = (state, symbol) =>
            {
                if (state == 0 && symbol.IsOneOf("abc")) //move to first 1
                    return new Transition(0, Direction.Right);
                else if (state == 0 && symbol == '1')
                    return new Transition(1, Direction.Right);
                else if (state == 0 && symbol == ' ')
                    return new Transition(4, Direction.Left);
                else if (state == 1 && symbol == '1') // check if theres only 1s after first 1
                    return new Transition(1, Direction.Right);
                else if (state == 1 && symbol.IsOneOf("abc"))
                    return new Transition(int.MinValue, Direction.Right);
                else if (state == 1 && symbol == ' ')
                    return new Transition(2, Direction.Left);
                else if (state == 2 && symbol == '1') //find 1
                    return new Transition(3, '2', Direction.Left);
                else if (state == 2 && symbol.IsOneOf("Aabc2"))
                    return new Transition(2, Direction.Right);
                else if (state == 2 && symbol == ' ')
                    return new Transition(4, Direction.Left); // check if there arent unmarked A's
                else if (state == 3 && symbol == 'a')
                    return new Transition(2, 'A', Direction.Right);
                else if (state == 3 && symbol.IsOneOf("Abc12"))
                    return new Transition(3, Direction.Left);
                else if (state == 3 && symbol == ' ')
                    return new Transition(int.MinValue, Direction.Left);
                else if (state == 4 && symbol == ' ')
                    return new Transition(int.MaxValue, Direction.Left);
                else if (state == 4 && symbol.IsOneOf("Abc2"))
                    return new Transition(4, Direction.Left);
                else if (state == 4 && symbol.IsOneOf("a1"))
                    return new Transition(int.MinValue, Direction.Left);

                return new Transition(int.MinValue, Direction.Right);//undefined transition = fail;
            };
            tm = new TuringMachine(f);
        }
        TuringMachine tm;

        [TestMethod]
        public void EmptyWord()
        {
            tm.ProcessWord("").AssertAccepted();
        }

        [TestMethod]
        public void a()
        {
            tm.ProcessWord("a").AssertRejected();
        }

        [TestMethod]
        public void a1()
        {
            tm.ProcessWord("a1").AssertAccepted();
        }

        [TestMethod]
        public void ba1()
        {
            tm.ProcessWord("ba1").AssertAccepted();
        }

        [TestMethod]
        public void abcba()
        {
            tm.ProcessWord("abcba").AssertRejected();
        }

        [TestMethod]
        public void aa1()
        {
            tm.ProcessWord("aa1").AssertRejected();
        }

        [TestMethod]
        public void a11()
        {
            tm.ProcessWord("a11").AssertRejected();
        }

        [TestMethod]
        public void bcaba111()
        {
            tm.ProcessWord("bcaba111").AssertRejected();
        }
        [TestMethod]
        public void abc1()
        {
            tm.ProcessWord("abc1").AssertAccepted();
        }
        [TestMethod]
        public void aaa111()
        {
            tm.ProcessWord("aaa111").AssertAccepted();
        }
        [TestMethod]
        public void aabbcc11()
        {
            tm.ProcessWord("aabbcc11").AssertAccepted();
        }

        [TestMethod]
        public void bcaba11()
        {
            tm.ProcessWord("bcaba11").AssertAccepted();
        }

        [TestMethod]
        public void bcaba11a()
        {
            tm.ProcessWord("bcaba11a").AssertRejected();
        }

        [TestMethod]
        public void bbb()
        {
            tm.ProcessWord("bbb").AssertAccepted();
        }
    }
}
