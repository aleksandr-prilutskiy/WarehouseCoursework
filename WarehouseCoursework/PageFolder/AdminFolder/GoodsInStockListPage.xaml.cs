using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseCoursework.ClassFolder;
using WarehouseCoursework.DataFolder;

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for ManufacturerListPage.xaml
    /// </summary>
    public partial class GoodsInStockListPage : Page
    {
        public GoodsInStockListPage()
        {
            InitializeComponent();
            MainLB.ItemsSource = App.Context.Product.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                MainLB.ItemsSource = App.Context.Product.ToList();
            }
            else
            {
                try
                {
                    MainLB.ItemsSource = App.Context.Product.
                        Where(x => x.NameProduct.Contains(SearchTB.Text)).ToList();
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void AddGoodsInStock_Click(object sender, RoutedEventArgs e)
        {
            GV.Product = MainLB.SelectedValue as Product;
            NavigationService.Navigate(new GoodsInStockAddPage());
        }

        private void DeleteGoodsInStock_Click(object sender, RoutedEventArgs e)
        {
            GV.Product = MainLB.SelectedValue as Product;
            NavigationService.Navigate(new GoodsInStockDelPage());
        }
    }
}
