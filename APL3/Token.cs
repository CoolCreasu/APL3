using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL3
{
    internal class Token
    {
        public string Name;
        public int Line;

        public override string ToString()
        {
            return $"{Line}: {Name}";
        }
    }
}
