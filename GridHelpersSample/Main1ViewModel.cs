using Caliburn.Micro;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GridHelpersSample
{
    public class Main1ViewModel : Screen
    {
        private readonly IResolutionRoot _resolutionRoot;

        public Main1ViewModel(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
            RowCount = 3;
            ColumnCount = 3;
        }

        #region datas for defining grid
        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
            set
            {
                rowCount = value;
                NotifyOfPropertyChange(() => RowCount);
            }
        }
        private int columnCount;
        public int ColumnCount
        {
            get { return columnCount; }
            set
            {
                columnCount = value;
                NotifyOfPropertyChange(() => ColumnCount);
            }
        }
        private string starRows;
        public string StarRows
        {
            get { return starRows; }
            set
            {
                starRows = value;
                NotifyOfPropertyChange(() => StarRows);
            }
        }
        private string starColumns;
        public string StarColumns
        {
            get { return starColumns; }
            set
            {
                starColumns = value;
                NotifyOfPropertyChange(() => StarColumns);
            }
        }

        private string pixelRows;
        public string PixelRows
        {
            get { return pixelRows; }
            set
            {
                pixelRows = value;
                NotifyOfPropertyChange(() => PixelRows);
            }
        }
        private string pixelColumns;
        public string PixelColumns
        {
            get { return pixelColumns; }
            set
            {
                pixelColumns = value;
                NotifyOfPropertyChange(() => PixelColumns);
            }
        }
        #endregion

        public void Valider()
        {
            //IEnumerable<PropertyInfo> properties = typeof(MainViewModel).GetProperties()
            //                                            .Where(p => Regex.IsMatch(p.Name, "Row|Column"));
            //foreach (PropertyInfo property in properties)
            //{
            //    System.Diagnostics.Debug.WriteLine(property.Name);
            //    //NotifyOfPropertyChange(property.Name);
            //}

            return;
            CreateButton();
        }

        private void CreateButton()
        {
            Main.CreateButton();
            MainGrid.DataContext = Main;
            var myGrid = new Grid();
            
            myGrid.Name = "Toto";
            myGrid.ShowGridLines = true;
            Main.MainGrid.Children.Add(myGrid);
            
            Grid.SetRow(myGrid, 1);
            // Add columns to the grid
            for (int i = 0; i < ColumnCount; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef);
            }

            // Add rows to the grid
            for (int i = 0; i < RowCount; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                myGrid.RowDefinitions.Add(rowDef);
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    //var button = new ButtonViewModel
                    //{
                    //    Content = $"R{i} C{j}",
                    //    GridRow = i,
                    //    GridColumn = j
                    //};

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
            //MainGrid.Children.Add(myGrid);
            //Grid.SetRow(myGrid, 1);
        }

        private Grid MainGrid => _resolutionRoot.Get<Main1View>().MainGrid;
        private Main1View Main => _resolutionRoot.Get<Main1View>();
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }
    }
}
