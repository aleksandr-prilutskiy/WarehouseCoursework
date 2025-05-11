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

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for StaffEditPage.xaml
    /// </summary>
    public partial class StaffEditPage : Page
    {
        public StaffEditPage()
        {
            InitializeComponent();
            DateOfBirthDP.Text = GV.Staff.DateOfBirthStaff.ToString();
            DataContext = GV.Staff;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            string cifri = "1234567890";
            if (string.IsNullOrWhiteSpace(SurnameTB.Text))
            {
                MB.Error("Введите фамилию!");
                SurnameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(SurnameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Фамилия не может содержать цифры!");
                SurnameTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MB.Error("Введите имя!");
                NameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(NameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Имя не может содержать цифры!");
                NameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(MiddeNameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Отчество не может содержать цифры!");
                MiddeNameTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(DateOfBirthDP.Text))
            {
                MB.Error("Введите дату рождения!");
                DateOfBirthDP.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PhoneTB.Text))
            {
                MB.Error("Введите телефон!");
                PhoneTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(PhoneTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Номер телефона должен содержать только цифры!");
                PhoneTB.Focus();
                return;
            }
            else if (PhoneTB.Text.Length != 11)
            {
                MB.Error("Номер телефона должна состоять из 11 цифр!" +
                    "\nПример: 79001234545");
                PhoneTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(MailTB.Text))
            {
                MB.Error("Введите почту!");
                MailTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(SeriesPassportTB.Text))
            {
                MB.Error("Введите серию паспорта!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(SeriesPassportTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Серия паспорта должена содержать только цифры!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (SeriesPassportTB.Text.Length != 4)
            {
                MB.Error("Серия паспорта должна состоять из 4 цифр!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(NumberPassportTB.Text))
            {
                MB.Error("Введите номер паспорта!");
                NumberPassportTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(NumberPassportTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Номер паспорта должена содержать только цифры!");
                NumberPassportTB.Focus();
                return;
            }
            else if (NumberPassportTB.Text.Length != 6)
            {
                MB.Error("Номер паспорта должна состоять из 6 цифр!");
                NumberPassportTB.Focus();
                return;
            }
            else
            {
                try
                {
                    EditStaff();
                    MB.Info("Изминения успешно сохранены!");
                    NavigationService.Navigate(new StaffListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void EditStaff()
        {
            string middleCheck;
            if (string.IsNullOrEmpty(MiddeNameTB.Text))
            {
                middleCheck = "Отсутствует";
            }
            else
            {
                middleCheck = MiddeNameTB.Text;
            }
            var staff = App.Context.Staff.FirstOrDefault(x => x.IdStaff == GV.Staff.IdStaff);

            staff.SurnameStaff = SurnameTB.Text;
            staff.NameStaff = NameTB.Text;
            staff.MiddleNameStaff = middleCheck;
            staff.DateOfBirthStaff = DateTime.Parse(DateOfBirthDP.Text.ToString());
            staff.PhoneStaff = PhoneTB.Text;
            staff.MailStaff = MailTB.Text;
            staff.SeriesPassportStaff = SeriesPassportTB.Text;
            staff.NumberPassportStaff = NumberPassportTB.Text;

            App.Context.SaveChanges();
        }
    }
}
