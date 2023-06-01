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

namespace _01_H_Intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string previous_digit = string.Empty;
        private string current_digit = string.Empty;
        enum Operations { Add, Minus, Mult, Div, None = -1 };
        private int operation = (int)Operations.None;
        private int last_operation = (int)Operations.None;
        private string last_digit = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            CurrentTextBox.Text = "0";
        }

        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            current_digit = string.Empty;
            CurrentTextBox.Text = "0";
        }
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            current_digit = string.Empty;
            previous_digit = string.Empty;
            CurrentTextBox.Text = "0";
            HistoryTextBox.Text = string.Empty;
            operation = (int)Operations.None; ;
        }
        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            if (IsNonZeroNumber(current_digit))
            {
                current_digit = RemoveLastDigit(current_digit);
                CurrentTextBox.Text = current_digit;
            }
        }
        public static bool IsNonZeroNumber(string input)
        {
            // Перевірка, чи рядок містить ціле або дробове число відмінне від нуля
            double number;
            return double.TryParse(input, out number) && number != 0;
        }
        public static string RemoveLastDigit(string input)
        {
            // Видалення останньої цифри з кінця рядка
            StringBuilder sb = new StringBuilder(input);
            if (sb.Length > 1)
            {
                sb.Length--;  // Видалення останнього символу
            }
            else
            {
                sb[0] = '0';  // Заміна єдиної цифри на нуль
            }
            return sb.ToString();
        }
        private void Button_Click_Digit(object sender, RoutedEventArgs e)
        {
            current_digit += (sender as Button).Content.ToString();
            CurrentTextBox.Text = current_digit;
        }
        private void Button_Click_Div(object sender, RoutedEventArgs e)
        {
            if (previous_digit == string.Empty && current_digit == string.Empty && operation == (int)Operations.None)
                return;
            if (previous_digit != string.Empty && operation != (int)Operations.None)
                Button_Click_Equal(sender, e);
            else if (previous_digit == string.Empty)
                previous_digit = current_digit;
            current_digit = string.Empty;
            HistoryTextBox.Text = previous_digit + " / ";
            operation = (int)Operations.Div;
        }
        private void Button_Click_Mult(object sender, RoutedEventArgs e)
        {
            if (previous_digit == string.Empty && current_digit == string.Empty && operation == (int)Operations.None)
                return;

            if (previous_digit != string.Empty && operation != (int)Operations.None)
                Button_Click_Equal(sender, e);
            else if (previous_digit == string.Empty)
                previous_digit = current_digit;
            current_digit = string.Empty;
            HistoryTextBox.Text = previous_digit + " * ";
            operation = (int)Operations.Mult;
        }
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            if (previous_digit == string.Empty && current_digit == string.Empty && operation == (int)Operations.None)
            {
                current_digit = "-";
                CurrentTextBox.Text = "-0";
                return;
            }
            if (previous_digit != string.Empty && operation != (int)Operations.None)
                Button_Click_Equal(sender, e);
            else if (previous_digit == string.Empty)
                previous_digit = current_digit;
            current_digit = string.Empty;
            HistoryTextBox.Text = previous_digit + " - ";
            operation = (int)Operations.Minus;
        }
        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            if (previous_digit == string.Empty && current_digit == string.Empty && operation == (int)Operations.None)
                return;
            if (previous_digit != string.Empty && operation != (int)Operations.None)
                Button_Click_Equal(sender, e);
            else if (previous_digit == string.Empty)
                previous_digit = current_digit;
            current_digit = string.Empty;
            HistoryTextBox.Text = previous_digit + " + ";
            operation = (int)Operations.Add;
        }
        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (current_digit.Contains(','))
                return;
            if (current_digit != string.Empty && current_digit == "-")
                current_digit = "-0,";
            else if (current_digit != string.Empty)
                current_digit += ",";
            else
                current_digit = "0,";
            CurrentTextBox.Text = current_digit;
        }
        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            if (current_digit == string.Empty && last_operation != -1)
            {
                current_digit = last_digit;
                operation = last_operation;
                switch ((Operations)last_operation)
                {
                    case Operations.Add:
                        HistoryTextBox.Text = $"{previous_digit} + ";
                        break;
                    case Operations.Minus:
                        HistoryTextBox.Text = $"{previous_digit} - ";
                        break;
                    case Operations.Mult:
                        HistoryTextBox.Text = $"{previous_digit} * ";
                        break;
                    case Operations.Div:
                        HistoryTextBox.Text = $"{previous_digit} / ";
                        break;
                    default:
                        break;
                }
            }
            if (operation == -1 && last_operation == -1)
                HistoryTextBox.Text = CurrentTextBox.Text;
            else
            {
                switch ((Operations)operation)
                {
                    case Operations.Add:
                        CurrentTextBox.Text = (decimal.Parse(previous_digit) + decimal.Parse(current_digit)).ToString();
                        break;
                    case Operations.Minus:
                        CurrentTextBox.Text = (decimal.Parse(previous_digit) - decimal.Parse(current_digit)).ToString();
                        break;
                    case Operations.Mult:
                        CurrentTextBox.Text = (decimal.Parse(previous_digit) * decimal.Parse(current_digit)).ToString();
                        break;
                    case Operations.Div:
                        if (previous_digit != string.Empty && current_digit == "0")
                        {
                            previous_digit = string.Empty;
                            current_digit = string.Empty;
                            operation = (int)Operations.None;
                            HistoryTextBox.Text = string.Empty;
                            CurrentTextBox.Text = "Cannot divide by zero";
                            return;
                        }
                        CurrentTextBox.Text = (decimal.Parse(previous_digit) / decimal.Parse(current_digit)).ToString();
                        break;
                    default:
                        break;
                }
                HistoryTextBox.Text += current_digit;
                HistoryTextBox.Text += " = ";
                previous_digit = CurrentTextBox.Text;
            }
            last_digit = current_digit;
            current_digit = string.Empty;
            last_operation = operation;
            operation = (int)Operations.None;
        }
    }
}
