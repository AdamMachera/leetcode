using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;

namespace Leetcode.Tests
{
    [TestClass]
    public class DivisionTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            dtim.Divide(1, 0);
        }

        [TestMethod]
        public void DivideEvenNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(32, 8);
            Assert.AreEqual(4, res);
        }


        [TestMethod]
        public void DivideWithRestNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(32, 9);
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void DivideByMinusWithRestNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-32, 1);
            Assert.AreEqual(-32, res);
        }

        [TestMethod]
        public void DivideByMinusWithRestDecimalNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(31, -3);
            Assert.AreEqual(-10, res);
        }

        [TestMethod]

        public void OverflowMinusNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-2147483648, -1);
            Assert.AreEqual(Int32.MaxValue, res);
        }

        [TestMethod]
        public void DivideBigNumbersNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(2147483647, 2);
            Assert.AreEqual(1073741823, res);
        }

        [TestMethod]
        public void DivideBigNumbers3Number()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(2147483647, 3);
            Assert.AreEqual(715827882, res);
        }

        [TestMethod]
        public void DivideStepByStep()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(1234, 36);
            Assert.AreEqual(34, res);
        }

        [TestMethod]
        public void DivideMediumNumbersNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(2147, 2);
            Assert.AreEqual(1073, res);
        }

        [TestMethod]
        public void DivideMaxMinusInt()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(Int32.MinValue, -1);
            Assert.AreEqual(Int32.MaxValue, res);
        }

        [TestMethod]
        public void DivideMedium2NumbersNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(20147, 7);
            Assert.AreEqual(2878, res);
        }

        [TestMethod]
        public void DivideMediumMinus2NumbersNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(20147, -7);
            Assert.AreEqual(-2878, res);
        }

        [TestMethod]
        public void DivideByMaxMinusNumber()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-1010369383, -2147483648);
            Assert.AreEqual(0, res);
        }


        [TestMethod]
        public void DivideOverflowTest()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(102137742, 1817624734);
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void DivideBigMinusNumberTest()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-2147483648, 2);
            Assert.AreEqual(-1073741824, res);
        }

        [TestMethod]
        public void DivideBigMinusByBigMinusNumberTest()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-2147483648, -1017100424);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void DivideBigMinusByBigMinusNumber2Test()
        {
            DivideTwoIntegersManager dtim = new DivideTwoIntegersManager();
            var res = dtim.Divide(-2147483648, -17100424);
            Assert.AreEqual(125, res);
        }
    }
}
