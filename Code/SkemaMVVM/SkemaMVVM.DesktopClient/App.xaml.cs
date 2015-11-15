using System.Windows;
using Controllers;
using Services;

namespace SkemaMVVM.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CustomerController controller = new CustomerController(new CustomerService());
            controller.Start();
        }
    }
}
