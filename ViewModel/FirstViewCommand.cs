using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace tabControl1.ViewModel
{
    class LoadCSVBtnCommand : ICommand
    {
        private FirstViewViewModel fvm;
        public event EventHandler CanExecuteChanged;
        public LoadCSVBtnCommand(FirstViewViewModel fvm)
        {
            this.fvm = fvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //로드파일로직구현
            LoadFile();
        }



        private static double LoadFile(double first, string symbol, double second)             //first,second는 첫,둘째값, symbol은 연산기호
        {
            double result = 0;                                                                  //result(결과값) 정의 및 초기화


            if (symbol.Equals("*"))  //곱셈
            {
                result = first * second;

            }
            else if (symbol.Equals("/")) //나눗셈
            {
                result = first / second;
            }
            else if (symbol.Equals("+")) //덧셈
            {
                result = first + second;
            }
            else if (symbol.Equals("-")) //뺄셈
            {
                result = first - second;
            }

            return result;   //calculate결과물, 결과값 반환
        }

    }

    class SaveCSVBtnCommand : ICommand
    {
        private FirstViewViewModel fvm;
        public event EventHandler CanExecuteChanged;
        public SaveCSVBtnCommand(FirstViewViewModel fvm)
        {
            this.fvm = fvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //로드파일로직구현
        }
    }

    class AddRowBtnCommand : ICommand
    {
        private FirstViewViewModel fvm;
        public event EventHandler CanExecuteChanged;
        public AddRowBtnCommand(FirstViewViewModel fvm)
        {
            this.fvm = fvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //로드파일로직구현
        }
    }

    class DeleteRowBtnCommand : ICommand
    {
        private FirstViewViewModel fvm;
        public event EventHandler CanExecuteChanged;
        public DeleteRowBtnCommand(FirstViewViewModel fvm)
        {
            this.fvm = fvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //로드파일로직구현
        }
    }







}
