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
            SecondViewViewModel secondViewViewModel = new SecondViewViewModel();
            this.Tabs = new ObservableCollection<MyTabItemModel>
            {           
                new MyTabItemModel()
                {
                    Header = "CSV View",
                   CurrentMyTabContentViewModel = firstViewViewModel //new FirstViewViewModel()
                
                },
                new MyTabItemModel()
                {
                    Header = "Plot View",
                   CurrentMyTabContentViewModel = secondViewViewModel//new SecondViewViewModel()
                }
        };
            firstViewViewModel._svm = Tabs[1].CurrentMyTabContentViewModel as SecondViewViewModel;
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
      */  }
    }


