using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ClassSalesValues : ClassNotify
    {
        #region fields
        private string _bidUSD;
        private string _bidEUR;
        private string _bidOwnValuta;
        private string _priceWithFeeUSD;
        private string _priceWithFeeEUR;
        private string _priceWithFeeOwnValuta;
        private ClassCurrency _classCurrency;
        private string _currencyID;
        private DateTime _date;
        private ClassCustomer _ClassCustomer;
        private ClassArt _ClassArt;
        
        #endregion

        public ClassSalesValues()
        {
            
        }
        #region Properties
        
        [Key]
        public string currencyID
        {
            get { return _currencyID; }
            set
            {
                if (value != _currencyID)
                {
                    _currencyID = value;
                    Notify("currencyID");
                }
            }
        }

        [ForeignKey("ClassCustomer")]
        public int customerId { get; set; }
        public ClassCustomer ClassCustomer
        {
            get { return _ClassCustomer; }
            set
            {
                if (value != _ClassCustomer)
                {
                    _ClassCustomer = value;
                    if (ClassCustomer != null)
                    {
                        customerId = ClassCustomer.customerId;
                    }
                    Notify("ClassCustomer");

                }
            }
        }
        [ForeignKey("ClassArt")]        
        public int artID { get; set; }
        public ClassArt ClassArt
        {
            get { return _ClassArt; }
            set
            {
                if (value != _ClassArt)
                {
                    _ClassArt = value;
                    if (ClassArt != null)
                    {
                        artID = ClassArt.artID;
                    }
                    Notify("ClassArt");

                }
            }
        }

        
        public string priceWithFeeOwnValuta
        {
            get { return _priceWithFeeOwnValuta; }
            set
            {
                if (value != _priceWithFeeOwnValuta)
                {
                    _priceWithFeeOwnValuta = value;
                    Notify("priceWithFeeOwnValuta");
                }
            }
        }
        
        public string priceWithFeeEUR
        {
            get { return _priceWithFeeEUR; }
            set
            {
                if (value != _priceWithFeeEUR)
                {
                    _priceWithFeeEUR = value;
                    Notify("priceWithFeeEUR");
                }
            }
        }
               
        public string priceWithFeeUSD
        {
            get { return _priceWithFeeUSD; }
            set
            {
                if (value != _priceWithFeeUSD)
                {
                    _priceWithFeeUSD = value;
                    Notify("priceWithFeeUSD");
                }
            }
        }
        
        public string bidOwnValuta
        {
            get { return _bidOwnValuta; }
            set
            {
                if (value != _bidOwnValuta)
                {
                    _bidOwnValuta = value;
                    Notify("bidOwnValuta");
                }
            }
        }
        
        public string bidEUR
        {
            get { return _bidEUR; }
            set
            {
                if (value != _bidEUR)
                {
                    _bidEUR = value;
                    Notify("bidEUR");
                }
            }
        }
               
        public string bidUSD
        {
            get { return _bidUSD; }
            set
            {
                if (value != _bidUSD)
                {
                    if (decimal.TryParse(value, out decimal X))
                    {
                        _bidUSD = value;
                        CalculateAll();
                    }                   
                    Notify("bidUSD");                    
                }
            }
        }
        

        public DateTime date
        {
            get { return _date; }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    Notify("date");

                }
            }
        }
        [NotMapped]
        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (value != _classCurrency)
                {
                    _classCurrency = value;
                    Notify("classCurrency");
                }
            }
        }

        #endregion
        private void CalculateAll()
        {
            
            
                decimal valutaRateOvnValuta = classCurrency.rates[Convert.ToDecimal(currencyID).ToString()];
                decimal.TryParse(bidUSD, out decimal calckUSD);
                decimal valutaRateEUR = classCurrency.rates["EUR"];
                decimal KRkurs = classCurrency.rates["DKK"];

                bidEUR = (calckUSD * valutaRateEUR).ToString("#,##0.00");
                bidOwnValuta = (calckUSD * valutaRateOvnValuta).ToString("#,##0.00");

                priceWithFeeUSD = (calckUSD * 1.075M).ToString("#,##0.00");
                priceWithFeeEUR = ((calckUSD * valutaRateEUR) * 1.075M).ToString("#,##0.00");
                priceWithFeeOwnValuta = ((calckUSD * valutaRateOvnValuta) * 1.075M).ToString("#,##0.00");
        }
    }
}
