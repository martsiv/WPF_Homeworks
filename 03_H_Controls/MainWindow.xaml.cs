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

namespace _03._H_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i_persons = 0;
        public MainWindow()
        {
            InitializeComponent();
            persons.Content = i_persons;
        }

        private void CheckedTerms(object sender, RoutedEventArgs e)
        {
            if (terms.IsChecked == true)
                OK.IsEnabled = true;
            else OK.IsEnabled = false;
        }

        private void ClickCancel(object sender, RoutedEventArgs e)
        {
            fullName.Clear();
            phoneNumber.Clear();
            i_persons = 0;
            persons.Content = i_persons;
            roomTypeGrid.Children.OfType<RadioButton>().ToList().ForEach(radioButton => radioButton.IsChecked = false);
        }

        private void ClickOK(object sender, RoutedEventArgs e)
        {
            bool isOK = true;
            if (string.IsNullOrEmpty(fullName.Text) == true)
                isOK = false;
            if (string.IsNullOrEmpty(phoneNumber.Text) == true)
                isOK = false;
            if (string.IsNullOrEmpty(persons?.Content?.ToString()) == true)
                isOK = false;
            string roomType = roomTypeGrid.Children.OfType<RadioButton>()?.FirstOrDefault(radioButton => radioButton.IsChecked == true)?.Name ?? string.Empty;

            if (roomType == string.Empty)
                isOK = false;
            if (calendar.SelectedDate == null)
                isOK = false;
          
            if (isOK == false)
                MessageBox.Show("First enter all data!");
            else
                new Result(fullName.Text, phoneNumber.Text, persons.Content.ToString(), roomType, $"From: {calendar.SelectedDates.First().ToShortDateString()}/ To: {calendar.SelectedDates.Last().ToShortDateString()}").ShowDialog();
        }

        private void ClickRepeatBttPersons(object sender, RoutedEventArgs e)
        {
            i_persons = 12 < ++i_persons ? 0 : i_persons;
            persons.Content = i_persons;
        }
    }
}
