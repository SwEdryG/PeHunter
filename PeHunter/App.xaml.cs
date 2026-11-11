using System.Configuration;
using System.Data;
using System.Windows;

namespace PeHunter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            base.OnStartup(e);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Произошла непредвиденная ошибка:\n" + e.Exception.Message,
                            "PeHunter", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true; // не убиваем процесс, показываем диалог
        }
    }
}

