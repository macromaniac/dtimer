using dtimer;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace DTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string WindowName { get; set; } = "";
        public int TimerFontSize { get; set; } = 100;
        public string TimerText { get; set; } = "blah";
        public string TimerTextColor { get; set; } = "black";
        public string TooltipText { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SizeChanged += MainWindow_SizeChanged;
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(.1) };
            timer.Tick += Timer_Tick;
            timer.Start();
            TimerText = "";
            WindowName = saved.Default.GoalMessage;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int daysLeft = (int)Math.Ceiling((saved.Default.GoalEndTime - DateTime.Now).TotalDays);
            if (daysLeft < 0) {
                daysLeft = 0;
                TimerTextColor = "red";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerTextColor)));
            }
            TooltipText = (saved.Default.GoalEndTime - DateTime.Now).ToString(@"d\:hh\:mm");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TooltipText)));
            TimerText = daysLeft.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerText)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TimerFontSize = (int)Math.Floor(Height - 40); //roughly size of title bar
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerFontSize)));
        }
    }
}
