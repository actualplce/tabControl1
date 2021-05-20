using System.Windows;
using tabControl1.ViewModel;


namespace tabControl1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext= new MainViewModel();
            
        }
    }
}
