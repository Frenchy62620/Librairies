using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LivechartTest.Views
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void But_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            var myLabel = (Label)this.FindName(button.Name.Replace("b" ,"l"));
            myLabel.Visibility = Visibility.Hidden;
        }
        private void But_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            var myLabel = (Label)this.FindName(button.Name.Replace("b", "l"));
            myLabel.Visibility = Visibility.Visible;
        }
    }
}
