using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WarehouseCoursework.ClassFolder;

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        public string selectedFileName = "";
        byte[] Photo;
        public ProductEditPage()
        {
            InitializeComponent();
            DataContext = GV.Product;
            ManufacturerCB.ItemsSource = App.Context.Manufacturer.ToList();
            ManufacturerCB.SelectedIndex = GV.Product.IdManufacturer - 1;
            DateOfReleaseDP.Text = GV.Product.DateOfReleaseProduct.ToString();
        }

        private void PhotoBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EditPhoto();
            }
            catch (Exception ex)
            {
                MB.Error(ex);
            }
        }

        private void EditPhoto()
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
            try
            {
                var product = App.Context
                        .Product.FirstOrDefault(s => s.IdProduct == GV.Product.IdProduct);

                product.PhotoProduct = Photo;
                MB.Info("Фото изменено!");

                App.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MB.Error(ex);
                return;
            }
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
            else
            {
                try
                {
                    EditProduct();
                    MB.Info("Изминения сохранены!");
                    NavigationService.Navigate(new ProductListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void EditProduct()
        {
            var product = App.Context.Product.FirstOrDefault(x => x.IdProduct == GV.Product.IdProduct);

            if (product == null)
            {
                MB.Error("Товар не найден, повторите попытку!");
                return;            
            }
            product.NameProduct = NameTB.Text;
            product.IdManufacturer = Int32.Parse(ManufacturerCB.SelectedValue.ToString());
            product.DateOfReleaseProduct = DateTime.Parse(DateOfReleaseDP.Text);
            product.PriceProduct = decimal.Parse(PriceTB.Text);
            product.LocationProduct = LocationTB.Text;
            product.RemainProduct = Int32.Parse(RemainTB.Text);

            App.Context.SaveChanges();
        }
    }
}
