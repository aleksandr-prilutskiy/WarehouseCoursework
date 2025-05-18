using Microsoft.Win32;
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
    /// Interaction logic for ProductAddPage.xaml
    /// </summary>
    public partial class ProductAddPage : Page
    {
        public string selectedFileName = "";
        byte[] Photo;
        public ProductAddPage()
        {
            InitializeComponent();
            ManufacturerCB.ItemsSource = App.Context.Manufacturer.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MB.Error("Введите название!");
                NameTB.Focus();
                return;
            }
            else if (NameTB.Text.Length < 5)
            {
                MB.Error("Название не может быть таким коротким!");
                NameTB.Focus();
                return;
            }
            else if (ManufacturerCB.Text == null)
            {
                MB.Error("Выбретие производителя!");
                ManufacturerCB.Focus();
                return;
            }
            else if (DateOfReleaseDP.Text == null)
            {
                MB.Error("Введите дату производства!");
                DateOfReleaseDP.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PriceTB.Text))
            {
                MB.Error("Введите цену!");
                PriceTB.Focus();
                return;
            }
            else if (Int32.Parse(PriceTB.Text) <= 0)
            {
                MB.Error("Цена не может быть равно 0 или меньше 0!");
                PriceTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(RemainTB.Text))
            {
                MB.Error("Введите остаток!");
                RemainTB.Focus();
                return;
            }
            else if (Int32.Parse(RemainTB.Text) < 0)
            {
                MB.Error("Остаток не может быть меньше 0!");
                RemainTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(LocationTB.Text))
            {
                MB.Error("Введите локацию!");
                LocationTB.Focus();
                return;
            }
            else if (LocationTB.Text.Length > 4)
            {
                MB.Error("Локация не может состоять больше чем из 4 символов!");
                LocationTB.Focus();
                return;
            }
            else if (Photo == null)
            {
                MB.Error("Выберите фото!");
                return;
            }
            else
            {
                try
                {
                    AddProduct();
                    MB.Info($"Товар {NameTB.Text} успешно добавлен!");
                    NavigationService.Navigate(new ProductListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void AddProduct()
        {
            var product = new Product()
            {
                NameProduct = NameTB.Text,
                IdManufacturer = Int32.Parse(ManufacturerCB.SelectedValue.ToString()),
                DateOfReleaseProduct = DateTime.Parse(DateOfReleaseDP.Text),
                PriceProduct = decimal.Parse(PriceTB.Text),
                LocationProduct = LocationTB.Text,
                RemainProduct = Int32.Parse(RemainTB.Text),
                PhotoProduct = Photo
            };
            App.Context.Product.Add(product);
            App.Context.SaveChanges();
        }

        private void PhotoBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddPhoto();
        }

        private void AddPhoto()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                selectedFileName = op.FileName;
                Photo = Img.ConvertImageToByteArray(selectedFileName);
                PhotoProductImageBrush.ImageSource = Img.ConvertByteArrayToImage(Photo);
            }
            else
            {
                return;
            }
        }
    }
}
