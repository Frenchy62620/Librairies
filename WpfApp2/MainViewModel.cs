using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            SetBrushes();
        }

        private ImageBrush _trABrush;
        public ImageBrush TrABrush
        {
            get => _trABrush;
            set
            {
                if (Equals(value, _trABrush)) return;
                _trABrush = value;
                OnPropertyChanged();
            }
        }

        public void SetBrushes() => TrABrush = GetBrush(Colors.Violet);

        public ImageBrush GetBrush(Color color)
        {
            var w = 300;
            var h = 200;
            var size = w * h * 3;
            var array = GetRGBArray(color, size);
            var wbmp = new WriteableBitmap(w, h, 96, 96, PixelFormats.Rgb24, null);
            var stride = (w * PixelFormats.Rgb24.BitsPerPixel + 7) / 8;
            wbmp.WritePixels(new Int32Rect(0, 0, w, h), array, stride, 0);
            return new ImageBrush(wbmp);
        }

        private byte[] GetRGBArray(Color color, int size)
        {
            var array = new byte[size];
            for (var i = 0; i < size - 3; i += 3)
            {
                array[i] = color.R;
                array[i + 1] = color.G;
                array[i + 2] = color.B;
            }
            return array;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
