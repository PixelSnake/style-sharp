using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.Tokens
{
    public class ElementToken : Token
    {
        internal string Selector { get; private set; }
        internal HashSet<string> ClassNames { get; private set; }
        internal HashSet<string> Ids { get; private set; }

        public ElementToken(Token selector, Token className, Token id)
            : this(selector, new Token[] { className }, new Token[] { id }) { }

        public ElementToken(Token selector, Token[] classNames, Token[] ids)
            : base(BuildSelectorString(selector, classNames, ids))
        {
            if (selector == null
                && (classNames == null || classNames.Length < 1)
                && (ids == null || ids.Length < 1))
                throw new FormatException("Empty selectors are not allowed");

            Selector = selector?.Data;

            ClassNames = new HashSet<string>();
            foreach (var c in classNames)
                ClassNames.Add(c.Data);

            Ids = new HashSet<string>();
            foreach (var i in ids)
                Ids.Add(i.Data);
        }

        public bool HasClass(string s)
        {
            return ClassNames.Contains(s);
        }

        public bool HasId(string s)
        {
            return Ids.Contains(s);
        }

        private static string BuildSelectorString(Token Selector, Token[] ClassNames, Token[] Ids)
        {
            return Selector
                + (ClassNames.Length > 0 ? "." + String.Join<Token>(".", ClassNames) : "")
                + (Ids.Length > 0 ? "#" + String.Join<Token>("#", Ids) : "");
        }
    }
}
