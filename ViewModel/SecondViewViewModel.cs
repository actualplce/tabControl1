using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    public class SecondViewViewModel : BaseViewModel,IMyTabContentViewModel  
    {
        public SecondViewViewModel(){ }
        public SecondViewViewModel(FirstViewViewModel fvm)
        {
            this.PlotBtnCommand = new PlotBtnCommand(this);

            SeriesCollection = new SeriesCollection();
            stdNameXLabels = new string[50];
            ScoreFormatter= value => value.ToString("N");
            this._fvm= fvm;
            int a = fvm.ItemsLists.Count;


        }

      //  public FirstViewViewModel _fvm;
        public ICommand PlotBtnCommand { set; get; }

        
        private FirstViewViewModel __fvm = new FirstViewViewModel();
        public FirstViewViewModel _fvm
        {
            get { return __fvm; }
            private set
            {
                if (_fvm == value)
                {
                    return;
                }
                __fvm = value;
                this.OnPropertyChanged("_fvm ");
            }
        }
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] stdNameXLabels { get; set; }
        public Func<double, string> ScoreFormatter { get; set; }
        //Func<double(in),string(out)>: double을 string으로 변환.



        
    }


}
