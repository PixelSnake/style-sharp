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
            Console.WriteLine(t.GetNextSelector());
        }
    }
}
