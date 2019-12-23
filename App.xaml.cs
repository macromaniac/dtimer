using dtimer;
using System;
using System.Windows;

namespace DTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 1)
            {
                saved.Default.GoalEndTime = DateTime.Now.AddDays(double.Parse(e.Args[0]));
                saved.Default.Save();
                return;
            }
            
            if (e.Args.Length == 2)
            {
                saved.Default.GoalMessage = e.Args[0];
                saved.Default.GoalEndTime = DateTime.Now.AddDays(double.Parse(e.Args[1]));
                saved.Default.Save();
            }
        }
    }
}
