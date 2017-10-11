using StyleSharp;
using System;
using StyleSharp.DOM;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutput.TestClasses;

namespace TestOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new CSSParser();
            p.OpenFile("assets/test1.css");

            StyleSharp.DOM.DOMTree dom = new StyleSharp.DOM.DOMTree();
            dom.Root = new DOMElement("body");
            dom.Root.Children.Add(new DOMElement("span"));

            Console.ReadKey(true);
        }
    }
}
