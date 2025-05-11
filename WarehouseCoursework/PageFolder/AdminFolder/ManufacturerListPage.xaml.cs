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
    /// Interaction logic for ManufacturerListPage.xaml
    /// </summary>
    public partial class ManufacturerListPage : Page
    {
        public ManufacturerListPage()
        {
            InitializeComponent();
            MainLB.ItemsSource = App.Context.Manufacturer.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                MainLB.ItemsSource = App.Context.Manufacturer.ToList();
            }
            else
            {
                try
                {
                    MainLB.ItemsSource =
                        App.Context.Manufacturer.
                        Where(x => x.NameManufacturer.
                        Contains(SearchTB.Text))
                        .ToList();
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void ManufacturerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManufacturerAddPage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            GV.Manufacturer = MainLB.SelectedValue as Manufacturer; 
            NavigationService.Navigate(new ManufacturerEditPage());
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            if (MainLB.SelectedValue == null)
            {
                MB.Error("Товар не выбран!");
                return;
            }
            else
            {
                var selected = MainLB.SelectedValue as Manufacturer;
                var manufacturer = App.Context.Manufacturer.FirstOrDefault(x => x.IdManufacturer == selected.IdManufacturer);
                if (manufacturer != null)
                {
                    var question = MB.Quiestion($"Вы действительно хотите удалить {manufacturer.NameManufacturer}?");

                    if (question)
                    {
                        try
                        {
                            App.Context.Manufacturer.Remove(manufacturer);
                            App.Context.SaveChanges();
                            MB.Info($"Производитель - {manufacturer.NameManufacturer} успешно удален!");
                            NavigationService.Navigate(new ManufacturerListPage());
                        }
                        catch (Exception ex)
                        {
                            MB.Error(ex);
                        }
                    }
                }
                else
                {
                    MB.Error("Производитель не существует!");
                    return;
                }
            }
        }
    }
}
