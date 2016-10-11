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


        [TestMethod]
        public void IsOnlyE()
        {
            string val = "e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnBegining()
        {
            string val = "e14";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnEnd()
        {
            string val = "14e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnBeginingWithPlus()
        {
            string val = "+14e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnBeginingWithMinus()
        {
            string val = "-14e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnEndWithPlus()
        {
            string val = "+14e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyEOnEndWithMinus()
        {
            string val = "-14e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyOneValidEMinus()
        {
            string val = "-14e1";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsTwoInvalidEMinus()
        {
            string val = "-14ee1";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsOnlyDot()
        {
            string val = ".";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsDotWithPreceedingNumber()
        {
            string val = "5.";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsTwoDotWithPreceedingNumber()
        {
            string val = "5..";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsNumberWithWhitespacesOnEnd()
        {
            string val = " 5 ";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsNumberWithWhitespacesOnEnd2()
        {
            string val = " 5.  ";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsDotWithEpsilon()
        {
            string val = ".e1";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsDotWithEpsilonAndPlus()
        {
            string val = " +.e1";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsDotWithEpsilonAndDotAtTheEnd()
        {
            string val = " 1e.1";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void OnlyPluses()
        {
            string val = "+++";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void MinusDotAndV()
        {
            string val = "-.V";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void NumberDotAndEpsilonAndInteger()
        {
            string val = "46.e3";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void NumberDotIntegerAndEpsilonAndInteger()
        {
            string val = "46.2e3";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void NumberDotAndEpsilon()
        {
            string val = "46.e";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void DotNumberAndEpsilonInteger()
        {
            string val = ".2e81";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void EpsilonPlusNumber()
        {
            string val = " 005047e+6";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void EpsilonMinusNumber()
        {
            string val = " 005047e-6";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IntegerEpsilonPlus()
        {
            string val = "4e+";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IntegerDotMinusInteger()
        {
            string val = "32.e-80123";
            IsNumberManager mgr = new IsNumberManager();
            var res = mgr.IsNumber(val);
            Assert.IsTrue(res);
        }
    }
}
