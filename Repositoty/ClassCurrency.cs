using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositoty
{
    public class ClassCurrency : ClassNotify
    {
        private string _USD;
        private string _EUR;
        private string _DKK;
        #region not used fields
        //private string _KWD;
        //private string _BHD;
        //private string _OMR;
        //private string _JOD;
        //private string _GBP;
        //private string _KYD;
        //private string _CHF;
        //private string _CAD;
        //private string _AUD;
        //private string _AZN;
        //private string _BRL;
        //private string _HKD;
        #endregion
        private Dictionary<string, string> _currencyIdName;

        private Dictionary<string, decimal> _rates;

        public ClassCurrency()
        {
            
        }
        #region notused properties
        //public string HKD
        //{
        //    get { return _HKD; }
        //    set
        //    {
        //        if (value != _HKD)
        //        {
        //            _HKD = value;
        //            Notify("HKD");
        //        }
        //    }
        //}

        //public string BRL
        //{
        //    get { return _BRL; }
        //    set
        //    {
        //        if (value != _BRL)
        //        {
        //            _BRL = value;
        //            Notify("BRL");
        //        }
        //    }
        //}

        //public string AZN
        //{
        //    get { return _AZN; }
        //    set
        //    {
        //        if (value != _AZN)
        //        {
        //            _AZN = value;
        //            Notify("AZN");
        //        }
        //    }
        //}

        //public string AUD
        //{
        //    get { return _AUD; }
        //    set
        //    {
        //        if (value != _AUD)
        //        {
        //            _AUD = value;
        //            Notify("AUD");
        //        }
        //    }
        //}

        //public string CAD
        //{
        //    get { return _CAD; }
        //    set
        //    {
        //        if (value != _CAD)
        //        {
        //            _CAD = value;
        //            Notify("CAD");
        //        }
        //    }
        //}

        //public string CHF
        //{
        //    get { return _CHF; }
        //    set
        //    {
        //        if (value != _CHF)
        //        {
        //            _CHF = value;
        //            Notify("CHF");
        //        }
        //    }
        //}

        //public string KYD
        //{
        //    get { return _KYD; }
        //    set
        //    {
        //        if (value != _KYD)
        //        {
        //            _KYD = value;
        //            Notify("KYD");
        //        }
        //    }
        //}

        //public string GBP
        //{
        //    get { return _GBP; }
        //    set
        //    {
        //        if (value != _GBP)
        //        {
        //            _GBP = value;
        //            Notify("GBP");
        //        }
        //    }
        //}

        //public string JOD
        //{
        //    get { return _JOD; }
        //    set
        //    {
        //        if (value != _JOD)
        //        {
        //            _JOD = value;
        //            Notify("JOD");
        //        }
        //    }
        //}

        //public string OMR
        //{
        //    get { return _OMR; }
        //    set
        //    {
        //        if (value != _OMR)
        //        {
        //            _OMR = value;
        //            Notify("OMR");
        //        }
        //    }
        //}

        //public string BHD
        //{
        //    get { return _BHD; }
        //    set
        //    {
        //        if (value != _BHD)
        //        {
        //            _BHD = value;
        //            Notify("BHD");
        //        }
        //    }
        //}

        //public string KWD
        //{
        //    get { return _KWD; }
        //    set
        //    {
        //        if (value != _KWD)
        //        {
        //            _KWD = value;
        //            Notify("KWD");
        //        }
        //    }
        //}
        #endregion
        public string DKK
        {
            get { return _DKK; }
            set
            {
                if (value != _DKK)
                {
                    _DKK = value;
                    Notify("DKK");
                }
            }
        }

        public string EUR
        {
            get { return _EUR; }
            set
            {
                if (value != _EUR)
                {
                    _EUR = value;
                    Notify("EUR");
                }
            }
        }

        public string USD
        {
            get { return _USD; }
            set
            {
                if (value != _USD)
                {
                    _USD = value;
                    Notify("USD");
                }
            }
        }
        
        public Dictionary<string, string> currencyIdName
        {
            get { return _currencyIdName; }
            set
            {
                if (value != _currencyIdName)
                {
                    _currencyIdName = value;
                    Notify("currencyIdName");
                }
            }
        }


        public string disclaimer { get; set; }
        public string license { get; set; }
        public long timestamp { get; set; }
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
        public Dictionary<string, decimal> rates
        {
            get
            {
                return _rates;
            }
            set
            {
                _rates = value;
                SetValutaValueInProperty();
            }
        }
        private void SetValutaValueInProperty()
        {
            decimal KRkurs = rates["DKK"];
            USD = ((1 / rates["USD"]) * KRkurs).ToString("##0.0000");
            EUR = ((1 / rates["EUR"]) * KRkurs).ToString("##0.0000");
            DKK = ((1 / rates["DKK"]) * KRkurs).ToString("##0.0000");
            #region not used var
            //KWD = ((1 / rates["KWD"]) * KRkurs).ToString("##0.0000");
            //BHD = ((1 / rates["BHD"]) * KRkurs).ToString("##0.0000");
            //OMR = ((1 / rates["OMR"]) * KRkurs).ToString("##0.0000");
            //JOD = ((1 / rates["JOD"]) * KRkurs).ToString("##0.0000");
            //GBP = ((1 / rates["GBP"]) * KRkurs).ToString("##0.0000");
            //KYD = ((1 / rates["KYD"]) * KRkurs).ToString("##0.0000");
            //CHF = ((1 / rates["CHF"]) * KRkurs).ToString("##0.0000");
            //CAD = ((1 / rates["CAD"]) * KRkurs).ToString("##0.0000");
            //AUD = ((1 / rates["AUD"]) * KRkurs).ToString("##0.0000");
            //AZN = ((1 / rates["AZN"]) * KRkurs).ToString("##0.0000");
            //BRL = ((1 / rates["BRL"]) * KRkurs).ToString("##0.0000");
            //HKD = ((1 / rates["HKD"]) * KRkurs).ToString("##0.0000");
            #endregion
        }
    }
}
