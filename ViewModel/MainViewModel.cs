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
            this.Tabs = GetDemoData();
        }


        public ObservableCollection<MyTabItemModel> Tabs { get; set; }
        private static ObservableCollection<MyTabItemModel> GetDemoData()
        {
            return new ObservableCollection<MyTabItemModel>
            {
                new MyTabItemModel()
                {
                    Header = "CSV View",
                    CurrentMyTabContentViewModel = new FirstViewViewModel()
                },
                new MyTabItemModel()
                {
                    Header = "Plot View",
                    CurrentMyTabContentViewModel = new SecondViewViewModel()
                }


            };
        }
    }
}
