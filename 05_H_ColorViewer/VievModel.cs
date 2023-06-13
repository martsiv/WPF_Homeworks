using _06._1_L_MVVM.Helper;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _06._1_L_MVVM
{
    [AddINotifyPropertyChangedInterface]
    public class VievModel
    {
        public ObservableCollection<Color> colors = new ObservableCollection<Color>();
        public IEnumerable<Color> MyColors => colors;
        public MyColorRGB Color2 { get; set; }
        private readonly RelayCommand addColor;
        private readonly RelayCommand removeColor;
        private Color? selectedColor;
        public Color? SelectedColor 
        { 
            get => selectedColor; 
            set 
            { 
                selectedColor = value; 
                Color2.Red = value.Value.R; 
                Color2.Alpha = value.Value.A;
                Color2.Green = value.Value.G;
                Color2.Blue = value.Value.B;
            } 
        }
        public ICommand AddColor => addColor;
        public ICommand RemoveColor => removeColor;
        public VievModel()
        {
            Color2 = new MyColorRGB() { Alpha = 100, Blue = 23, Green = 46, Red = 120 };

            addColor = new((o) => Add(), (с) => !colors.Contains(Color2.RGB));
            removeColor = new((o) => Remove(), (o) => selectedColor != null);
        }
        public void Add()
        {
            colors.Add(Color2.RGB);
        }
        public void Remove() 
        {
            colors.Remove(selectedColor.Value);
        }
    }
}
