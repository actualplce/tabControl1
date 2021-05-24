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
        class PlotBtnCommand : ICommand
        {
            private SecondViewViewModel svm;
            private FirstViewViewModel fvm;

            public event EventHandler CanExecuteChanged;
            public PlotBtnCommand(SecondViewViewModel svm)
            {
                this.svm= svm;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {

            //CopyList
          //  ObservableCollection<FirstModel> copyList = new ObservableCollection<FirstModel>();
           // copyList = fvm.ItemsLists;

            for(int i=0;i<fvm.ItemsLists.Count;i++)
            {
                ChartValues<double> test = new ChartValues<double>();
                test.Add(fvm.ItemsLists[i].Score);

                //SeriesCollection seriesViews = new SeriesCollection();
            }

            for (int i = 0; i < fvm.ItemsLists.Count; i++)
            {
              //  svm.stdNameXLabels.Add(fvm.ItemsLists[i].Name);
            
            
            }

            svm.SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            svm.ScoreFormatter = value => value.ToString("N");

        }
     


        private static double PlotSCV(double first, string symbol, double second)             //first,second는 첫,둘째값, symbol은 연산기호
            {
                double result = 0;                                                                  //result(결과값) 정의 및 초기화


                

                return result;   //calculate결과물, 결과값 반환
            }
        }
    }



