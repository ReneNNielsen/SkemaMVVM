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
            TeacherController controller = new TeacherController(new TeacherService());
            controller.Start();
        }
    }
}
