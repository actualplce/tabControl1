using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tabControl1
{
    /// <summary>
    /// SecondView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SecondView : UserControl
    {
        public SecondView()
        {
            InitializeComponent();
            

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            stdNameXLabels = new[] { "Maria", "Susan", "Charles", "Frida" };
            ScoreFormatter = value => value.ToString("N");


            //adding series will update and animate the chart automatically
            #region 12
            /*
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });
            */

            //also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);
            #endregion


            DataContext = this;
        }


    }
}
    

