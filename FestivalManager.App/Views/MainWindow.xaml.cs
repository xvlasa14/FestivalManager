using System.Windows.Input;
using FestivalManager.App.ViewModels;

namespace FestivalManager.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private void MainBar_MouseLeftButtonDown(object obj, MouseButtonEventArgs e) => DragMove();
    }
}
