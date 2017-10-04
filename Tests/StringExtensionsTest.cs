using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleSharp.Tokenizer.Extensions;

namespace Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void GetClosingScopeTrueTest1()
        {
            int c = "{     }".GetClosingScope(0);
            Assert.AreEqual(6, c);
        }

        [TestMethod]
        public void GetClosingScopeTrueTest2()
        {
            int c = "{   }".GetClosingScope(0);
            Assert.AreEqual(4, c);
        }

        [TestMethod]
        public void GetClosingScopeTrueTest3()
        {
            int c = "{  {{{{   }}{}{     }}fffffff{}  ()()()()   [][][]   }}".GetClosingScope(0);
            Assert.AreEqual(54, c);
        }
    }
}
