using System;
using System.Windows.Input;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows;
using System.IO;
using System.Linq;
using tabControl1.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Text;

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
            //LoadFile 
            OpenFileDialog oFileDialog = new OpenFileDialog();

            oFileDialog.Filter = "Excel Files (*.csv, *.xlsx, *.xls) |*.csv;*.xlsx;*.xls";
            oFileDialog.Multiselect = true; //dialog에서 복수개의 파일을 선택할 수 있는지 설정
            oFileDialog.ShowDialog();
            string filepath = oFileDialog.FileName;


            //   fvm.ItemsList = FirstViewLoadFile(filepath);
            try
            {
                var listExample = LoadFile(filepath);
                fvm.ItemsLists.Clear();
                listExample.ForEach(x => fvm.ItemsLists.Add(x)); 
                //(Command)List->(VM)ObservableCollection
            }
            catch (Exception e)
            {
                return;
            }
            
        }

        public List<FirstModel> LoadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath); //파일열어서 줄 다 읽음
            var data = from l in lines.Skip(1)    //첫째열(헤더)스킵
                       let split = l.Split(',')   //한 라인을 ,로 구분 (1,금동,950,30)
                       select new FirstModel        //Model의 요소에 집어넣음.(리스트로 저장됨)
                       {
                           Number = int.Parse(split[0]),
                           Name = split[1],
                           BirthYMD = split[2],
                           Score = double.Parse(split[3])

                       };
            return data.ToList();
        }
    }


    class SaveCSVBtnCommand : ICommand
        {   
            //Save and Export To Excel and CSV
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

            //SaveFileDialog
            SaveFileDialog sFileDialog = new SaveFileDialog();
            sFileDialog.Filter = "CSV file (*.csv) |*.csv";
            sFileDialog.ShowDialog();
            string filepath = sFileDialog.FileName;


            //CopyList
            ObservableCollection<FirstModel> copyList = new ObservableCollection<FirstModel>();
            copyList = fvm.ItemsLists; 
            string copiedText = CopyList(copyList);


            //StreamWriter(write into CSV)
            StreamWriter sw = new StreamWriter(filepath,false,Encoding.UTF8);
            sw.WriteLine(copiedText);
            sw.Close();

        }


            private static string CopyList(ObservableCollection<FirstModel> copyList)
            {
            //copy ItemsLists
            string tempCSV = String.Empty;
            tempCSV = "Number,Name,BirthYMD,Score\n";
            for (int i = 0; i < copyList.Count; i++)
            {
                string tempRow = String.Empty;
                tempRow += copyList[i].Number + ",";
                tempRow += copyList[i].Name + ",";
                tempRow += copyList[i].BirthYMD + ",";
                tempRow += copyList[i].Score + "\n";

                tempCSV += tempRow;

                
            }
            return tempCSV;
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
            //AddRow
            FirstModel tempModel = new FirstModel();
            fvm.ItemsLists.Add(tempModel);  //Insert empty data
            }
        }







        class DeleteRowBtnCommand : ICommand
        {
            public FirstViewViewModel fvm;
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
            //DeleteRow

            fvm.ItemsLists.RemoveAt(fvm.selectedIndex);  //Insert empty data
            //foreach(var a1 in fvm.selectedIndex)
            
        }
    }  //한줄만 delete







    }

