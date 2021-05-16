using System;
using System.Collections.Generic;
using System.Text;

namespace tabControl1
{
    public class SharedViewModel
    {
        public SharedViewModel()
        {
            SmallerViewModels = new List<ISmallViewModel>();
            SmallerViewModels.Add(new FirstViewModel());
            SmallerViewModels.Add(new SecondViewModel());
        }
        public IList<ISmallViewModel> SmallerViewModels { get; private set; }
    }
    public interface ISmallViewModel { }
    public class FirstViewModel : ISmallViewModel
    {
        public string FirstDescription
        {
            get { return "My first ViewModel"; }
        }
    }
    public class SecondViewModel : ISmallViewModel
    {
        public string SecondDescription
        {
            get { return "My second ViewModel"; }
        }
    }
}
