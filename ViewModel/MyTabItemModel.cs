using System;
using System.Collections.Generic;
using System.Text;

namespace tabControl1.ViewModel
{
    public class MyTabItemModel
    {   //TabItem내부의 데이터 요소 정의. (Header가 tab에 표출)
        public string Header { get; set; }

        public IMyTabContentViewModel CurrentMyTabContentViewModel { get; set; }
    }
}
