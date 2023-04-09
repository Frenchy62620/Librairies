using System.Windows;
using System.Windows.Controls;

namespace GridHelpersSample
{
    /// <summary>
    /// Logique d'interaction pour Main1View.xaml
    /// </summary>
    public partial class Main1View : Window
    {
        public Grid myGrid { get; set; }
        public int n = 9;
        public Main1View()
        {
            InitializeComponent();
        }
        public void CreateButton()
        {
            myGrid = new Grid();
            myGrid.ShowGridLines = true;

            // Add columns to the grid
            for (int i = 0; i < n; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef);
            }

            // Add rows to the grid
            for (int i = 0; i < n; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                myGrid.RowDefinitions.Add(rowDef);
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var button = new Button
                    {
                        Content = $"R{i} C{j}",
                    };
                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);

                    myGrid.Children.Add(button);
                    //Caliburn.Micro.Action.SetTargetWithoutContext(button, this);
                    //Caliburn.Micro.Message.SetAttach(button, "ButtonClick");
                    //Caliburn.Micro.Message.SetHandler (button, "OnButtonClick");

                    //var h = myView.TestGrid.Children.Add(button);
                    ////myView.TestGrid
                    //Grid.SetRow(button, i);
                    //Grid.SetColumn(button, j);
                }
            }
            MainGrid.Children.Add(myGrid);
            Grid.SetRow(myGrid, 1);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Remove(myGrid);
            CreateButton();
            n--;
        }
    }
}
