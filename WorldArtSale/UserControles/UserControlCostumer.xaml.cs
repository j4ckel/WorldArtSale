using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;
using Repositoty;

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlCostumer.xaml
    /// </summary>
    public partial class UserControlCostumer : UserControl
    {
        ClassBiz CB;
        
        public UserControlCostumer(ClassBiz inCB)
        {
            InitializeComponent();
            CB = inCB;
            
            topBoxGrid.DataContext = CB;
            comboBoxValuta.DataContext = CB.classCurrency;
            CB.classCustomer.customerCurrencyID = "DKK";

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox myCombo = (ComboBox)sender;
            var XX = myCombo.SelectedValue;
            if (XX != null)
            {
                CB.classCustomer.customerCurrencyID = XX.ToString();
                List<ClassCurrency> classCurrency = (List<ClassCurrency>)myCombo.SelectedItem;

            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comb = (ComboBox)sender;
            ClassCustomer classCustomer = (ClassCustomer)comb.SelectedItem;
            ClassSalesValues csv = new ClassSalesValues();
            csv.classCurrency = CB.classCurrency;
            CB.classCustomer = classCustomer;
        }

        private void OpenAllTextBoxForEdit()
        {
            textBoxName.IsReadOnly = false;
            textBoxAddress.IsReadOnly = false;
            textBoxZipCity.IsReadOnly = false;
            textBoxCountry.IsReadOnly = false;
            textBoxMail.IsReadOnly = false;
            textBoxPhone.IsReadOnly = false;
            textBoxMaxBid.IsReadOnly = false;
            buttonCreateUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonNewCustomer.Visibility = Visibility.Hidden;
            buttonEditCustomer.Visibility = Visibility.Hidden;
        }

        private void CloseAllTextBoxForEdit()
        {
            textBoxName.IsReadOnly = true;
            textBoxAddress.IsReadOnly = true;
            textBoxZipCity.IsReadOnly = true;
            textBoxCountry.IsReadOnly = true;
            textBoxMail.IsReadOnly = true;
            textBoxPhone.IsReadOnly = true;
            textBoxMaxBid.IsReadOnly = true;
            buttonCreateUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Hidden;
            buttonNewCustomer.Visibility = Visibility.Visible;
            buttonEditCustomer.Visibility = Visibility.Visible;
        }

        public void ClearAllTextBoxes()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxZipCity.Text = "";
            textBoxCountry.Text = "";
            textBoxMail.Text = "";
            textBoxPhone.Text = "";
            textBoxMaxBid.Text = "";
        }

        private void ButtonNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CB.fallbackCustomer = CB.classCustomer;
            OpenAllTextBoxForEdit();            
            CB.classCustomer = new ClassCustomer();

        }

        private void ButtonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            CB.fallbackCustomer = CB.classCustomer;
            OpenAllTextBoxForEdit();
            
        }

        private void ButtonCreateUpdate_Click(object sender, RoutedEventArgs e)
        {
            CB.SaveCustomerToDB();
            
            CloseAllTextBoxForEdit();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseAllTextBoxForEdit();
            CB.classCustomer = CB.fallbackCustomer;
        }
    }
}
