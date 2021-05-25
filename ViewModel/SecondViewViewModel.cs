using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    public class SecondViewViewModel : BaseViewModel, IMyTabContentViewModel
    {
        public SecondViewViewModel() { }
        public SecondViewViewModel(FirstViewViewModel fvm)
        {
            this.PlotBtnCommand = new PlotBtnCommand(this);

            seriesCollection = new SeriesCollection();
            label = new string[] { };
            scoreFormatter = value => value.ToString("N");
            this._fvm = fvm;

            

        }

      //  public FirstViewViewModel _fvm;
        public ICommand PlotBtnCommand { set; get; }


        private FirstViewViewModel __fvm = new FirstViewViewModel();
        public FirstViewViewModel _fvm
        {
            get { return __fvm; }
            set
            {
                if (_fvm == value)
                {
                    return;
                }
                __fvm = value;
                this.OnPropertyChanged("_fvm ");
            }
        }

        private SeriesCollection _seriesCollection ;
        public SeriesCollection seriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                if (seriesCollection == value)
                {
                    return;
                }
            _seriesCollection = value;
            this.OnPropertyChanged("seriesCollection");
            }
        }
        


        private String[] _label;
        public String[] label
        {
            get { return _label; }
            set
            {
                if (label == value)
                {
                    return;
                }
                _label = value;
                this.OnPropertyChanged("label");
            }
        }



        public Func<double, string> scoreFormatter { get; set; }
        //Func<double(in),string(out)>: double을 string으로 변환.



        
    }


}
