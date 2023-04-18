using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> lengthExceeded ;
        public ObservableCollection<string> LengthExceeded
        {
            get { return lengthExceeded; }
            set
            {
                lengthExceeded = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<string>();
            list.Add("Folder1/file1");
            list.Add("Folder1/file2");
            list.Add("Folder1/file3");
            LengthExceeded = new ObservableCollection<string>(list);
            //lvFiles.ItemsSource = LengthExceeded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
