using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlSample.ViewModels
{
    public class MainViewModel : Screen
    {
        public BindableCollection<string> FileNames { get; set; }

        public MainViewModel()
        {
            FileNames = new BindableCollection<string>() { "Test1", "test2" };
        }
    }
}
