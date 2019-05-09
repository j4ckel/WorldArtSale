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

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlBidCalculation.xaml
    /// </summary>
    public partial class UserControlBidCalculation : UserControl
    {
        ClassBiz CB;
        public UserControlBidCalculation(ClassBiz inCB)
        {
            InitializeComponent();
            CB = inCB;
            GridMoney.DataContext = CB;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(comboBoxBidUp.Text, out decimal bidUp))
            {
                decimal.TryParse(textBoxActualBid.Text, out decimal oldBid);
                decimal newBid = oldBid + bidUp;
                textBoxActualBid.Text = newBid.ToString("#,##0.00");
            }
            else
            {
                MessageBox.Show("Angiv hvor meget der øges med !!!! ");
            }

        }
    }
}
