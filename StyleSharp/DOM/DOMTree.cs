using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.DOM
{
    public class DOMTree
    {
        public IDOMElement Root { get; set; }

        public DOMTree()
        {

        }

        public void ApplyStyleSheet(StyleSheet s)
        {
            ApplyStyleSheetToElement(Root, s);
        }

        protected void ApplyStyleSheetToElement(IDOMElement e, StyleSheet s)
        {
            Console.WriteLine("Applying all to Element " + e.Selector);

            foreach (var style in s)
            {
                ApplyStyleSetToElement(e, style);
            }

            ApplyStyleToChildren(e, s);
        }

        protected void ApplyStyleSetToElement(IDOMElement e, StyleSet style)
        {
            if (e.Selector == style.Selector.Selector)
            {
                foreach (var c in style.Selector.ClassNames)
                    if (!style.Selector.HasClass(c))
                        return;
                foreach (var i in style.Selector.Ids)
                    if (!style.Selector.HasId(i))
                        return;

                Console.WriteLine("style " + style.Selector + " matches on " + e.Selector);

                e.Styles = new RuleCollection();
                foreach (var r in style.Rules)
                {
                    if (!e.Styles.ContainsKey(r.Key) || !e.Styles[r.Key].IsImportant)
                    {
                        e.Styles.Add(r.Key, r.Value);
                        Console.WriteLine("adding " + r.Key + " : " + r.Value);
                        continue;
                    }
                }
            }
        }

        protected void ApplyStyleToChildren(IDOMElement e, StyleSheet s)
        {
            foreach (var c in e.Children)
                ApplyStyleSheetToElement(c, s);
        }
    }
}
