using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace tabControl1.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            //this.Tabs = GetDemoData();
            //this.Tabs[0] = firstViewViewModel;
            FirstViewViewModel firstViewViewModel = new FirstViewViewModel();
            SecondViewViewModel secondViewViewModel = new SecondViewViewModel(firstViewViewModel);
            this.Tabs = new ObservableCollection<MyTabItemModel>
            {
                new MyTabItemModel()
                {
                    Header = "CSV View",
                   CurrentMyTabContentViewModel = firstViewViewModel

                },
                new MyTabItemModel()
                {
                    Header = "Plot View",
                   CurrentMyTabContentViewModel = secondViewViewModel
                }
            };
            //firstViewViewModel._svm = Tabs[1].CurrentMyTabContentViewModel as SecondViewViewModel;
            //secondViewViewModel._fvm = Tabs[0].CurrentMyTabContentViewModel as FirstViewViewModel;  //SecondVM에 FirstVM인자로써 전달

        }



        public ObservableCollection<MyTabItemModel> Tabs { get; set; }

        /*    private static ObservableCollection<MyTabItemModel> GetDemoData()
            {
                return new ObservableCollection<MyTabItemModel>
                {
                    new MyTabItemModel()
                    {
                        Header = "CSV View",
                       CurrentMyTabContentViewModel = new FirstViewViewModel()
                      //  FirstViewViewModel();

                    },
                    new MyTabItemModel()
                    {
                        Header = "Plot View",
                       CurrentMyTabContentViewModel = new SecondViewViewModel()
                    }


            };
          */
    }
}


