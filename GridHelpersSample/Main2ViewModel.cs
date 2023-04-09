using Caliburn.Micro;
using Ninject;
using Ninject.Syntax;
using System.Collections.Generic;

namespace GridHelpersSample
{
    public class Main2ViewModel : Screen
    {
        private bool needToReload = false;
        private bool justChange = false;

        private readonly IResolutionRoot _resolutionRoot;
        private readonly IKernel _kernel;
        public BindableCollection<ButtonViewModel> ButtonViewModels { get; set; }

        private MyGridViewModel _myGridViewModel;
        public MyGridViewModel myGridViewModel
        {
            get { return _myGridViewModel; }
            set
            {
                _myGridViewModel = value;
                NotifyOfPropertyChange(() => myGridViewModel);
            }
        }
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

            Valider();
        }

        #region datas for defining grid
        private string rowCount;
        public string RowCount
        {
            get { return rowCount; }
            set
            {
                if (value != rowCount)
                    needToReload = true;
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

                if (value != columnCount)
                    needToReload = true;
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
                if (value != starRows)
                    justChange = true;
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
                if (value != starColumns)
                    justChange = true;
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

                if (value != pixelRows)
                    justChange = true;
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

                if (value != pixelColumns)
                    justChange = true;
                pixelColumns = value;
                NotifyOfPropertyChange(() => PixelColumns);
            }
        }
        #endregion

        public void Valider()
        {
            if (needToReload)
                AddNewContent();
            if(!needToReload && justChange)
                myGridViewModel.UpdateParams();

            needToReload = false;
            justChange = false;
        }
        public List<ButtonViewModel> CreateButton()
        {
            //var myView = _resolutionRoot.Get<Main2View>();
            //var t = myView.MainGrid;
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
            //myGridViewModel = new MyGridViewModel(RowCount, ColumnCount, StarRows, StarColumns, PixelRows, PixelColumns);
            myGridViewModel = new MyGridViewModel(this);
        }
    }
}
