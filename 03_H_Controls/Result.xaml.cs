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
using System.Windows.Shapes;

namespace _03._H_Controls
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result()
        {
            InitializeComponent();
        }
        public Result(string fullName, string phoneNumber, string person, string roomType, string livingTime)
        {
            InitializeComponent();
            labelFullName.Content = fullName;
            labelPhoneNumer.Content = phoneNumber;
            labelLivingTime.Content = livingTime;
            labelPerson.Content = person;
            labelRoomType.Content = roomType;
        }

        private void ButtonResultOK(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
