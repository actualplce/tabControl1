using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Defaults; 
namespace tabControl1.ViewModel
{
    class SecondViewCommand
    {
        class PlotBtnCommand : ICommand
        {
            private FirstViewViewModel fvm;
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
                
                //Plot로직구현
                //PlotSCV();
            }






            private static double PlotSCV(double first, string symbol, double second)             //first,second는 첫,둘째값, symbol은 연산기호
            {
                double result = 0;                                                                  //result(결과값) 정의 및 초기화


                

                return result;   //calculate결과물, 결과값 반환
            }
        }
    }
}
