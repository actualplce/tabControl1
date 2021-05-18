using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private object Datagrid_Import;

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

            if (oFileDialog.ShowDialog() == false)
            {
                return;
            }

            OfficeOpenXml.FormulaParsing.Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;
            string sCellData = "";
            double dCellData;

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
                    sData = sData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(sData.Split('|'));
                }

                dataExcel.ItemsSource = dt.DefaultView;

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
            /*
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            //Set filter for file extension and default file extention
            dialog.DefaultExt = ".csv";
            dialog.Filter = "csv Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx";
            dialog.Multiselect = true; //dialog에서 복수개의 파일을 선택할 수 있는지 설정

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                string filepath = dialog.FileName;  //경로("C:\\Users\\asrock\\Desktop\\tabControlSample.csv")
                var fi = new FileInfo(filepath);

                using (var pakage = new ExcelPackage(fi))
                {
                    var workbook = pakage.Workbook;

                    //Excel 내의 AllSheet에 접근
                    var worksheet = workbook.Worksheets.FirstOrDefault();

                    //시트의 마지막 row데이터에서 -1
                    int noOfRow = worksheet.Dimension.End.Row - 1;

                    //종류 row를 제외하고 2부터시작
                    int row = 2;
                    List<FirstViewViewModel> excelData = new List<FirstViewViewModel>();  //fvvn넣어도되나?
                    for (int k = 0; k <= noOfRow -1; k++)
                    {
                        FirstViewViewModel item = new FirstViewViewModel();
                        item.Number = Convert.ToInt32(worksheet.GetValue(row, 1));
                        item.Name = worksheet.GetValue(row, 2).ToString();
                        row++;
                        excelData.Add(item);

                        //productNumber가 0인시점에서 데이터 불러오는작업중단
                        if(Convert.ToInt32(worksheet.GetValue(row,1))==0)
                        { break; }

                    }
                    this.Datagrid_Import.ItemsSource = excelData;
                }

            }
            */
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
