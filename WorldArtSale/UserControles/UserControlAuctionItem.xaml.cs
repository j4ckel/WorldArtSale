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
    /// Interaction logic for UserControlAuctionItem.xaml
    /// </summary>
    public partial class UserControlAuctionItem : UserControl
    {
        ClassBiz classBiz;
        Grid gridLeft;
        Grid gridMiddel;
        Grid gridRight;
        UserControl userControl;

        public UserControlAuctionItem(ClassBiz inBIZ, Grid inGridLeft, Grid inGridMiddel, Grid inGridRight, UserControl inUserControl)
        {
            InitializeComponent();
            classBiz = inBIZ;
            gridLeft = inGridLeft;
            gridMiddel = inGridMiddel;
            gridRight = inGridRight;
            userControl = inUserControl;



            MainArtGrid.DataContext = classBiz;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comb = (ComboBox)sender;
            ClassArt ca = (ClassArt)comb.SelectedItem;
            classBiz.classArt = ca;
        }

        private void AddNewArtToDB_Click(object sender, RoutedEventArgs e)
        {
            gridMiddel.IsEnabled = false;
            gridRight.IsEnabled = false;
            
            classBiz.classArt = new ClassArt();
            gridLeft.Children.Add(userControl);
        }
    }
}
