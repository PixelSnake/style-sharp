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
        bool Outside = true;
        
        public override void Parse(string css)
        {
            Console.WriteLine("Parsing...");

            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer(css);
            StyleSet s;
            while ((s = t.GetNextStyleSet()) != null)
            {
                //Console.WriteLine($"{s.Element} has {s.Rules.Count} style rule(s)");
            }
        }
    }
}
