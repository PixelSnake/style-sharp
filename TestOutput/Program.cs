using StyleSharp;
using System;
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

            Console.ReadKey(true);
        }
    }
}
