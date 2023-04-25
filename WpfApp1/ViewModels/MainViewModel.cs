using Caliburn.Micro;
using Ninject;
using Ninject.Syntax;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IResolutionRoot resolutionRoot;
        private readonly IEventAggregator eventAggregator;
        public MainViewModel(IResolutionRoot resolutionRoot, IEventAggregator eventAggregator)
        {
            this.resolutionRoot = resolutionRoot;
            this.eventAggregator = eventAggregator;
        }
        #region first stackpanel
        public async void DoModal()
        {
            //var vm = new MyDialogViewModel();
            var vm = resolutionRoot.Get<MyModalDialogViewModel>();
            var manager = resolutionRoot.Get<IWindowManager>();

            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = "COUCOU";
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanMinimize;

            var result = await manager.ShowDialogAsync(vm, null, settings);

            MessageBox.Show($"The dialog returns with the result {result}");
        }

        public async void DoClose()
        {
            //Close Main Window
            await TryCloseAsync();
        }
        public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(200);
            return true; //false to refuse to close, true to accept
        }
        #endregion

        #region second stackpanel
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
                NotifyOfPropertyChange(() => CanClickOnMe);
            }
        }
        public bool CanClickOnMe => !string.IsNullOrEmpty(Message);
        public void ClickOnMe()
        {
            Message = "";
        }
        public void Text_MouseEnter(object sender, MouseEventArgs e)
        {
            var s = sender as TextBox;
            s.ToolTip = "Hovered";
        }
        #endregion
    }
}
