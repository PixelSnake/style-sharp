using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.Extensions
{
    public static class StringExtensions
    {
        public static int GetClosingScope(this String s, int position)
        {
            char openingBracket = s[position];
            char closingBracket;

            switch (openingBracket)
            {
                case '{':
                    closingBracket = '}';
                    break;

                case '[':
                    closingBracket = ']';
                    break;

                case '(':
                    closingBracket = ')';
                    break;

                default:
                    throw new ArgumentException("The character at the given position is not an opening bracket");
            }

            int brackCount = 0;

            while (true)
            {
                if (position + 1 > s.Length)
                    return -1;

                char c = s[position];
                if (c == openingBracket) brackCount++;
                if (c == closingBracket) brackCount--;

                if (brackCount == 0)
                    return position;
                position++;
            }
        }
    }
}
