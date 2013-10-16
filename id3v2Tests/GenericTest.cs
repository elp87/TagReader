using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class GenericTest
    {
        [TestMethod]
        public void TestGenericAdd()
        {
            int[] testArray = new int[] { 1, 2, 3, 4 };
            int[] expArray = new int[] { 1, 2, 3, 4, 5 };

            testArray = Generic.Add(testArray, 5);

            CollectionAssert.AreEqual(expArray, testArray);
        }
    }
}
