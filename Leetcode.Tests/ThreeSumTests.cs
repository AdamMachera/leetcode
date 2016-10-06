using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;

namespace Leetcode.Tests
{
    [TestClass]
    public class ThreeSumTests
    {
        [TestMethod]
        public void TestOne()
        {
            
            int[] items = new int[] { -1, 0, 1, 2, -1, -4 };
            ThreeSumManager mgr = new ThreeSumManager();
            var res = mgr.ThreeSum(items);

            Assert.IsTrue(res.Count(x => x[0] == -1 && x[1] == 0 && x[2] == 1) == 1);
            Assert.IsTrue(res.Count(x => x[0] == -1 && x[1] == -1 && x[2] == 2) == 1);
            Assert.IsTrue(res.Count() == 2);
        }

        [TestMethod]
        public void TestLargest()
        {
            int[] items = new int[] { 8, -15, -2, -13, 8, 5, 6, -3, -9, 3, 6, -6, 8, 14, -9, -8, -9, -6, -14, 5, -7, 3, -10, -14, -12, -11, 12, -15, -1, 12, 8, -8, 12, 13, -13, -3, -5, 0, 10, 2, -11, -7, 3, 4, -8, 9, 3, -10, 11, 5, 10, 11, -7, 7, 12, -12, 3, 1, 11, 9, -9, -4, 9, -12, -6, 11, -7, 4, -4, -12, 13, -8, -12, 2, 3, -13, -12, -8, 14, 14, 12, 9, 10, 12, -6, -1, 8, 4, 8, 4, -1, 14, -15, -7, 9, -14, 11, 9, 5, 14 };
            ThreeSumManager mgr = new ThreeSumManager();
            var res = mgr.ThreeSum(items);

            Assert.IsTrue(res.Count(x => x[0] == -15 && x[1] == 1 && x[2] == 14) == 1);
            //Assert.IsTrue(res.Count(x => x[0] == -1 && x[1] == -1 && x[2] == 2) == 1);
            //Assert.IsTrue(res.Count() == 2);
        }

        [TestMethod]
        public void TestZeros()
        {
            int[] items = new int[] { 0, 0, 0 };
            ThreeSumManager mgr = new ThreeSumManager();
            var res = mgr.ThreeSum(items);

            Assert.IsTrue(res.Count(x => x[0] == 0 && x[1] == 0 && x[2] == 0) == 1);
            Assert.IsTrue(res.Count() == 1);
        }

        [TestMethod]
        public void TestLessThen3Items()
        {
            int[] items = new int[] { 0, 0 };
            ThreeSumManager mgr = new ThreeSumManager();
            var res = mgr.ThreeSum(items);
            Assert.IsTrue(res.Count() == 0);
        }
    }
}
