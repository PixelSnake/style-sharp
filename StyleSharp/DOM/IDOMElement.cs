using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSharp.DOM
{
    public interface IDOMElement
    {
        string Selector { get; }
        IList<string> Classes { get; }
        IList<string> Ids { get; }

        StyleSet Styles { get; set; }

        IEnumerable<IDOMElement> Children { get; }
    }
}
