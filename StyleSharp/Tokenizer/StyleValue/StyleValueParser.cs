using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.StyleValue
{
    public abstract class StyleValueParser
    {
        protected static List<StyleValueParser> Parsers = new List<StyleValueParser>()
        {
            SingleDimensionValueParser.Instance
        };

        public static void RegisterParser(StyleValueParser p)
        {
            Parsers.Add(p);
        }

        public abstract StyleValue Parse(string s);
        public abstract Match Match(string s);

        public static bool TryParse(string s, out StyleValue v)
        {
            foreach (var p in Parsers)
            {
                if (p.Match(s).Success)
                {
                    v = p.Parse(s);
                    return true;
                }
            }

            v = null;
            return false;
        }
    }
}
