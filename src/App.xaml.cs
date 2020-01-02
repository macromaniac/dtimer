using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
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
            if (e.Args.Length == 0)
            {
                //the exe.config stores our default settings, we want our app to work
                //if the exe.config doesn't exist so we do a try catch here
                try
                {
                    var endTime = saved.Default.GoalEndTime;
                }
                catch (NullReferenceException)
                {
                    string settingsLocation = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                    MessageBox.Show("dtimer.exe requires a time to be set, no save data found in " + settingsLocation);
                    Current.Shutdown();
                }
            }

            if (e.Args.Length == 1)
            {
                //always end at 12 the next day, we do this by flooring to the current date
                saved.Default.GoalEndTime = DateTime.Now.Date.AddDays(double.Parse(e.Args[0]) + 1);
                saved.Default.Save();
                return;
            }
            
            if (e.Args.Length >= 2)
            {
                //.net treats 's as seperate arguments (eg a.exe 'A B' would be 'A,'B in args list)
                //so we cheat here and just concat them if there are multiple arguments, we could use an arg parser
                //but would have to embed the dll as want to keep to one executable so /shrug
                saved.Default.GoalMessage = string.Join(" ", e.Args.Take(e.Args.Length - 1));
                //always end at 12 the next day, we do this by flooring to the the current date
                saved.Default.GoalEndTime = DateTime.Now.Date.AddDays(double.Parse(e.Args[e.Args.Length - 1]) + 1);
                saved.Default.Save();
            }
        }
    }
}
