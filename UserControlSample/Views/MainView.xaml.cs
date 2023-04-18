using Caliburn.Micro;
using CustomControl;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControlSample.Views
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
        public ObservableCollection<string> FileNames
        {
            get => (ObservableCollection<string>)GetValue(FileNamesProperty);
            set => SetValue(FileNamesProperty, value);
        }

        public static readonly DependencyProperty FileNamesProperty = DependencyProperty.Register(
          "FileNames",
          typeof(ObservableCollection<string>),
          typeof(UserControlView),
          new PropertyMetadata(default));

        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^-?[0-9]*[\\.,]?[0-9]?[0-9]?$");
            var tb = sender as TextBox;
            var futureText = "";
            if (tb.SelectedText != "")
            {
                futureText = tb.Text.Replace(tb.SelectedText, e.Text);
                e.Handled = !regex.IsMatch(futureText);
                return;
            }

            futureText = tb.Text + e.Text;
            e.Handled = !regex.IsMatch(futureText);
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var myInput = sender as TextBox;
            myInput.Text = myInput.Text.Replace(",", ".").Trim();
            myInput.CaretIndex = myInput.Text.Length;
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var myInput = sender as TextBox;
            System.Diagnostics.Debug.WriteLine(myInput.SelectedText);
        }


    }
}
