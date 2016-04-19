
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Tests
{
    public static class TuringMachineAssertExtensions
    {
        public static void AssertAccepted(this Tuple<int, string> r)
        {
            Assert.IsTrue(r.Item1 > 0);
        }

        public static void AssertRejected(this Tuple<int, string> r)
        {
            Assert.IsTrue(r.Item1 < 0);
        }
        public static void AssertProduced(this Tuple<int, string> r, string expected)
        {
            r.AssertAccepted();
            Assert.AreEqual(expected, r.Item2);
        }
    }
}
