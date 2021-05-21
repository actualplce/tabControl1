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
            ItemsLists = new ObservableCollection<FirstModel>();
         this.LoadCSVBtnCommand = new LoadCSVBtnCommand(this);
         this.SaveCSVBtnCommand = new SaveCSVBtnCommand(this);
         this.AddRowBtnCommand = new AddRowBtnCommand(this);
         this.DeleteRowBtnCommand = new DeleteRowBtnCommand(this);
            FirstModel s = new FirstModel();
            s.BirthYMD = "test";
            s.Name = "test";
            s.Number = 11;
            s.Score = 22;
            ItemsLists.Add(s);

     }
        //public List<FirstModel> FirstModel { get; set; }
        //private List<FirstModel> _ItemsList;
        public ObservableCollection<FirstModel> ItemsLists { get; set; }


      /*  int number = 0;
             //계산기의 출력창과 바인딩된 속성
             public int Number
             {
                 set
                 {
                     if (number != value)
                     {
                         number = value;
                         OnPropertyChanged("Number");
                     }
                 }
                 get { return number; }
             }

             string name = "";
             public string Name
             {
                 internal set
                 {
                     if (name != value)
                     {
                         name = value;
                         OnPropertyChanged("Name");
                     }
                 }
                 get { return name; }
             }
        
        
        */
        public ICommand LoadCSVBtnCommand { protected set; get; }
     public ICommand SaveCSVBtnCommand { protected set; get; }
     public ICommand AddRowBtnCommand { protected set; get; }
     public ICommand DeleteRowBtnCommand { protected set; get; }

    }

}




