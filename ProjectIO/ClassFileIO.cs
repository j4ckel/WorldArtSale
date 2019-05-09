using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIO
{
    public class ClassFileIO
    {

        public ClassFileIO()
        {

        }

        public Dictionary<string, string> ReadDataFromCurrencyFile()
        {
            Dictionary<string, string> dicRes = new Dictionary<string, string>();
            try
            {
                string startupPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Repositoty\DataFiles\CurrencyIdName.csv";

                
                StreamReader reader = new StreamReader(startupPath);
                char[] sep = new char[] { ';' };

                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    dicRes.Add(values[0], values[1]);
                }
            }
            catch (IOException ex)
            {

                throw ex;
            }
            
            return dicRes;
        }
       

    }
}
