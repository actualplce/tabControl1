using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using tabControl1.Data;

namespace tabControl1.ViewModel
{
    public class PlotBtnCommand : ICommand
    {
        private SecondViewViewModel svm;

        public event EventHandler CanExecuteChanged;
        public PlotBtnCommand(SecondViewViewModel svm)
        {
            this.svm = svm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            ChartValues<double> test = new ChartValues<double>();
            for (int i = 0; i < svm._fvm.ItemsLists.Count; i++)             //Name
            {
                svm.stdNameXLabels[i] = svm._fvm.ItemsLists[i].Name;
                double[] a = new double[] { };
                a[i] = svm._fvm.ItemsLists[i].Score;  //out of range of array
                test.Add(svm._fvm.ItemsLists[i].Score);

            }

            //  for (int i = 0; i < svm._fvm.ItemsLists.Count; i++)             //Name
            //{
            //    svm.stdNameXLabels[i] = svm._fvm.ItemsLists[i].Name;
            //    //test.Add(svm._fvm.ItemsLists[i].Score);

            //}

            svm.seriesCollection= new SeriesCollection()
            {
                new ColumnSeries
                {
                    
                    Values = test
                }
            };

            /*
    seriesViews.Add(new ColumnSeries
    {
        // Title = "2015",
        Values = new ChartValues<double> { 10, 20, 30, 40 }
    });
*/
            // svm.seriesCollection = seriesViews;



           //svm.seriesCollection = test as SeriesCollection;
         



        }


    }
}



