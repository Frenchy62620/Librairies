using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour RectZone.xaml
    /// </summary>
    public partial class RectZone : UserControl
    {
        public RectZone()
        {
            InitializeComponent();
        }
        public ImageBrush CanImageBrush
        {
            get { return (ImageBrush)GetValue(CanImageBrushProperty); }
            set { SetValue(CanImageBrushProperty, value); }
        }

        public static readonly DependencyProperty CanImageBrushProperty =
            DependencyProperty.Register(nameof(CanImageBrush), typeof(ImageBrush), typeof(RectZone), new PropertyMetadata(null));
    }
}
