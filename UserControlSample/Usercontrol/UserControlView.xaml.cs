using System;
using System.Collections;
using System.Collections.Generic;
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

namespace CustomControl
{
    /// <summary>
    /// Logique d'interaction pour UserControlView.xaml
    /// </summary>
    public partial class UserControlView : UserControl
    {
        public UserControlView()
        {
            InitializeComponent();
        }
        public IList FileNameItemsSource
        {
            get => (IList)GetValue(FileNameItemsSourceProperty);
            set => SetValue(FileNameItemsSourceProperty, value);
        }

        public static readonly DependencyProperty FileNameItemsSourceProperty = DependencyProperty.Register(
          "FileNameItemsSource",
          typeof(IList),
          typeof(UserControlView),
          new PropertyMetadata(default));
    }
}
