using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WarehouseCoursework.ClassFolder;

namespace WarehouseCoursework.WindowFolder
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MB.Error("Введите логин!");
                LoginTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MB.Error("Введите пароль!");
                PasswordPB.Focus();
                return;
            }
            else if (LoginTB.Text.Length < 3)
            {
                MB.Error("Логин слишком короткий!");
                LoginTB.Focus();
                return;
            }
            else if (PasswordPB.Password.Length < 3)
            {
                MB.Error("Пароль слишком короткий!");
                PasswordPB.Focus();
                return;
            }
            else
            {
                try
                {
                    var user = App.Context.User.FirstOrDefault(x => x.LoginUser == LoginTB.Text);

                    if ((user == null) || (user.PasswordUser != PasswordPB.Password))
                    {
                        MB.Error("Вы ввели неверный логин или пароль!");
                        return;
                    }
                    else
                    {
                        GV.User = user;
                        MB.Info($"Добро пожаловать, {user.LoginUser}!");
                        new AdminFolder.MainAdminWindow().Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MB.Exit();
        }
    }
}
