using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //internal Token GetNextToken()
        //{
        //    if (Position + 2 >= Data.Length)
        //        return null;

        //    string buf = string.Empty;
        //    buf += Data[Position++];

        //    while (true)
        //    {
        //        if (Position + 1 >= Data.Length)
        //            break;

        //        char c = Data[Position];

        //        Console.WriteLine(buf);
        //        if (Delimiters.Contains(c))
        //        {
        //            Tokens.Add(Token.CreateToken(buf.Trim()));
        //            buf = "";

        //            switch (c)
        //            {
        //                /* definition of an element selector is finished */
        //                case ' ':
        //                    Console.WriteLine(Tokens.Count);

        //                    if (Tokens.Count < 1)
        //                        break;

        //                    Tokens.ElementNameToken selector = null;
        //                    var classNames = new List<Tokens.ClassToken>();
        //                    var ids = new List<Tokens.IdToken>();

        //                    foreach (Token t in Tokens)
        //                    {
        //                        switch (t)
        //                        {
        //                            case Tokens.ElementNameToken _t:
        //                                selector = (selector == null ? _t : throw new ArgumentException("Unexpected ElementToken"));
        //                                break;

        //                            case Tokens.ClassToken _t:
        //                                classNames.Add(_t);
        //                                break;

        //                            case Tokens.IdToken _t:
        //                                ids.Add(_t);
        //                                break;
        //                        }
        //                    }

        //                    return new Tokens.ElementToken(selector, classNames.ToArray(), ids.ToArray());
        //            }
        //        }

        //        buf += c;
        //        Position++;
        //    }

        //    if (buf.Length < 1)
        //        throw new ArgumentException("Unexpected EOF");
        //}

        internal Tokens.ElementToken GetNextSelector()
        {
            if (Position + 2 >= Data.Length)
                throw new FormatException();

            string buf = string.Empty;
            var Tokens = new List<Token>();

            buf += Data[Position++];

            while (true)
            {
                if (Position + 1 >= Data.Length)
                    break;

                char c = Data[Position];

                Console.WriteLine(buf);
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
                            Console.WriteLine(Tokens.Count);

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
                                        selector = (selector == null ? _t : throw new ArgumentException("Unexpected ElementToken"));
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
