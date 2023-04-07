using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace GridHelpers
{
    public class GridHelpers
    {
        #region RowCount Property

        /// <summary>
        /// Adds the specified number of Rows to RowDefinitions. 
        /// Default Height is Auto
        /// </summary>
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.RegisterAttached(
                "RowCount", typeof(int), typeof(GridHelpers),
                new PropertyMetadata(-1, RowCountChanged));

        // Get
        public static int GetRowCount(DependencyObject obj)
        {
            return (int)obj.GetValue(RowCountProperty);
        }

        // Set
        public static void SetRowCount(DependencyObject obj, int value)
        {
            obj.SetValue(RowCountProperty, value);
        }

        // Change Event - Adds the Rows
        public static void RowCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.RowDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
                grid.RowDefinitions.Add(
                    new RowDefinition() { Height = GridLength.Auto });

            SetPixelOrStarRows(grid);
        }

        #endregion

        #region ColumnCount Property

        /// <summary>
        /// Adds the specified number of Columns to ColumnDefinitions. 
        /// Default Width is Auto
        /// </summary>
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.RegisterAttached(
                "ColumnCount", typeof(int), typeof(GridHelpers),
                new PropertyMetadata(-1, ColumnCountChanged));

        // Get
        public static int GetColumnCount(DependencyObject obj)
        {
            return (int)obj.GetValue(ColumnCountProperty);
        }

        // Set
        public static void SetColumnCount(DependencyObject obj, int value)
        {
            obj.SetValue(ColumnCountProperty, value);
        }

        // Change Event - Add the Columns
        public static void ColumnCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = GridLength.Auto });

            SetPixelOrStarColumns(grid);
        }

        #endregion

        #region StarRows Property

        /// <summary>
        /// Makes the specified Row's Height equal to Star. 
        /// Can set on multiple Rows
        /// </summary>
        public static readonly DependencyProperty StarRowsProperty =
            DependencyProperty.RegisterAttached(
                "StarRows", typeof(string), typeof(GridHelpers),
                new PropertyMetadata(string.Empty, StarRowsChanged));

        // Get
        public static string GetStarRows(DependencyObject obj)
        {
            return (string)obj.GetValue(StarRowsProperty);
        }

        // Set
        public static void SetStarRows(DependencyObject obj, string value)
        {
            obj.SetValue(StarRowsProperty, value);
        }

        // Change Event - Makes specified Row's Height equal to Star
        public static void StarRowsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetPixelOrStarRows((Grid)obj);
        }

        #endregion

        #region StarColumns Property

        /// <summary>
        /// Makes the specified Column's Width equal to Star. 
        /// Can set on multiple Columns
        /// </summary>
        public static readonly DependencyProperty StarColumnsProperty =
            DependencyProperty.RegisterAttached(
                "StarColumns", typeof(string), typeof(GridHelpers),
                new PropertyMetadata(string.Empty, StarColumnsChanged));

        // Get
        public static string GetStarColumns(DependencyObject obj)
        {
            return (string)obj.GetValue(StarColumnsProperty);
        }

        // Set
        public static void SetStarColumns(DependencyObject obj, string value)
        {
            obj.SetValue(StarColumnsProperty, value);
        }

        // Change Event - Makes specified Column's Width equal to Star
        public static void StarColumnsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetPixelOrStarColumns((Grid)obj);
        }

        #endregion

        #region PixelRows Property

        /// <summary>
        /// Makes the specified Row's Height equal to Star. 
        /// Can set on multiple Rows
        /// </summary>
        public static readonly DependencyProperty PixelRowsProperty =
            DependencyProperty.RegisterAttached(
                "PixelRows", typeof(string), typeof(GridHelpers),
                new PropertyMetadata(string.Empty, PixelRowsChanged));

        // Get
        public static string GetPixelRows(DependencyObject obj)
        {
            return (string)obj.GetValue(PixelRowsProperty);
        }

        // Set
        public static void SetPixelRows(DependencyObject obj, string value)
        {
            obj.SetValue(PixelRowsProperty, value);
        }

        // Change Event - Makes specified Row's Height equal to Star
        public static void PixelRowsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetPixelOrStarRows((Grid)obj, GridUnitType.Pixel);
        }

        #endregion

        #region PixelColumns Property

        /// <summary>
        /// Makes the specified Column's Width equal to Star. 
        /// Can set on multiple Columns
        /// </summary>
        public static readonly DependencyProperty PixelColumnsProperty =
            DependencyProperty.RegisterAttached(
                "PixelColumns", typeof(string), typeof(GridHelpers),
                new PropertyMetadata(string.Empty, PixelColumnsChanged));

        // Get
        public static string GetPixelColumns(DependencyObject obj)
        {
            return (string)obj.GetValue(PixelColumnsProperty);
        }

        // Set
        public static void SetPixelColumns(DependencyObject obj, string value)
        {
            obj.SetValue(PixelColumnsProperty, value);
        }

        // Change Event - Makes specified Column's Width equal to Star
        public static void PixelColumnsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
                return;

            SetPixelOrStarColumns((Grid)obj, GridUnitType.Pixel);
        }

        #endregion

        private static void SetPixelOrStarColumns(Grid grid, GridUnitType type = GridUnitType.Star)
        {

            //another way using Regex.Split
            //var starColumns = Regex.Split(GetStarColumns(grid), @",(?![^()]*\))")
            //                       .Where(x => !string.IsNullOrEmpty(x))
            //                       .Select(m =>
            //                       {
            //                           var v = Regex.Replace(m, @"[\(\) ]", "");
            //                           return (v.Contains(",") ? v : $"{v},1").Split(',')
            //                                                                  .Select(int.Parse)
            //                                                                  .ToArray();
            //                       })
            //                       .ToDictionary(x => x[0], x => x[1]);

            var regex = new Regex(@"(?:(?:\((?>[^()]+|\((?<number>)|\)(?<-number>))*(?(number)(?!))\))|[^,])+");
            var starColumns = regex.Matches(GetStarColumns(grid))
                                   .Cast<Match>()
                                   .Select(m => 
                                   {
                                       var v = Regex.Replace(m.Value, @"[\(\) ]", "");
                                       return (v.Contains(",") ? v : $"{v},1").Split(',')
                                                                              .Select(int.Parse)
                                                                              .ToArray();
                                    })

                                   .ToDictionary(x => x[0], x => x[1]);

            if (starColumns.Count == 0) return;

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                if(starColumns.TryGetValue(i, out int nbrStar))
                        grid.ColumnDefinitions[i].Width =
                            new GridLength(nbrStar, type);
            }
        }

        private static void SetPixelOrStarRows(Grid grid, GridUnitType type = GridUnitType.Star)
        {
            var regex = new Regex(@"(?:(?:\((?>[^()]+|\((?<number>)|\)(?<-number>))*(?(number)(?!))\))|[^,])+");
            var starRows = regex.Matches(GetStarRows(grid))
                                .Cast<Match>()
                                .Select(m =>
                                {
                                    var v = Regex.Replace(m.Value, @"[\(\) ]", "");
                                    return (v.Contains(",") ? v : $"{v},1").Split(',')
                                                                            .Select(int.Parse)
                                                                            .ToArray();
                                })
                                .ToDictionary(x => x[0], x => x[1]);

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                if (starRows.TryGetValue(i, out int nbrStar))
                    grid.RowDefinitions[i].Height =
                        new GridLength(nbrStar, type);
            }
            //string[] starRows =
            //    GetStarRows(grid).Split(',');

            //for (int i = 0; i < grid.RowDefinitions.Count; i++)
            //{
            //    if (starRows.Contains(i.ToString()))
            //        grid.RowDefinitions[i].Height =
            //            new GridLength(1, GridUnitType.Star);
            //}
        }
    }
}
