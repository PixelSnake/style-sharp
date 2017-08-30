using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer
{
    internal class Tokenizer
    {
        private static readonly char[] Delimiters = { '.', '#', ',', ':', ' ', ';' };

        public string Data { get; private set; }
        public int Position { get; private set; }

        internal Tokenizer(string data)
        {
            Data = data;
        }

        internal Token GetNextToken()
        {
            if (Position + 2 >= Data.Length)
                return null;

            string buf = string.Empty;

            buf += Data[Position++];
            
            while(true)
            {
                if (Position + 1 >= Data.Length)
                    break;

                char c = Data[Position];

                if (Delimiters.Contains(c))
                    break;

                buf += c;
                Position++;
            }



            return buf.Length < 1 ? null : Token.CreateToken(buf.Trim());
        }
    }
}
