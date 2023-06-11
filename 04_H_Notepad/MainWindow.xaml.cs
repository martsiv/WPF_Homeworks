using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _04_H_Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] fontSizes = { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
        public MainWindow()
        {
            InitializeComponent();
            sizeComboBox.ItemsSource = fontSizes;
            sizeComboBox.SelectedIndex = 1;
        }
        private void OnClickAlignLeft(object sender, RoutedEventArgs e)
        {
            AlignLeft();
        }
        private void OnClickAlignCenter(object sender, RoutedEventArgs e)
        {
            AlignCenter();
        }
        private void OnClickAlignRight(object sender, RoutedEventArgs e)
        {
            AlignRight();
        }
        private void OnClickExit(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void OnClickNew(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }
        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateCaretPosition();
        }
        private void Align(TextAlignment textAlignment)
        {
            textBox.TextAlignment = textAlignment;
        }
        private void AlignCenter()
        {
            Align(TextAlignment.Center);
        }
        private void AlignLeft()
        {
            Align(TextAlignment.Left);
        }
        private void AlignRight()
        {
            Align(TextAlignment.Right);
        }
        private void UpdateCaretPosition()
        {
            int str = textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex);
            int smb = textBox.Text.Length;
            int wrd = textBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
            strings.Content = $"Strings: {str}";
            symbols.Content = $"Symbols: {smb}";
            words.Content = $"words: {wrd}";
        }
        private void HelpClic(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Notepad WPF", "Info");
        }
        private void ThemeClick(object sender, RoutedEventArgs e)
        {
            if (theme.IsChecked)
                ChangeBackground(Colors.White);
            else
                ChangeBackground(Colors.DarkGray);
        }
        private void ChangeBackground(Color color)
        {
            textBox.Background = new SolidColorBrush(color);
        }
        private void ChangeSize(object sender, SelectionChangedEventArgs e) => textBox.FontSize = int.Parse(sizeComboBox.SelectedItem.ToString());
        private void Undo(object sender, RoutedEventArgs e) => textBox.Undo();
        private void Redo(object sender, RoutedEventArgs e) => textBox.Redo();
        private void SelectedAll(object sender, RoutedEventArgs e) => textBox.SelectAll();
        private void DeselectAll(object sender, RoutedEventArgs e) => textBox.Select(textBox.SelectionStart, 0);
        private void Cut(object sender, RoutedEventArgs e) => textBox.Cut();
        private void Copy(object sender, RoutedEventArgs e) => textBox.Copy();
        private void Paste(object sender, RoutedEventArgs e) => textBox.Paste();
        private void Delete(object sender, RoutedEventArgs e) => textBox.Clear();
        private void Italic(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Italic)
                textBox.FontStyle = FontStyles.Normal;
            else
                textBox.FontStyle = FontStyles.Italic;
        }
        private void Underline(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations == TextDecorations.Underline)
                textBox.TextDecorations = null;
            else
                textBox.TextDecorations = TextDecorations.Underline;
        }
        private void Bold(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Bold)
                textBox.FontWeight = FontWeights.Regular;
            else
                textBox.FontWeight = FontWeights.Bold;
        }
        private void ChangeColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            textBox.Foreground = new SolidColorBrush(colorPicker.SelectedColor.Value);
        }
    }
}
