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
            ApplyStyleToElement(Root, s);
        }

        protected void ApplyStyleToElement(IDOMElement e, StyleSheet s)
        {
            foreach (var style in s)
            {
                if (e.Selector == style.Selector.Selector)
                {
                    // todo check classes and ids
                    e.Styles = style;
                    ApplyStyleToChildren(e, s);
                }
            }
        }

        protected void ApplyStyleToChildren(IDOMElement e, StyleSheet s)
        {
            foreach (var c in e.Children)
                ApplyStyleToElement(c, s);
        }
    }
}
