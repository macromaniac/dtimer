using System;
using System.Configuration;
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
            //the exe.config stores our default settings, we want our app to work
            //if the exe.config doesn't exist so we do a try catch here
            try
            {
                var endTime = saved.Default.GoalEndTime;
            }catch (NullReferenceException)
            {
                string settingsLocation = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                MessageBox.Show("dtimer.exe requires a time to be set, no save data found in " + settingsLocation);
                Current.Shutdown();
            }

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
