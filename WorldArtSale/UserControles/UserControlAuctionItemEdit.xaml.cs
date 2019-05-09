using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Repositoty;

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlAuctionItemEdit.xaml
    /// </summary>
    public partial class UserControlAuctionItemEdit : UserControl
    {
        ClassBiz classBiz;
        Grid gridLeft;
        Grid gridMiddel;
        Grid gridRight;

        public UserControlAuctionItemEdit(ClassBiz inBiz, Grid inGridLeft, Grid inGridMiddel, Grid inGridRight)
        {
            InitializeComponent();
            classBiz = inBiz;
            MainArtGridEdit.DataContext = classBiz;
            gridLeft = inGridLeft;
            gridMiddel = inGridMiddel;
            gridRight = inGridRight;

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            classBiz.SaveArtToDB();
            classBiz.classArt = new ClassArt();

            gridMiddel.IsEnabled = true;
            gridRight.IsEnabled = true;
            gridLeft.Children.RemoveAt(1);
        }

        private void ButtonFindArt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    OpenFileDialog OFD = new OpenFileDialog();
                    OFD.Filter = "JPG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|All files (*.*)|*.*";
                    if (OFD.ShowDialog() == true)
                    {
                        //classBiz.classArt.picturePath = OFD.FileName;
                        string newPath = @"C:\skole\skole\S3\eksamen s3\WorldArtSale\Image" + OFD.SafeFileName;
                        File.Copy(OFD.FileName, newPath);
                        classBiz.classArt.picturePath = newPath;
                    }

                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
