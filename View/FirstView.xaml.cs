﻿using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace tabControl1
{
    /// <summary>
    /// FirstView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FirstView : UserControl
    {

        public FirstView()
        {
            InitializeComponent();
            //DataExcel.DataContext = new ViewModel.MyTabItemModel();
            //            DataContext = new ViewModel.MyTabItemModel();
            DataContext = new ViewModel.FirstViewViewModel();

        }
    }
}
