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
        private int _lineIndex = default;
        private int _columnIndex = default;

        public Tokenizer(string source)
        {
            _source = source.ReplaceLineEndings("\n");
            _currentCharacter = string.IsNullOrEmpty(_source) ? '\0' : _source[_currentIndex];
            _lineIndex = 1; // 1 because text editors
            _columnIndex = 1; // 1 cause else you end up on 1 before

            while (_currentCharacter != '\0')
            {
                GetTokens();
            }
        }

        private void Advance()
        {
            _currentIndex++;    // Iterate the absolute index.
            _columnIndex++;    // Iterate the index of the character on this current line.

            if (_currentIndex >= _source.Length)
            {
                // We reached the end of the source string so EOF is the current character.
                _currentCharacter = '\0';
            }
            else
            {
                // The current character is what is currently at the index.
                _currentCharacter = _source[_currentIndex];
            }

            if (_currentCharacter == '\n')
            {
                // We reached a new line so iterate the line index.
                _lineIndex++;
                _columnIndex = 1;
            }
        }

        private void GetTokens()
        {
            Token token = new Token();
            StringBuilder tokenName = new StringBuilder();

            if (char.IsLetter(_currentCharacter))
            {
                token.Line = _lineIndex;
                token.Column = _columnIndex;
                while (char.IsLetter(_currentCharacter))
                {
                    tokenName.Append(_currentCharacter);
                    Advance();
                }
                token.Name = tokenName.ToString();
                Console.WriteLine(token);
            }
            else
            {
                Advance();
            }
        }
    }
}
