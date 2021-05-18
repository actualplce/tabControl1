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

        string displayText = "";
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
        }


        public ICommand LoadCSVBtnCommand { protected set; get;}
        public ICommand SaveCSVBtnCommand { protected set; get; }
        public ICommand AddRowBtnCommand { protected set; get; }
        public ICommand DeleteRowBtnCommand { protected set; get; }





    }






    public class SecondViewViewModel : IMyTabContentViewModel 
    {

    }

}