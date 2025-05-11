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
using WarehouseCoursework.ClassFolder;

namespace WarehouseCoursework.PageFolder.StaffFolder
{
    /// <summary>
    /// Interaction logic for ProductInfoPage.xaml
    /// </summary>
    public partial class ProductInfoPage : Page
    {
        public ProductInfoPage()
        {
            InitializeComponent();
            DataContext = GV.Product;
            ManufacturerCB.ItemsSource = App.Context.Manufacturer.ToList();
            ManufacturerCB.SelectedIndex = GV.Product.IdManufacturer - 1;
            DateOfReleaseDP.Text = GV.Product.DateOfReleaseProduct.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
