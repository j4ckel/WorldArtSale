using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositoty
{
    public class ClassCustomer : ClassNotify
    {
        
        ClassSalesValues csv = new ClassSalesValues();
        private int _CustomerId;
        private string _name;
        private string _address;
        private string _zipCity;
        private string _country;
        private string _email;
        private string _phoneNo;
        private string _maxBid;
        private string _customerCurrencyID;

        public ClassCustomer()
        {
            
        }
          [Key]
        public int customerId
        {
            get { return _CustomerId; }
            set
            {
                if (value != _CustomerId)
                {
                    _CustomerId = value;
                    Notify("customerId");

                }
            }
        }
        public string customerCurrencyID
        {
            get { return _customerCurrencyID; }
            set
            {
                if (value != _customerCurrencyID)
                {
                    _customerCurrencyID = value;
                    csv.currencyID = customerCurrencyID;
                    Notify("costumerCurrencyID");
                }
            }
        }
        public string maxBid
        {
            get { return _maxBid; }
            set
            {
                if (value != _maxBid)
                {
                    decimal customerMaxBid = Convert.ToDecimal(value);
                    _maxBid = customerMaxBid.ToString("#,##0.00");
                    Notify("maxBid");
                }
            }
        }
        public string phoneNo
        {
            get { return _phoneNo; }
            set
            {
                if (value != _phoneNo)
                {
                    _phoneNo = value;
                    Notify("phoneNo");
                }
            }
        }


        public string email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    Notify("email");
                }
            }
        }


        public string country
        {
            get { return _country; }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    Notify("country");
                }
            }
        }
        public string zipCity
        {
            get { return _zipCity; }
            set
            {
                if (value != _zipCity)
                {
                    _zipCity = value;
                    Notify("zipCity");
                }
            }
        }
        public string address
        {
            get { return _address; }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    Notify("address");
                }
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    Notify("name");
                }
            }
        }
    }
}
