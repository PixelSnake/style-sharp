using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer
{
    public class StyleSet
    {
        public Tokens.ElementToken Element { get; }
        public RuleCollection Rules { get; }

        internal StyleSet(Tokens.ElementToken element, RuleCollection rules)
        {
            Element = element;
            Rules = rules;
        }
    }
}
