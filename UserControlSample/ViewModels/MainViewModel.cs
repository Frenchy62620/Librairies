using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UserControlSample.ViewModels
{
    public class MainViewModel : Screen
    {
        public BindableCollection<string> FileNames { get; set; }
        public BindableCollection<Lines> Lines { get; set; }
        private int canvasWidth;
        public int CanvasWidth
        {
            get { return canvasWidth; }
            set
            {
                canvasWidth = value;
                NotifyOfPropertyChange(() => CanvasWidth);
            }
        }
        private int canvasHeight;
        public int CanvasHeight
        {
            get { return canvasHeight; }
            set
            {
                canvasHeight = value;
                NotifyOfPropertyChange(() => CanvasHeight);
            }
        }

        public MainViewModel()
        {
            var a = new List<Lines>()
            {
                new Lines {X = 20, Y = 20, Width = 400, Height = 50}
            };
            canvasWidth = 500;
            canvasHeight = 300;
            Lines = new BindableCollection<Lines>(a);
            FileNames = new BindableCollection<string>() { "Test1", "test2" };
        }

        public void ChangeColor(Rectangle sender)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.AliceBlue);
            sender.Fill = color;
        }
    }
}
