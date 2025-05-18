using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WarehouseCoursework.ClassFolder;

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for ManufacturerEditPage.xaml
    /// </summary>
    public partial class ManufacturerEditPage : Page
    {
        public ManufacturerEditPage()
        {
            InitializeComponent();
            DataContext = GV.Manufacturer;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
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
                    EditManufacturer();
                    MB.Info($"Изминения успешно сохранены!");
                    NavigationService.Navigate(new ManufacturerListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void EditManufacturer()
        {
            var manufacturer = App.Context.Manufacturer.FirstOrDefault(
                s => s.IdManufacturer == GV.Manufacturer.IdManufacturer);
            manufacturer.NameManufacturer = NameTB.Text;
            App.Context.SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
