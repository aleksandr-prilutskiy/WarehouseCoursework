using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WarehouseCoursework.ClassFolder
{
    internal class MB
    {
        public static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message,
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void Error(string ex)
        {
            MessageBox.Show(ex,
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void Info(string ex)
        {
            MessageBox.Show(ex,
                "Информация",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static bool Quiestion(string ex)
        {
            return MessageBoxResult.Yes == MessageBox.Show(ex,
                "Вопрос",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
        }

        public static void Exit()
        {
            var question = MB.Quiestion("Вы действительно хотите выйти?");

            if (question)
            {
                App.Current.Shutdown();
            }
        }
    }
}
