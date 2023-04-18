using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1.UserControls
{
    public class SliderViewModel : Screen
    {
        private ObservableCollection<MarkerPickerViewModel> _pickers;
        public ObservableCollection<MarkerPickerViewModel> Pickers
        {
            get { return _pickers; }
            set 
            {
                _pickers = value;
                NotifyOfPropertyChange(() => Pickers);
            }
        }
        public int Start
        {
            get { return _start; }
            set 
            { 
                _start = value;
                NotifyOfPropertyChange(() => Start);
            }
        }
        public BitmapSource CroppedImage
        {
            get => new CroppedBitmap(_originalImage, new Int32Rect(Start, 0, SliderWidth, SliderHeight));
        }
        public int SliderHeight
        {
            get { return _sliderHeight; }
            set 
            {
                _sliderHeight = value; 
                NotifyOfPropertyChange(() => SliderHeight);
            }
        }
        public int SliderWidth
        {
            get { return _sliderWidth; }
            set 
            { 
                _sliderWidth = value;
                NotifyOfPropertyChange(() => SliderWidth);
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
        private int _sliderHeight = 82;
        private int _sliderWidth = 1080;
        private int _controlWidth = 1080;
        private int _controlHeight = 200;
        private int _start = 0;
        BitmapImage _originalImage;

        public SliderViewModel()
        {
            LoadResources();
            InitPickers();
        }

        private void LoadResources()
        {
            _originalImage = (BitmapImage)Application.Current.FindResource("ScaleImage");
        }

        private void InitPickers()
        {
            int elementWidth = 96;
            int elementHeight = 84;
            _pickers = new ObservableCollection<PickerViewModel>();
            for (int i = 1; i <= 10; i++)
            {
                _pickers.Add(new PickerViewModel()
                {
                    ControlWidth = elementWidth,
                    ControlHeight = elementHeight,
                    Number = i,
                    Active = false,
                });
            }
        }
    }
}
