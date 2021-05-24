using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    public class SecondViewViewModel : BaseViewModel,IMyTabContentViewModel  
    {
        public SecondViewViewModel()
        {
            this.PlotBtnCommand = new PlotBtnCommand(this);

            SeriesCollection = new SeriesCollection();
            stdNameXLabels = new string[]{};
            ScoreFormatter= value => value.ToString("N");
            

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] stdNameXLabels { get; set; }
        public Func<double, string> ScoreFormatter { get; set; }
        //Func<double(in),string(out)>: double을 string으로 변환.

        public ICommand PlotBtnCommand { protected set; get; }

    }


}
