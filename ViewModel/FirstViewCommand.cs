﻿using System;
using System.Windows.Input;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows;

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
            #region 로드로직
            //로드파일로직구현
            //  LoadFile(parameter);

            OpenFileDialog oFileDialog = new OpenFileDialog();

            oFileDialog.Filter = "Excel Files (*.csv, *.xlsx, *.xls) |*.csv;*.xlsx;*.xls";
            oFileDialog.Multiselect = true; //dialog에서 복수개의 파일을 선택할 수 있는지 설정

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

            #endregion
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

           
       



        private void LoadFile(object sender)
        {
           
        }

    }






    class SaveCSVBtnCommand : ICommand
    {   //Save and Export To Excel and CSV
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
            //Save파일로직구현
            //SaveFile(parameter);
        }


        private static void SaveFile(object sender)
        {
            #region 1
            //저장할경로선택 후, 그 자리에 파일저장로직 쓰기

            /*Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            //Set filter for file extension and default file extention
            dialog.DefaultExt = ".csv";
            dialog.Filter = "csv Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx";
            dialog.Multiselect = true; //dialog에서 복수개의 파일을 선택할 수 있는지 설정

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;  //경로("C:\\Users\\asrock\\Desktop\\tabControlSample.csv")

                foreach (String file in dialog.FileNames)
                {

                }

            }*/
            #endregion
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
            //DeleteRow
        }
    }







}
