using Caliburn.Micro;
using System.Collections.Generic;

namespace GridHelpersSample
{
    public class MyGridViewModel : Screen
    {
        public BindableCollection<ButtonViewModel> ButtonViewModels { get; set; }
        public MyGridViewModel(Main2ViewModel main2ViewModel)
        {
            RowCount = main2ViewModel.RowCount;
            ColumnCount = main2ViewModel.ColumnCount;
            StarRows = main2ViewModel.StarRows;
            StarColumns = main2ViewModel.StarColumns;
            PixelRows = main2ViewModel.PixelRows;
            PixelColumns = main2ViewModel.PixelColumns;
            ButtonViewModels = main2ViewModel.ButtonViewModels;
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

        public void OnButtonClick(ButtonViewModel context)
        {

        }
    }
}
