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

namespace WSR2024.Pages
{
    /// <summary>
    /// Логика взаимодействия для HospitalizationPage.xaml
    /// </summary>
    public partial class HospitalizationPage : Page
    {
        public HospitalizationPage()
        {
            InitializeComponent();

            try
            {
                PatientCbx.ItemsSource = Db.Patient.ToList();
                conditionsIdComboBox.ItemsSource = Db.Conditions.ToList();
                grid2.DataContext = new Hospitalization();
                PatientCbx.SelectedIndex = 0;
                dataDatePicker.SelectedDate = DateTime.Now;
                conditionsIdComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            

        }

        private void PatientCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var item = PatientCbx.SelectedItem as Patient;
                grid1.DataContext = item;
                (grid2.DataContext as Hospitalization).PationtId = item.Id;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var item = conditionsIdComboBox.SelectedItem as Conditions;
                (grid2.DataContext as Hospitalization).ConditionsId = item.Id;
                Db.Hospitalization.Add(grid2.DataContext as Hospitalization);
                Db.SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
