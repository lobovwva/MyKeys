using MyKeys.View;
using MyKeys.ViewModel;
using System.Windows;

namespace MyKeys
{
    public partial class App : Application
    {
        private BoardVM boardVM = new BoardVM();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new MainWindow() { DataContext = boardVM }.Show();
        }
    }
}
