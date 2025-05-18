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
    /// Interaction logic for UserEditPage.xaml
    /// </summary>
    public partial class GoodsInStockDelPage : Page
    {
        public GoodsInStockDelPage()
        {
            InitializeComponent();
            DataContext = GV.Product;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserChangePassword());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DelCount.Text))
            {
                MB.Error("Введите количество");
                DelCount.Focus();
                return;
            }
            else
            {
                try
                {
                    if (int.TryParse(DelCount.Text, out int count) && (count > 0)) 
                    {
                        var product = App.Context.Product.FirstOrDefault(x => x.IdProduct == GV.Product.IdProduct);
                        if (product.RemainProduct >= count)
                        {
                            product.RemainProduct = product.RemainProduct - count;
                            App.Context.SaveChanges();
                            MB.Info("Изминения сохранены!");
                            NavigationService.Navigate(new GoodsInStockListPage());
                        }
                        else
                        {
                            MB.Error("Нельзя забрать больше того что есть на складе");
                            DelCount.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MB.Error("Количество должно быть положительным числом");
                        DelCount.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }
    }
}
