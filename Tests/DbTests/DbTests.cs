using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace DbTests
{
    [TestClass]
    public class DbTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var hallo = new BusinessContext())
            {

            }
        }
    }
}
