using Caliburn.Micro;

namespace ShadowedTextBoxSample
{
    public class MainViewModel : Screen
    {
        private readonly ILog _log = LogManager.GetLog(typeof(MainViewModel));
        public MainViewModel(ILog log)
        {
            log.Info("le");
            _log.Info("eee");
        }
    }
}