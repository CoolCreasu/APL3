using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL3
{
    internal class Lexer
    {
        private readonly string _source = string.Empty;
        private char _currentCharacter = default;
        private int _currentIndex = default;
        private int _columnIndex = default;
        private int _lineIndex = default;

        public Lexer(string source)
        {
            _source = source.ReplaceLineEndings("\n");
            _currentCharacter = string.IsNullOrEmpty(_source) ? '\0' : _source[0];

            while (_currentCharacter != '\0')
            {
                GetToken();
            }
        }

        private void Advance()
        {
            _currentIndex++;
            _columnIndex++;

            if (_currentIndex >= _source.Length) _currentCharacter = '\0';
            else _currentCharacter = _source[_currentIndex];

            if (_currentCharacter == '\n')
            {
                _lineIndex++;
                _columnIndex = 0;
            }
        }

        private void GetToken()
        {
            Token token = new Token();
            StringBuilder tokenName = new StringBuilder();

            if (char.IsWhiteSpace(_currentCharacter))
            {
                token.Line = _lineIndex;
                token.Column = _columnIndex;
                while (char.IsWhiteSpace(_currentCharacter))
                {
                    tokenName.Append(_currentCharacter);
                    Advance();
                }
                token.Name = tokenName.ToString();
                //Console.WriteLine(token.ToString());
                return;
            }
            else if (char.IsLetter(_currentCharacter))
            {
                token.Line = _lineIndex;
                token.Column = _columnIndex;
                while (char.IsLetterOrDigit(_currentCharacter))
                {
                    tokenName.Append(_currentCharacter);
                    Advance();
                }
                token.Name = tokenName.ToString();
                Console.WriteLine(token.ToString());
                return;
            }
            else if (char.IsDigit(_currentCharacter))
            {
                token.Line = _lineIndex;
                token.Column = _columnIndex;
                bool isFloat = false;
                while (char.IsDigit(_currentCharacter) || char.Equals('.', _currentCharacter))
                {
                    if (char.Equals('.', _currentCharacter))
                    {
                        if (isFloat == true) Program.Abort($"Error float has 2 or more decimal seperators at ({token.Line},{token.Column})" , 1);
                        isFloat = true;
                    }
                    tokenName.Append(_currentCharacter);
                    Advance();
                }
                token.Name = tokenName.ToString();
                Console.WriteLine(token.ToString());
                return;
            }
            else if (!char.IsWhiteSpace(_currentCharacter) && !char.IsLetterOrDigit(_currentCharacter))
            {
                token.Line = _lineIndex;
                token.Column = _columnIndex;
                tokenName.Append(_currentCharacter);
                Advance();
                token.Name = tokenName.ToString();
                Console.WriteLine(token.ToString());
                return;
            }
            else
            {
                Advance();
            }
        }
    }
}
