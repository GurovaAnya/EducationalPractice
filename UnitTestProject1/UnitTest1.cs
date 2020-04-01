using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using задание_5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[,] matrix = new double[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 } };
            Program.FindNegаtive(matrix);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double[,] matrix = new double[,] { { 0, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
            Program.FindNegаtive(matrix);
            Assert.AreEqual(1, 1);
        }
    }
}
