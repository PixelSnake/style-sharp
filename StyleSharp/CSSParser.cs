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
            Console.WriteLine("Parsing");

            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer(css);
            Tokenizer.Token token;
            while ((token = t.GetNextToken()) != null)
            {
                Console.WriteLine(token);

                if (Outside)
                {
                    var classes = new List<string>();
                    
                }
                else
                {

                }
            }
        }
    }
}
