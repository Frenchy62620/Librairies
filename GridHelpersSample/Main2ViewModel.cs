using Caliburn.Micro;
using Ninject;
using Ninject.Syntax;
using System.Collections.Generic;

namespace GridHelpersSample
{
    public class Main2ViewModel : Screen
    {
        private readonly IResolutionRoot _resolutionRoot;
        private readonly IKernel _kernel;
        public BindableCollection<ButtonViewModel> ButtonViewModels { get; set; }
        public MyGridViewModel myGridViewModel { get; set; }
        public Main2ViewModel(IResolutionRoot resolutionRoot, IKernel kernel) 
        {
            _resolutionRoot = resolutionRoot;
            _kernel = kernel;
            RowCount = "3";
            ColumnCount = "3";
            StarRows = "*";
            StarColumns = "*";
            PixelRows = "";
            PixelColumns = "";

            AddNewContent();
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
            AddNewContent();
        }
        public List<ButtonViewModel> CreateButton()
        {
            var myView = _resolutionRoot.Get<Main2View>();
            var t = myView.MainGrid;
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
                }
            }
            return list;
        }

        private void AddNewContent()
        {
            ButtonViewModels = new BindableCollection<ButtonViewModel>(CreateButton());
            myGridViewModel = new MyGridViewModel(this);
        }
    }
}
