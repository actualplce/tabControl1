using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using tabControl1.Data;

namespace tabControl1.Converter
{
    class LabelsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ObservableCollection<FirstModel>))  //넘겨받는 값이 FistModel값아닐경우 예외처리
                return null;

            var ItemsLists = value as ObservableCollection<FirstModel>;

            var list = ItemsLists.Select(x => x.Name).ToList();  //해당 모델의 Name값을 넣고 ItemLists[Obser.Coll->List]로 바꿈.
            

            return list.ToArray();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
