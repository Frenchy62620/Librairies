using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShadowedTextBoxSample
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        int tt = 0;
        public MainView()
        {
            InitializeComponent();
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void ShadowedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"{e.KeyboardDevice.Modifiers} {e.Key}");
            //System.Diagnostics.Debug.WriteLine($"{Keyboard.Modifiers   {e.Key}")
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) > 0 && e.Key == Key.V)
            {
                System.Diagnostics.Debug.WriteLine($"{e.KeyboardDevice.Modifiers} {tt++}");
            }
        }
    }
}
