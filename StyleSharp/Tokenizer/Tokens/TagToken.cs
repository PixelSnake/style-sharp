using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.Tokens
{
    internal class TagToken : Token
    {
        private static readonly string Pattern = @"^[a-zA-Z0-9_-]+$";

        public TagToken(string data) : base(data)
        {
            if (!Matches(data))
                throw new FormatException("The tag name provided does not follow CSS tag rules");

            Data = data;
        }

        public static bool Matches(string data)
        {
            return Regex.Match(data, Pattern).Success;
        }
    }
}
