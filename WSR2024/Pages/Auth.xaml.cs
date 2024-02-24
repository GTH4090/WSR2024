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
using static WSR2024.Classes.Helper;
using WSR2024.Models;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Drawing;

namespace WSR2024.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = ".png|*.png";
                if(openFileDialog.ShowDialog() == true)
                {
                 
                    QRCodeDecoder qRCode = new QRCodeDecoder();
                    string x = qRCode.Decode(new QRCodeBitmapImage(new Bitmap(System.Drawing.Image.FromFile(openFileDialog.FileName))));
                    var item = Db.Patient.FirstOrDefault(el => el.MedId == x);
                    if (item != null)
                    {
                        NavigationService.Navigate(new Registration(item.Id));
                    }
                }

                
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void HospBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HospitalizationPage());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Db.Doctor.FirstOrDefault(el => el.Name == DoctorTbx.Text) != null)
            {
                var item = Db.Doctor.FirstOrDefault(el => el.Name == DoctorTbx.Text);
                Logined = item;
                NavigationService.Navigate(new SchedulePage());
            }
        }
    }
}
