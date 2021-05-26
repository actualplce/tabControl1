using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using tabControl1.Data;

namespace tabControl1.Converter
{
    class SeriesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ObservableCollection<FirstModel>))
                return null;

            var ItemsLists = value as ObservableCollection<FirstModel>;

            ChartValues <double> test = new ChartValues<double>();  //numb temp
            double a = 0;

            //var list = ItemsLists.Select(x => x.Name).ToList();
            ItemsLists.ToList().ForEach(x => test.Add(x.Score));


            //svm.label = list.ToArray();
         

            return new SeriesCollection()
            {
                new ColumnSeries
                {
                    Values = test
                }
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
