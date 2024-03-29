﻿using System;
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

            ChartValues<double> test = new ChartValues<double>();  //numb temp
            List<string> list = new List<string>();  //name temp
            double a = 0;


            for (int i = 0; i < svm._fvm.ItemsLists.Count; i++)             
            {
                list.Add(svm._fvm.ItemsLists[i].Name);  //name add  

                a = svm._fvm.ItemsLists[i].Score;   //numb add ok
                test.Add(a);

            }

            svm.label = list.ToArray();
            svm.seriesCollection = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Values = test
                }
            };
        }


    }
}



