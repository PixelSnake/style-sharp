using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StyleSharp.Tokenizer.StyleValue
{
    public class SingleDimensionValue : StyleValue
    {
        public static string RegexString => "([0-9]+)([a-zA-Z%*]*)";

        public float Value { get; protected set; }
        public Unit Unit { get; protected set; }

        internal SingleDimensionValue(float value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        internal static Match Match(string s)
        {
            return Regex.Match(s, RegexString);
        }
    }

    public class SingleDimensionValueParser : StyleValueParser
    {
        private static SingleDimensionValueParser _instance = new SingleDimensionValueParser();
        public static SingleDimensionValueParser Instance => _instance;

        public override Match Match(string s) => SingleDimensionValue.Match(s);

        public override StyleValue Parse(String s)
        {
            var m = SingleDimensionValue.Match(s);
            if (!m.Success)
                throw new FormatException("Invalid format for " + GetType().Name);

            var value = float.Parse(m.Groups[1].Value);
            var u = m.Groups[2].Value.Trim().ToLower();
            Unit unit;

            if (u == "%")
                unit = Unit.Percent;
            else
                unit = Unit.Pixel;

            return new SingleDimensionValue(value, unit);
        }
    }
}
