using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.DOM
{
    public class DOMElement : IDOMElement
    {
        public string Selector => _selector;
        public string _selector;

        public IList<string> Classes => _classes;
        public IList<string> _classes;

        public IList<string> Ids => _ids;
        public IList<string> _ids;

        public RuleCollection Styles { get; set; }

        public IList<IDOMElement> Children => _children;
        public IList<IDOMElement> _children;

        public DOMElement(string selector) : this(selector, new string[] { }, new string[] { }) { }
        public DOMElement(string selector, IList<string> classes) : this(selector, classes, new string[] { }) { }
        public DOMElement(string selector, IList<string> classes, IList<string> ids)
        {
            _children = new List<IDOMElement>();
            Styles = new RuleCollection();

            _selector = selector;
            _classes = classes;
            _ids = ids;
        }
    }
}
