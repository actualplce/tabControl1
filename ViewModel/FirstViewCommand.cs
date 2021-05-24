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

namespace tabControl1.ViewModel
{
    class LoadCSVBtnCommand : ICommand
    {
        private FirstViewViewModel fvm;
        public List<FirstModel> LoadResult { get; set; }

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
            //  LoadFile(parameter);

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
                listExample.ForEach(x => fvm.ItemsLists.Add(x)); //(Command)List->(VM)ObservableCollection
            }
            catch (Exception e)
            {
                throw null;
            }
            #region prev1
            /*
            if (oFileDialog.ShowDialog() == false)
            {
                return;
            }

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;
            string sCellData = "";
            //double dCellData;
            object dCellData;

            xlApp = new Excel.Application();

            try
            {
                xlWorkBook = xlApp.Workbooks.Open(oFileDialog.FileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;

                DataTable dt = new DataTable();

                // 첫 행을 제목으로
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    str = (string)(range.Cells[1, cCnt] as Excel.Range).Value2;
                    dt.Columns.Add(str, typeof(string));
                }

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    string sData = "";
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        try
                        {
                            sCellData = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            sData += sCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            dCellData = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            sData += dCellData.ToString() + "|";
                        }
                    }
                    sData = sData.Remove(sData.Length - 1, 1); //strData.Length->sData.Length
                    dt.Rows.Add(sData.Split('|'));
                }
                 
                

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 열기 실패! : " + ex.Message);
                return;
            }
            */
            #endregion
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
            StreamWriter sw = new StreamWriter(filepath);
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

