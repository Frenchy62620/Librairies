using CustomControl;
using System.Collections.ObjectModel;
using System.Windows;

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
    }
}
