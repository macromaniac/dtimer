using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace DTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string windowNameValue = "";
        public string WindowName { 
            get => windowNameValue;
            set { if (value != windowNameValue) { windowNameValue = value; NotifyPropertyChanged(); } }
        }

        private string timerTextValue = "blah";
        public string TimerText
        {
            get => timerTextValue;
            set { if (value != timerTextValue) { timerTextValue = value; NotifyPropertyChanged(); } }
        }

        private string timerTextColorValue = "black";
        public string TimerTextColor
        {
            get => timerTextColorValue;
            set { if (value != timerTextColorValue) { timerTextColorValue = value; NotifyPropertyChanged(); } }
        }

        private string tooltipTextValue = "";
        public string TooltipText
        {
            get => tooltipTextValue;
            set { if (value != tooltipTextValue) { tooltipTextValue = value; NotifyPropertyChanged(); } }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(.1) };
            timer.Tick += Timer_Tick;
            timer.Start();
            TimerText = "";
            WindowName = saved.Default.GoalMessage;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //set timer text
            int daysLeft = (int)Math.Floor((saved.Default.GoalEndTime - DateTime.Now).TotalDays);

            //if we got multiple days just display the number of days
            if (daysLeft > 0)
                TimerText = daysLeft.ToString();

            //if we are at 0 days display the number of hours
            if (daysLeft == 0)
            {
                string hoursLeft = Math.Floor((saved.Default.GoalEndTime - DateTime.Now).TotalHours).ToString();
                //dont display 0h, that would be wierd
                if (hoursLeft == "0")
                    TimerText = "<1h";
                else
                    TimerText = hoursLeft + "h";
            }

            //if we are out of time make the timer red
            if (daysLeft < 0)
            {
                TimerText = "0";
                TimerTextColor = "red";
            }

            TooltipText = (saved.Default.GoalEndTime - DateTime.Now).ToString(@"d\:hh\:mm");
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
