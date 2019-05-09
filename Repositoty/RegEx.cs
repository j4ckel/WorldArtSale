using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Repositoty
{
    public class RegEx
    {
        public RegEx() { }

        public bool checkzipcity(string instring)
        {
            Regex ex = new Regex(@"\d{3,4} \w+");
            return ex.IsMatch(instring);
        }
    }
}
