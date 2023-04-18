using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Logique d'interaction pour PickerView.xaml
    /// </summary>
    public partial class PickerView : UserControl
    {
        public PickerView()
        {
            InitializeComponent();
        }
        #region Dependency Properties
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(PickerView), new PropertyMetadata(1));
        public static readonly DependencyProperty ActiveProperty =
            DependencyProperty.Register("Active", typeof(bool), typeof(PickerView), new PropertyMetadata(false));
        #endregion
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }

    }
}
