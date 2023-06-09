﻿using Caliburn.Micro;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GridHelpersSample
{
    public class MainViewModel : Screen
    {
        private readonly IResolutionRoot _resolutionRoot;
        public BindableCollection<ButtonViewModel> ButtonViewModels { get; set; }
        
        public MainViewModel(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
            RowCount = "20";
            ColumnCount = "20";
            StarRows = "(0,1),(1,1),(2,1)";
            StarColumns = "(0,1),(1,2),(2,1)";
            ButtonViewModels = new BindableCollection<ButtonViewModel>(CreateButton());
            PixelRows = "";
            PixelColumns = "";


        }
        protected override void OnViewLoaded(object view)
        {
            var myView = _resolutionRoot.Get<MainView>();
            base.OnViewLoaded(view);
            var v = view as MainView;
        }
        #region datas for defining grid
        private string rowCount;
        public string RowCount
        {
            get { return rowCount; }
            set
            {
                rowCount = value;
                NotifyOfPropertyChange(() => RowCount);
            }
        }
        private string columnCount;
        public string ColumnCount
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
            IEnumerable<PropertyInfo> properties = typeof(MainViewModel).GetProperties()
                                                        .Where(p => Regex.IsMatch(p.Name, "Row|Column"));
            foreach (PropertyInfo property in properties)
            {
                System.Diagnostics.Debug.WriteLine(property.Name);
                //NotifyOfPropertyChange(property.Name);
            }


            var tt = CreateButton();
            ButtonViewModels = new BindableCollection<ButtonViewModel>(tt);
        }
        public void TextBox_LostFocus(TextBox tb, string value)
        {
            var myView = _resolutionRoot.Get<MainView>();
            var t = myView.TestGrid;
            //NotifyOfPropertyChange(tb.Name);
        }


        public List<ButtonViewModel> CreateButton()
        {
            var myView = _resolutionRoot.Get<MainView>();
            var t = myView.TestGrid;
            var list = new List<ButtonViewModel>();
            for (int i = 0; i < int.Parse(RowCount); i++)
            {
                for (int j = 0; j < int.Parse(ColumnCount); j++)
                {
                    var button = new ButtonViewModel
                    {
                        Content = $"R{i} C{j}",
                        GridRow = i,
                        GridColumn = j
                    };

                    list.Add(button);

                    //Caliburn.Micro.Action.SetTargetWithoutContext(button, this);
                    //Caliburn.Micro.Message.SetAttach(button, "ButtonClick");
                    //Caliburn.Micro.Message.SetHandler (button, "OnButtonClick");
                    
                    //var h = myView.TestGrid.Children.Add(button);
                    ////myView.TestGrid
                    //Grid.SetRow(button, i);
                    //Grid.SetColumn(button, j);
                }
            }
            return list;
        }
    }
}
