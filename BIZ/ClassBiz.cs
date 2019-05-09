using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIO;
using Repositoty;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Windows;
using System.Data.Entity.Migrations;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        private bool runUpdate = true;
        
        ClassCallWebAPI classCallWebAPI = new ClassCallWebAPI();
        ClassFileIO classFileIO = new ClassFileIO();
        private ClassContext getdata = new ClassContext();
        private ClassCurrency _classCurrency;
        private List<ClassCustomer> _listCustomer;
        private ClassCustomer _classCustomer;
        private ClassArt _classArt;
        private List<ClassArt> _listClassArt;
        private ClassCustomer _fallBackCustomer;
        private List<ClassSalesValues> _listclassSalesValues;
        private ClassSalesValues _ClassSalesValues;
        private ZipCity _zipCity;
        public ClassBiz()
        {            
            classCurrency = new ClassCurrency();
            GetAllCurrencyIdAndNames();
            

            
            ClassSalesValues csv = new ClassSalesValues();
            csv.classCurrency = classCurrency;

            classCustomer = new ClassCustomer();
            listClassArt = new List<ClassArt>(getdata.classArt.ToList() as List<ClassArt>);
            classArt = new ClassArt();
            listCustomer = new List<ClassCustomer>(getdata.classCustomer.ToList()as List<ClassCustomer>);
            ClassSalesValues = new ClassSalesValues();
            listclassSalesValues = new List<ClassSalesValues>(getdata.classSalesValues.ToList() as List<ClassSalesValues>);
        }

        #region properties

        public List<ClassArt> listClassArt
        {
            get { return _listClassArt; }
            set
            {
                if (value != _listClassArt)
                {
                    _listClassArt = value;
                    Notify("listClassArt");
                }
            }
        }

        public ClassArt classArt
        {
            get { return _classArt; }
            set
            {
                if (value != _classArt)
                {
                    _classArt = value;
                    Notify("classArt");
                }
            }
        }

        public List<ClassCustomer> listCustomer
        {
            get { return _listCustomer; }
            set
            {
                if (value != _listCustomer)
                {
                    _listCustomer = value;
                    Notify("listCustomer");
                }
            }
        }

        public ClassCustomer classCustomer
        {
            get { return _classCustomer; }
            set
            {
                if (value != _classCustomer)
                {
                    _classCustomer = value;
                    Notify("classCustomer");
                }
            }
        }
        public List<ClassSalesValues> listclassSalesValues
        {
            get { return _listclassSalesValues; }
            set
            {
                if (value != _listclassSalesValues)
                {
                    _listclassSalesValues = value;
                    Notify("listclassSalesValues");

                }
            }
        }
        
        public ClassSalesValues ClassSalesValues
        {
            get { return _ClassSalesValues; }
            set
            {
                if (value != _ClassSalesValues)
                {
                    _ClassSalesValues = value;
                    Notify("ClassSalesValues");

                }
            }
        } 

        public ClassCustomer fallbackCustomer
        {
            get { return _fallBackCustomer; }
            set
            {
                if (value != _fallBackCustomer)
                {
                    _fallBackCustomer = value;
                    Notify("fallbackCustomer");
                }
            }
        }

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
        

        public ZipCity zipCity
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

        #endregion

        public async Task StartCurrencyApiCall()
        {
            while (runUpdate)
            {
                // GetURLContents returns the contents of url as a byte array.
                byte[] urlContents = await classCallWebAPI.GetURLContentsAsync("https://openexchangerates.org/api/latest.json?app_id=09e34d204d7e4b998d7f178033b742ca");

                string strJson = System.Text.Encoding.UTF8.GetString(urlContents);
                classCurrency = JsonConvert.DeserializeObject<ClassCurrency>(strJson);
                await Task.Delay(60000);
            }
            
        }
        public async Task startzipcityapicall()
        {
            while (runUpdate)
            {
                
                byte[] urlcontents = await classCallWebAPI.GetURLContentsAsync(@"https://localhost:44344/api/zip/search/");

                string strjson = System.Text.Encoding.UTF8.GetString(urlcontents);

                zipCity = JsonConvert.DeserializeObject<ZipCity>(strjson);
                await Task.Delay(60000);
            }
        }
       
        private void GetAllCurrencyIdAndNames()
        {
            try
            {
                classCurrency.currencyIdName = classFileIO.ReadDataFromCurrencyFile();
            }
            catch (Exception ex)
            {

                string strEX = ex.Message;
            }            
        }
        
        public void SaveArtToDB()
        {
            using (ClassContext ccx = new ClassContext())
            {                
                ccx.classArt.AddOrUpdate(classArt);
                ccx.SaveChanges();
            }
            classArt = new ClassArt();
            listClassArt.Clear();
                
        }

        public void SaveCustomerToDB()
        {
            
            using (ClassContext ccx = new ClassContext())
            {
                classCustomer.customerCurrencyID = "DKK";
                ccx.classCustomer.AddOrUpdate(classCustomer);
                ccx.SaveChanges();
            }
            
            classCustomer = new ClassCustomer();
            listCustomer.Clear();
            //getallcustomers();

        }
        //private void getallcustomers()
        //{
        //    using (ClassContext ccx = new ClassContext())
        //    {

        //        List<ClassCustomer> listcustomer = ccx.classCustomer.ToList() as List<ClassCustomer>;
        //        foreach (ClassCustomer classCustomer in listcustomer)
        //        {
        //            listcustomer.Add(classCustomer);
        //        }
        //    }
        //}

        public void Makedatabase()
        {
            try
            {
                using (ClassContext ctx = new ClassContext())
                {
                    ctx.Database.CreateIfNotExists();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var t in ex.EntityValidationErrors)
                {
                    MessageBox.Show(t.ValidationErrors.First().ErrorMessage);
                }
            }
        }

    }
}
