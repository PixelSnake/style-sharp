using StyleSharp.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer
{
    internal abstract class Token
    {
        public string Data { get; protected set; }

        public Token(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"[{GetType().Name}: \"{Data}\"]";
        }

        public static Token CreateToken(string data)
        {
            if (TagToken.Matches(data))
                return new TagToken(data);
            else if (ClassToken.Match(data).Success)
                return new ClassToken(data);
            else if (IdToken.Match(data).Success)
                return new IdToken(data);
            else
                return null;
        }
    }
}
