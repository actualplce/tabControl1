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

        }

        public ObservableCollection<MyTabItemModel> Tabs { get; set; }


    }
}


