using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskBenner;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryExercise()
        {
            Network test = new Network(8);

            test.Connect(1, 2);
            test.Connect(3, 4);
            test.Connect(2, 5);
            test.Connect(5, 8);

            Assert.IsTrue(test.Query(2, 5));
            Assert.IsTrue(test.Query(5, 2));
            Assert.IsFalse(test.Query(6, 7));
            //Assert.IsFalse(test.Query(5, 7));
            //Assert.IsTrue(test.Query(1, 2));
            //Assert.IsTrue(test.Query(2, 5));
            //Assert.IsTrue(test.Query(1, 5));
            //Assert.IsTrue(test.Query(6, 2));
            //Assert.IsFalse(test.Query(7, 2));

        }
    }
}
