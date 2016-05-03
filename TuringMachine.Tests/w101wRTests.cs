using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Tests
{
    [TestClass]
    public class w101wRTests
    {
        public w101wRTests()
        {
            Func<int, char, Transition> f = (state, symbol) =>
            {

                if (state == 0 && symbol == '0')
                    return new Transition(1, '2', Direction.Right);
                else if (state == 0 && symbol == '1')
                    return new Transition(2, '3', Direction.Right);

                else if (state == 1 && symbol.IsOneOf("01")) //we remember 0
                    return new Transition(1, Direction.Right);
                else if (state == 1 && symbol.IsOneOf("23 "))
                    return new Transition(3, Direction.Left);

                else if (state == 2 && symbol.IsOneOf("01")) //we remember 1
                    return new Transition(2, Direction.Right);
                else if (state == 2 && symbol.IsOneOf("23 "))
                    return new Transition(4, Direction.Left);

                else if (state == 3 && symbol == '0')
                    return new Transition(5, '2', Direction.Left);
                else if (state == 3 && symbol == '1')
                    return new Transition(int.MinValue, Direction.Left);
                else if (state == 3 && symbol == '2')
                    return new Transition(6, Direction.Left);

                else if (state == 4 && symbol == '0')
                    return new Transition(int.MinValue, Direction.Left);
                else if (state == 4 && symbol == '1')
                    return new Transition(5, '3', Direction.Left);

                else if (state == 5 && symbol.IsOneOf("01"))
                    return new Transition(5, Direction.Left);
                else if (state == 5 && symbol.IsOneOf("23 "))
                    return new Transition(0, Direction.Right);

                else if (state == 6 && symbol == '3')
                    return new Transition(int.MaxValue, Direction.Right);
                return new Transition(int.MinValue, Direction.Right);
            };
            tm = new TuringMachine(f);
        }

        TuringMachine tm;

        [TestMethod]
        public void EmptyWord()
        {
            tm.ProcessWord("").AssertRejected();
        }

        [TestMethod]
        public void w0110110()
        {
            tm.ProcessWord("0110110").AssertAccepted();
        }

        [TestMethod]
        public void w0100010()
        {
            tm.ProcessWord("0100010").AssertRejected();
        }

        [TestMethod]
        public void w0110111()
        {
            tm.ProcessWord("0110111").AssertRejected();
        }
        [TestMethod]
        public void w0100110()
        {
            tm.ProcessWord("0100110").AssertRejected();
        }

        [TestMethod]
        public void w0110010()
        {
            tm.ProcessWord("0110010").AssertRejected();
        }


        [TestMethod]
        public void w0111110()
        {
            tm.ProcessWord("0111110").AssertRejected();
        }

        [TestMethod]
        public void w01100110()
        {
            tm.ProcessWord("01100110").AssertRejected();
        }
    }
}
