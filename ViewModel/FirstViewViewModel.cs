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
            
         this.LoadCSVBtnCommand = new LoadCSVBtnCommand(this);
         this.SaveCSVBtnCommand = new SaveCSVBtnCommand(this);
         this.AddRowBtnCommand = new AddRowBtnCommand(this);
         this.DeleteRowBtnCommand = new DeleteRowBtnCommand(this);

            ItemsLists = new ObservableCollection<FirstModel>();  //DataGrid x:Name="ItemsList" ItemsSource="{Binding ItemsLists}"
            #region sample1
            /*  FirstModel s = new FirstModel();
            s.BirthYMD = "test"; //sample data
            s.Name = "test";
            s.Number = 11;
            s.Score = 22;
            ItemsLists.Add(s);  //Insert sample data
          */
            #endregion


        }
        //public List<FirstModel> FirstModel { get; set; }
        //private List<FirstModel> _ItemsList;
     public ObservableCollection<FirstModel> ItemsLists { get; set; }   //속성정의
    


        
     public ICommand LoadCSVBtnCommand { protected set; get; }
     public ICommand SaveCSVBtnCommand { protected set; get; }
     public ICommand AddRowBtnCommand { protected set; get; }
     public ICommand DeleteRowBtnCommand { protected set; get; }

    }

}




