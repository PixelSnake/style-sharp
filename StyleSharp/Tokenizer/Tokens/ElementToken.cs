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
        internal string[] ClassNames { get; private set; }
        internal string[] Ids { get; private set; }

        public ElementToken(Token selector, Token className, Token id)
            : this(selector, new Token[] { className }, new Token[] { id }) { }

        public ElementToken(Token selector, Token[] classNames, Token[] ids)
            : base(
                  (selector != null ? selector.Data : "") +
                  (classNames != null && classNames.Length > 0 ? "." + String.Join<Token>(".", classNames) : "") +
                  (ids != null && ids.Length > 0 ? "#" + String.Join<Token>("#", ids) : "")
                  )
        {
            if (selector == null
                && (classNames == null || classNames.Length < 1)
                && (ids == null || ids.Length < 1))
                throw new FormatException("Empty selectors are not allowed");

            Selector = selector?.Data;

            var _ClassNames = new List<string>();
            foreach (var c in classNames)
                _ClassNames.Add(c.Data);
            ClassNames = _ClassNames.ToArray();

            var _Ids = new List<string>();
            foreach (var i in ids)
                _Ids.Add(i.Data);
            Ids = _Ids.ToArray();
        }

        public override string ToString()
        {
            return Selector
                + (ClassNames.Length > 0 ? "." + String.Join(".", ClassNames) : "")
                + (Ids.Length > 0 ? "#" + String.Join("#", Ids) : "");
        }
    }
}
