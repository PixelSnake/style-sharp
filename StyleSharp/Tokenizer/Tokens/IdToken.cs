﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.Tokens
{
    internal class IdToken : Token
    {
        private static readonly string Pattern = @"^#(([a-zA-Z0-9]+[_-]?)+)$";

        public IdToken(string data) : base(data)
        {
            Match m = Match(data);
            if (!m.Success)
                throw new FormatException("The id name provided does not follow CSS id rules");

            Data = m.Groups[1].Value;
        }

        public static Match Match(string data)
        {
            return Regex.Match(data, Pattern);
        }
    }
}
