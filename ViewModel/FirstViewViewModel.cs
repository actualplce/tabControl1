using System.Collections.Generic;
using System.Windows.Input;
using tabControl1.Data;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace tabControl1.ViewModel
{
    public class FirstViewViewModel : BaseViewModel,IMyTabContentViewModel
    {
        public FirstViewViewModel()
        {
        }
       public FirstViewViewModel(SecondViewViewModel svm)
        {
            
         this.LoadCSVBtnCommand = new LoadCSVBtnCommand(this);
         this.SaveCSVBtnCommand = new SaveCSVBtnCommand(this);
         this.AddRowBtnCommand = new AddRowBtnCommand(this);
         this.DeleteRowBtnCommand = new DeleteRowBtnCommand(this);

        ItemsLists = new ObservableCollection<FirstModel>();  //DataGrid x:Name="ItemsList" ItemsSource="{Binding ItemsLists}"
            
        selectedIndex = 0;
        this._svm = svm;
       

        }
     public ObservableCollection<FirstModel> ItemsLists { get; set; }   //속성정의
     public int selectedIndex { get; set; }   //datagrid 선택된 row?의 index (multiple items의 remove 어떻게?): selecteditem, ObservableCollection
        public SecondViewViewModel _svm;

     public ICommand LoadCSVBtnCommand { protected set; get; }
     public ICommand SaveCSVBtnCommand { protected set; get; }
     public ICommand AddRowBtnCommand { protected set; get; }
     public ICommand DeleteRowBtnCommand { protected set; get; }

    }

}




