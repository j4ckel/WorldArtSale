using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ZipCity :ClassNotify
    {
        public ZipCity()
        {
            
        }
        private string _zipcode;
        private string _CityName;
        private Dictionary<string,string> _ZipCityIdName;

        public Dictionary<string,string> ZipCityIdName
        {
            get { return _ZipCityIdName; }
            set
            {
                if (value != _ZipCityIdName)
                {
                    _ZipCityIdName = value;
                    Notify("ZipCityIdName");

                }
            }
        }

        public string Cityname
        {
            get { return _CityName; }
            set
            {
                if (value != _CityName)
                {
                    _CityName = value;
                    Notify("Cityname");

                }
            }
        }

        public string zipcode
        {
            get { return _zipcode; }
            set
            {
                if (value != _zipcode)
                {
                    _zipcode = value;
                    Notify("zipcode");

                }
            }
        }

    }
}
