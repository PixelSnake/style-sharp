using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleSharp;

namespace Tests
{
    [TestClass]
    public class TokenizerTest
    {
        [TestMethod]
        public void TrueTest1()
        {
            var t = new StyleSharp.Tokenizer.Tokenizer("selector{}");
            Assert.AreEqual("selector", t.GetNextSelector().ToString());
        }

        [TestMethod]
        public void TrueTest2()
        {
            var t = new StyleSharp.Tokenizer.Tokenizer("selector {\n}");
            Assert.AreEqual("selector", t.GetNextSelector().ToString());
        }

        [TestMethod]
        public void TrueTest3()
        {
            var t = new StyleSharp.Tokenizer.Tokenizer("selector.class1.class2.class3#id1#id2#id3 {}");
            Assert.AreEqual("selector.class1.class2.class3#id1#id2#id3", t.GetNextSelector().ToString());
        }

        [TestMethod]
        public void ErrorTestNoSelector()
        {
            try
            {
                var t = new StyleSharp.Tokenizer.Tokenizer("{}");
                t.GetNextSelector();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }

        [TestMethod]
        public void ErrorTestDotWithoutClassName()
        {
            try
            {
                var t = new StyleSharp.Tokenizer.Tokenizer("selector. {}");
                t.GetNextSelector();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }

        [TestMethod]
        public void ErrorTestDotWithoutClassName2()
        {
            try
            {
                var t = new StyleSharp.Tokenizer.Tokenizer("selector#id. {}");
                t.GetNextSelector();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }

        [TestMethod]
        public void ErrorTestHashWithoutId()
        {
            try
            {
                var t = new StyleSharp.Tokenizer.Tokenizer("selector# {}");
                t.GetNextSelector();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }

        [TestMethod]
        public void ErrorTestHashWithoutId2()
        {
            try
            {
                var t = new StyleSharp.Tokenizer.Tokenizer("selector.class# {}");
                t.GetNextSelector();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(FormatException));
            }
        }
    }
}
