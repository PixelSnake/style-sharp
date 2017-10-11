using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleSharp;
using StyleSharp.DOM;
using StyleSharp.Tokenizer.StyleValue;

namespace Tests
{
    [TestClass]
    public class DOMTreeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Parser p = new CSSParser();
            var stylesheet = p.Parse("span { width: 50px; height: 3%; }");

            StyleSharp.DOM.DOMTree dom = new StyleSharp.DOM.DOMTree();
            dom.Root = new DOMElement("body");
            dom.Root.Children.Add(new DOMElement("span"));
            dom.ApplyStyleSheet(stylesheet);

            Assert.AreEqual("span", dom.Root.Children[0].Selector);
            Assert.AreEqual(new SingleDimensionValue(50.0f, Unit.Pixel), dom.Root.Children[0].Styles["width"]);
            Assert.AreEqual(new SingleDimensionValue(3.0f, Unit.Percent), dom.Root.Children[0].Styles["height"]);
        }
    }
}
