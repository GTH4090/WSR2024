using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WSR2024.Models;

namespace WSR2024.Classes
{
    public class Helper
    {
        public static WSR2024Entities Db = new WSR2024Entities();

        public static Doctor Logined = null;

        public static void Error(string  message = "Ошибка подкючения к БД")
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Info(string message)
        {
            MessageBox.Show(message, "Инфо", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
