using StyleSharp.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp
{
    public class CSSParser : Parser
    {
        public override StyleSheet Parse(string css)
        {
            Console.WriteLine("Parsing...");

            StyleSheet sheet = new StyleSheet();
            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer(css);
            StyleSet s;
            while ((s = t.GetNextStyleSet()) != null)
            {
                sheet.Add(s);
            }

            return sheet;
        }
    }
}
