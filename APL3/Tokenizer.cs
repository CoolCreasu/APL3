using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL3
{
    internal class Tokenizer
    {
        private readonly string _source = string.Empty;

        public Tokenizer(string source)
        {
            _source = source.ReplaceLineEndings("\n");
        }
    }
}
