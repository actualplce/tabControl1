using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace tabControl1
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTypeTemplate { get; set; }
        public DataTemplate SecondTypeTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item.GetType() == typeof(FirstViewModel))
                return FirstTypeTemplate;
            return SecondTypeTemplate;
        }

    }
}
