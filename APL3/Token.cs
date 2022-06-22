using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL3
{
    internal class Token
    {
        public string Name = String.Empty;
        public int Line;
        public int Column;

        public override string ToString()
        {
            var str = $"({Line},{Column}): {Name}";

            return str;
        }
    }
}
