using Caliburn.Micro;

namespace WpfApp1.UserControls
{
    public class PickerViewModel : PropertyChangedBase
    {
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }
        public bool Active
        {
            get { return _active; }
            set 
            {
                _active = value;
                NotifyOfPropertyChange(() => Active);
            }
        }
        public int ControlHeight
        {
            get { return _controlHeight; }
            set 
            { 
                _controlHeight = value;
                NotifyOfPropertyChange(() => ControlHeight);
            }
        }
        public int ControlWidth
        {
            get { return _controlWidth; }
            set 
            { 
                _controlWidth = value;
                NotifyOfPropertyChange(() => ControlWidth);
            }
        }

        private int _number = 1;
        private bool _active = false;
        private int _controlHeight = 84;
        private int _controlWidth = 96;
    }
}
