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
using WarehouseCoursework.DataFolder;
using WarehouseCoursework.PageFolder.StaffFolder;

namespace WarehouseCoursework.PageFolder.StaffFolder
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            MainLB.ItemsSource = App.Context.Product.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(SearchTB.Text))
                {
                    MainLB.ItemsSource = App.Context.Product.ToList();
                }
                else
                {
                    try
                    {
                        MainLB.ItemsSource =
                            App.Context.Product.
                            Where(x => x.NameProduct.
                            Contains(SearchTB.Text) ||
                            x.LocationProduct.StartsWith(SearchTB.Text))
                            .ToList();
                    }
                    catch (Exception ex)
                    {
                        MB.Error(ex);
                    }
                }
            }
        }

        private void ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductAddPage());
        }

        private void InfoMI_Click(object sender, RoutedEventArgs e)
        {
            GV.Product = MainLB.SelectedValue as Product;
            NavigationService.Navigate(new ProductInfoPage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            GV.Product = MainLB.SelectedValue as Product;
            NavigationService.Navigate(new ProductEditPage());
        }
    }
}
