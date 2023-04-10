using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShadowedTextBoxSample
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {

            int startFloor = 1;
            int targetFloor = 10;
            int steps = 0;
            int current = startFloor;
            int upBtns = 2;
            int downBtns = 1;

            if (startFloor < targetFloor)
            {
                while (current < targetFloor && upBtns != 0)
                {
                    current += upBtns;
                    steps++;
                }
                while (current > targetFloor && downBtns != 0)
                {
                    current -= downBtns;
                    steps++;
                }
            }
            else
            {
                while (current < targetFloor && upBtns != 0)
                {
                    current += upBtns;
                    steps++;
                }
                while (current > targetFloor && downBtns == 0)
                {
                    current -= downBtns;
                    steps++;
                }
            }
            if (steps == 0)
                Console.WriteLine("use stairs");
            else
                Console.WriteLine($"{steps} steps");

            InitializeComponent();
        }
    }
}
