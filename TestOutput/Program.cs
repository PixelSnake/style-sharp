using StyleSharp;
using System;
using StyleSharp.DOM;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new CSSParser();
            p.OpenFile("assets/test1.css");

            StyleSharp.DOM.DOMTree dom = new StyleSharp.DOM.DOMTree();
            //dom.Root = new IDOMElement();

            Console.ReadKey(true);
        }
    }
}
