using System.Windows;
using System.Windows.Input;
using WarehouseCoursework.ClassFolder;
using WarehouseCoursework.PageFolder.AdminFolder;

namespace WarehouseCoursework.WindowFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        public MainAdminWindow()
        {
            InitializeComponent();
            UsernameLabel.Content = GV.User.LoginUser;
            MainFrame.Navigate(new UserListPage());
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserListPage());
        }

        private void StaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StaffListPage());
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductListPage());
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var question = MB.Quiestion("Вы действительно хотите выйти из аккаунта?");
            if (question)
            {
                GV.User = null;
                new AuthorizationWindow().Show();
                this.Close();
            }
        }

        private void PackIcon_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MB.Exit();
        }

        private void GoodsInStockBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GoodsInStockListPage());
        }

        private void ManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturerListPage());
        }
    }
}
