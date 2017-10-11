using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.StyleValue
{
    public abstract class StyleValue
    {
        public bool IsImportant { get; set; }
    }
}
