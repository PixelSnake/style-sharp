using System;
using System.IO;

namespace StyleSharp
{
    public abstract class Parser
    {
        public void OpenFile(string filename)
        {
            var data = File.ReadAllText(filename);
            Parse(data);
        }

        public abstract void Parse(string css);
    }
}
