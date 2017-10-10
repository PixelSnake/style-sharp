using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp
{
    public class StyleSet
    {
        public Tokenizer.Tokens.ElementToken Selector { get; }
        public Tokenizer.RuleCollection Rules { get; }

        internal StyleSet(Tokenizer.Tokens.ElementToken element, Tokenizer.RuleCollection rules)
        {
            Selector = element;
            Rules = rules;
        }
    }
}
