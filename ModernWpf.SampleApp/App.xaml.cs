using System.Windows;

namespace ModernWpf.SampleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsMultiThreaded { get; } = false;
    }
}
