using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyleSharp.Tokenizer.Extensions;

namespace StyleSharp.Tokenizer
{
    internal class Tokenizer
    {
        private static readonly char[] Delimiters = { '.', '#', ',', ':', ' ', ';', '{', '}' };

        public string Data { get; private set; }
        public int Position { get; private set; }

        internal Tokenizer(string data)
        {
            Data = data;
        }

        internal StyleSet GetNextStyleSet()
        {
            while (true)
            {
                try
                {
                    var selector = GetNextSelector();
                    var rules = GetNextRules();

                    foreach (var r in rules)
                    {
                        Console.WriteLine(r.Key + ":" + r.Value);
                    }

                    return new StyleSet(selector, rules);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        internal RuleCollection GetNextRules()
        {
            if (Position >= Data.Length)
                throw new FormatException();

            char c;
            while (Position + 1 < Data.Length && (c = Data[Position]) != '{')
                Position++;

            var scopeEnd = Data.GetClosingScope(Position);
            var scope = Data.Substring(Position + 1, scopeEnd - Position - 1).Trim();
            Position = scopeEnd + 1;

            int i = 0;
            string buf = "";

            RuleCollection rules = new RuleCollection();
            string Property = "";

            while (true)
            {
                if (i >= scope.Length)
                    break;

                c = scope[i++];

                if (Delimiters.Contains(c) && !char.IsWhiteSpace(c))
                {
                    if (buf.Length < 1)
                        throw new FormatException($"Unexpected delimiter \"{c}\"");

                    switch (c)
                    {
                        case ':':
                            Property = buf.Trim();
                            break;

                        case ';':
                            if (Property.Length < 1)
                                throw new FormatException("Unexpected ;");

                            string Value = buf.Trim();

                            StyleValue.StyleValue val;
                            StyleValue.StyleValueParser.TryParse(buf, out val);

                            if (val == null)
                                Console.WriteLine($"Could not parse \"{Value}\" - no matching parser found");
                            else
                                rules.Add(Property, val);

                            Property = "";
                            break;
                    }

                    buf = "";
                }
                else
                {
                    buf += c;
                }
            }

            return rules;
        }

        internal Tokens.ElementToken GetNextSelector()
        {
            if (Position >= Data.Length)
                throw new FormatException();

            string buf = string.Empty;
            var Tokens = new List<Token>();

            buf += Data[Position++];

            while (true)
            {
                if (Position >= Data.Length)
                    break;

                char c = Data[Position];

                //Console.WriteLine(buf);
                if (Delimiters.Contains(c))
                {
                    Tokens.Add(Token.CreateToken(buf.Trim()));
                    buf = "";

                    switch (c)
                    {
                        case '.':
                        case '#':
                        case ':':
                            break;

                        /* definition of an element selector is finished */
                        default:
                            //Console.WriteLine(Tokens.Count);

                            if (Tokens.Count < 1)
                                break;

                            Tokens.ElementNameToken selector = null;
                            var classNames = new List<Tokens.ClassToken>();
                            var ids = new List<Tokens.IdToken>();

                            foreach (Token t in Tokens)
                            {
                                switch (t)
                                {
                                    case Tokens.ElementNameToken _t:
                                        selector = (selector == null ? _t : throw new FormatException("Unexpected ElementToken"));
                                        break;

                                    case Tokens.ClassToken _t:
                                        classNames.Add(_t);
                                        break;

                                    case Tokens.IdToken _t:
                                        ids.Add(_t);
                                        break;
                                }
                            }

                            return new Tokens.ElementToken(selector, classNames.ToArray(), ids.ToArray());
                    }
                }

                buf += c;
                Position++;
            }

            //if (buf.Length < 1)
                throw new FormatException("Unexpected EOF");
        }
    }
}
