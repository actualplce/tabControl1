using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    public interface IMyTabContentViewModel { }
    public class FirstViewViewModel : BaseViewModel, IMyTabContentViewModel
    {
        public FirstViewViewModel()
        {
            this.LoadCSVBtnCommand = new LoadCSVBtnCommand(this);
            this.SaveCSVBtnCommand = new SaveCSVBtnCommand(this);
            this.AddRowBtnCommand = new AddRowBtnCommand(this);
            this.DeleteRowBtnCommand = new DeleteRowBtnCommand(this);

        }



        int number= 0;
        //계산기의 출력창과 바인딩된 속성
        public int Number
        {
            internal set
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


        /*string displayText = "";
        //계산기의 출력창과 바인딩된 속성
        public string DisplayText
        {
            internal set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }*/


        public ICommand LoadCSVBtnCommand { protected set; get;}
        public ICommand SaveCSVBtnCommand { protected set; get; }
        public ICommand AddRowBtnCommand { protected set; get; }
        public ICommand DeleteRowBtnCommand { protected set; get; }
        public object Datagrid_Import { get; internal set; }
    }






    public class SecondViewViewModel : IMyTabContentViewModel 
    {









    }

}