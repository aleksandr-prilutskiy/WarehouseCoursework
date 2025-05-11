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

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for ManufacturerAddPage.xaml
    /// </summary>
    public partial class ManufacturerAddPage : Page
    {
        public ManufacturerAddPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MB.Error("Введите название!");
                NameTB.Focus();
                return;
            }
            else if (NameTB.Text.Length < 3)
            {
                MB.Error("Название слишком короткое!");
                NameTB.Focus();
                return;
            }
            else
            {
                try
                {
                    AddManufacturer();
                    MB.Info($"Производитель - {NameTB.Text} ууспешно добавлен!");
                    NavigationService.Navigate(new ManufacturerListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void AddManufacturer()
        {
            var manufacturer = new Manufacturer()
            {
                NameManufacturer = NameTB.Text,
            };

            App.Context.Manufacturer.Add(manufacturer);
            App.Context.SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
