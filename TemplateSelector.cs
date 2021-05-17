using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using tabControl1.ViewModel;

namespace tabControl1
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTypeTemplate { get; set; }
        public DataTemplate SecondTypeTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(((MyTabItemModel)(item)).CurrentMyTabContentViewModel is FirstViewViewModel)
            {
                return FirstTypeTemplate;
            }
            return SecondTypeTemplate;
        }

    }


}
