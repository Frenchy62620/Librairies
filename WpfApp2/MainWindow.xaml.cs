using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private bool scrollViewActive = true;
        private int timeTowait = 5000; // en ms
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            scrollViewActive = false;
            await Task.Delay(timeTowait);
            scrollViewActive = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            scrollViewActive = true;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!scrollViewActive)
            {
                ScrollViewer scrollViewer = e.OriginalSource as ScrollViewer;
                scrollViewer.ScrollToVerticalOffset(0);
                return;
            }
        }
    }
}

