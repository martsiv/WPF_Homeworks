using PropertyChanged;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace _06._1_L_MVVM
{
    [AddINotifyPropertyChangedInterface]
    public class MyColorRGB 
    {
        public short Alpha { get; set; }
        public short Red { get; set; }
        public short Green { get; set; }
        public short Blue { get; set; }
        public MyColorRGB()
        {
            Alpha = 0;
            Red = 0;
            Green = 0;
            Blue = 0;
        }
        [DependsOn("Alpha", "Red", "Green", "Blue")]
        public Color RGB => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        public override string ToString() //to hexColor as string
        {
            return $"#{Alpha.ToString("X2")}{Red.ToString("X2")}{Green.ToString("X2")}{Blue.ToString("X2")}";
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}
