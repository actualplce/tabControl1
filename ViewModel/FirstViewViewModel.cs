using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using tabControl1.Data;

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

     }
    public List<FirstModel> FirstViewLoadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var data = from l in lines.Skip(1)
                       let split = l.Split(';')
                       select new FirstModel
                       {
                           Number = int.Parse(split[0]),
                           Name = split[1],
                           BirthYMD = split[2],
                           Score = double.Parse(split[3])

                       };


            return data.ToList();
        }

/*
     int number = 0;
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




