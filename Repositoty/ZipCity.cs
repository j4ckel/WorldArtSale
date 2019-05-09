using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ZipCity 
    {
        public string ZipCode { get; set; }
        public string CityName { get; set; }

        public override string ToString()
        {
            return $"{ZipCode} {CityName}";
        }

    }
}
