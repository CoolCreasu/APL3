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
        private char _currentCharacter = default;
        private int _currentIndex = default;

        public Tokenizer(string source)
        {
            _source = source.ReplaceLineEndings("\n");
            _currentCharacter = _source.Length > 0 ? _source[_currentIndex] : '\0';
        }
    }
}
