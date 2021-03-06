﻿using StyleSharp.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer
{
    public abstract class Token
    {
        public string Data { get; protected set; }

        public Token(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data;
        }

        public static Token CreateToken(string data)
        {
            if (ElementNameToken.Match(data).Success)
                return new ElementNameToken(data);
            else if (ClassToken.Match(data).Success)
                return new ClassToken(data);
            else if (IdToken.Match(data).Success)
                return new IdToken(data);
            else
                return null;
        }
    }
}
