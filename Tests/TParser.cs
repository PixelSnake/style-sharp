using System;
using StyleSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TParser
    {
        [TestMethod]
        public void Test1()
        {
            Parser p = new CSSParser();
            p.OpenFile("assets/test1.css");
        }
    }
}
