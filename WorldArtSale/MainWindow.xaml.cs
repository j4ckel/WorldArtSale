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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz CB;

        UserControlExchangerates userControlExchangerates; 
        UserControlCostumer userControlCostumer;
        UserControlAuctionItem userControlAuctionItem;
        UserControlBidCalculation userControlBidCalculation;
        UserControlAuctionItemEdit userControlAuctionItemEdit;
        

        public MainWindow()
        {
            InitializeComponent();
            
            CB = new ClassBiz();
            CB.Makedatabase();
            GridMain.DataContext = CB;
            userControlExchangerates = new UserControlExchangerates(CB);
            userControlCostumer = new UserControlCostumer(CB);
            userControlBidCalculation = new UserControlBidCalculation(CB);
            
            userControlAuctionItemEdit = new UserControlAuctionItemEdit(CB, GridTopLeft, GridTopMiddel, GridTopRight);
            userControlAuctionItem = new UserControlAuctionItem(CB, GridTopLeft, GridTopMiddel, GridTopRight, userControlAuctionItemEdit);

            GridBottum.Children.Add(userControlExchangerates);
            GridTopLeft.Children.Add(userControlAuctionItem);
            GridTopRight.Children.Add(userControlBidCalculation);
            GridTopMiddel.Children.Add(userControlCostumer);

            //GridTopLeft.Children.Add(userControlCostumer);
            //GridTopRight.Children.Add(userControlAuctionItem);
            //GridTopMiddel.Children.Add(userControlBidCalculation);

            
        }

        

        private async void StartJasonUpdate(object sender, RoutedEventArgs e)
        {
            await CB.StartCurrencyApiCall();
            await CB.startzipcityapicall();
        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {

        }
    }
}
