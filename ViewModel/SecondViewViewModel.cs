using LiveCharts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    public class SecondViewViewModel : BaseViewModel,IMyTabContentViewModel  
    {
        public SecondViewViewModel()
        {
            this.PlotBtnCommand = new PlotBtnCommand(this);

            SeriesCollection = new SeriesCollection();
            stdNameXLabels = new string[] { }  ;
            ScoreFormatter(0);

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] stdNameXLabels { get; set; }
        public Func<double, string> ScoreFormatter { get; set; }


        public ICommand PlotBtnCommand { protected set; get; }

    }


}
