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
using System.Drawing;
using System.Windows.Interop;
using Microsoft.Win32;
using System.IO;

namespace WSR2024.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration(int id = -1)
        {
            InitializeComponent();
            if(id == -1)
            {
                grid1.DataContext = new Patient();
                lastVisitDateDatePicker.SelectedDate = DateTime.Now;
                insuarnceEndDateDatePicker.SelectedDate = DateTime.Now;
                medDateDatePicker.SelectedDate = DateTime.Now;
                nextVisitDateDatePicker.SelectedDate = DateTime.Now;
            }
            else
            {
                grid1.DataContext = Db.Patient.FirstOrDefault(el => el.Id == id);
                grid1.IsEnabled = false;
            }
            
        }

        private void QrGenBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string qr = medIdTextBox.Text;
                if(Db.Patient.FirstOrDefault(el => el.MedId == qr) == null)
                {
                    QRCodeEncoder encoder = new QRCodeEncoder();
                    var qrcode = encoder.Encode(qr);
                    var source = qrcode.GetHbitmap();
                    QrImg.Source = Imaging.CreateBitmapSourceFromHBitmap(source, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = ".png|*.png";
                    if (saveFile.ShowDialog() == true)
                    {
                        qrcode.Save(saveFile.FileName);

                    }
                }
                else
                {
                    Info("Такой идент. код мед карты уже есть");
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void PrintQrBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(QrImg, "QR код пациента");
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Db.Patient.FirstOrDefault(el => el.PasspoerNumber == passpoerNumberTextBox.Text && el.PassportSerial== passportSerialTextBox.Text) == null && 
                    Db.Patient.FirstOrDefault(el => el.MedId == medIdTextBox.Text) == null)
                {
                    Db.Patient.Add(grid1.DataContext as Patient);
                    Db.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    Info("Такой пациент либо ид. код карты уже существуют");
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = ".png|*.png|.jpg|*.jpg";
                if(openFile.ShowDialog() == true)
                {
                    (grid1.DataContext as Patient).Photo = File.ReadAllBytes(openFile.FileName);
                    PhotoImg.Source = new ImageSourceConverter().ConvertFromString(openFile.FileName) as ImageSource;
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
