using System;
using System.Collections.Generic;
using System.IO;

namespace StyleSharp
{
    public abstract class Parser
    {
        internal List<Tokenizer.Token> Tokens { get; private set; }

        public void OpenFile(string filename)
        {
            var data = File.ReadAllText(filename);
            Parse(data);
        }

        public abstract void Parse(string css);
    }
}
