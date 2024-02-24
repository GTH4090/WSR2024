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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();

            try
            {
                DoctorCbx.ItemsSource = Db.Doctor.ToList();
                ViewCbx.SelectedIndex = 0;
                DoctorCbx.SelectedIndex = 0;

                FromDp.SelectedDate = DateTime.Now.AddDays(-7);
                ToDp.SelectedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            
        }

        private void loadSchedule()
        {

            try
            {
                if(DoctorCbx.SelectedItem != null && FromDp.SelectedDate != null && ToDp.SelectedDate != null)
                {
                    ScheduleGrid.Children.Clear();
                    ScheduleGrid.ColumnDefinitions.Clear();
                    var item = DoctorCbx.SelectedItem as Doctor;
                    var start = FromDp.SelectedDate.Value;
                    var end = ToDp.SelectedDate.Value;
                    var schedule = Db.PatientEvents.ToList().Where(el => el.DoctorId == item.Id && el.Date > start && el.Date < end).OrderBy(el => el.Date).ToList();

                    if(ViewCbx.SelectedIndex == 0)
                    {
                        for (int i = 0; i < (end - start).TotalDays; i++)
                        {
                            var date = start.AddDays(i);
                            ScheduleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
                            Label label = new Label();
                            label.Width = double.NaN;
                            label.Content = date.ToString("d");
                            Grid.SetColumn(label, i);
                            Grid.SetRow(label, 0);

                            ScheduleGrid.Children.Add(label);
                            
                        }
                        foreach(var it in schedule)
                        {
                            Label label1 = new Label();
                            label1.Width = double.NaN;
                            label1.Content = it.Name;

                            if(it.TypeId == 0)
                            {
                                label1.Background = Brushes.LightGreen;

                            }
                            if(it.TypeId == 1)
                            {
                                label1.Background = Brushes.LightBlue;

                            }
                            Grid.SetColumn(label1, (int)(end.Date.Date - it.Date.Date).TotalDays);
                            Grid.SetRow(label1, 1);
                            ScheduleGrid.Children.Add(label1);
                        }
                    }
                    if (ViewCbx.SelectedIndex == 1)
                    {
                        for (int i = 0; i < (end - start).TotalDays + 7; i += 7)
                        {
                            var date = start.AddDays(i);
                            var dateend = date.AddDays(7);
                            ScheduleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(150) });
                            Label label = new Label();
                            label.Width = double.NaN;
                            label.Content = date.ToString("d") + "-" + dateend.ToString("d");
                            Grid.SetColumn(label, i / 7);
                            Grid.SetRow(label, 0);

                            ScheduleGrid.Children.Add(label);
                            TextBox label1 = new TextBox();
                            label1.IsReadOnly = true;
                            label1.Width = double.NaN;
                            label1.Height = double.NaN;
                            Grid.SetColumn(label1, i / 7);
                            Grid.SetRow(label1, 1);

                            foreach (var it in schedule.Where(el => el.Date.Date >= date.Date && el.Date.Date <= dateend.Date))
                            {
                                
                                label1.Text += it.Name + "\n";

                            }
                            ScheduleGrid.Children.Add(label1);

                        }

                    }
                    

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void DoctorCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadSchedule();
        }

        private void ViewCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadSchedule();
        }

        private void FromDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            loadSchedule();
        }

        private void ToDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            loadSchedule();
        }
    }
}
