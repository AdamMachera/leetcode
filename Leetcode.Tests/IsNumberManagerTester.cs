using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode.Tests
{
    [TestClass]
    public class IsNumberManagerTester
    {
        [TestMethod]
        public void IsNumberContainingOnlyNumbers()
        {
            string val = "1234567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }


        [TestMethod]
        public void IsNumberContainingWhitespaces()
        {
            string val = "   1234567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNumberContainingWhitespacesAndMinus()
        {
            string val = "   -1234567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNotNumberContainingWhitespacesAndPlus()
        {
            string val = "   +1234567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNotNumberContainingWhitespacesAndPlusAndLetter()
        {
            string val = "   +12a34567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsNotNumberContainingWhitespacesInMiddle()
        {
            string val = "   +12 34567890";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsNotNumberContainingColon()
        {
            string val = "3:09";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsNumberContainingOneDot()
        {
            string val = "323123.12321321312319";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNumberContainingOneEpsilon()
        {
            string val = "323123e12321321312319";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNotNumberContainingOneEpsilon()
        {
            string val = "323123e1232132e1312319";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsNotNumberContainingOnlyWhitespace()
        {
            string val = " ";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }
    }
}
