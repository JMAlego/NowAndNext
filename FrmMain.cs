using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NowAndNext
{
    public partial class FrmMain : Form
    {
        // Extended window style constants (from WinUser.h)
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TOPMOST = 0x00000008;

        private readonly Clock clock;
        private DateTime LastUpdateTime = DateTime.Now;

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
        public FrmMain()
        {
            InitializeComponent();

            clock = new(new(Font.FontFamily, Font.Size * 2, FontStyle.Bold));
        }

        private void PicClock_Paint(object sender, PaintEventArgs e)
        {
            clock.Draw(e.Graphics);
        }

        public static int GetIso8601WeekOfYear()
        {
            DateTime time = DateTime.Today;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private void UpdateText(List<Event> ongoing, List<Event> upcoming)
        {
            StringBuilder sb = new();
            if (ongoing.Count != 0)
            {
                sb.AppendLine("Now:");
                foreach (Event entry in ongoing)
                {
                    sb.AppendLine($"    {entry.Subject}");
                }
            }
            DateTime? nextStartTime = null;
            if (upcoming.Count != 0)
            {
                sb.AppendLine("Next:");
                foreach (Event entry in upcoming)
                {
                    sb.Append("    ");
                    if (nextStartTime is not null)
                    {
                        sb.Append($"+{entry.StartTime.Subtract(nextStartTime ?? DateTime.Now).Minutes}m ");
                    }
                    sb.AppendLine($"{entry.Subject}");
                    nextStartTime ??= entry.StartTime;
                }
            }
            LabelNowAndNextInfo.Text = sb.ToString();

            string datePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string timeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;
            LabelCurrentTime.Text = DateTime.Now.ToString($"{datePattern} {timeFormat} (CW{GetIso8601WeekOfYear()})");
        }

        private void UpdateClock(List<Event> ongoing, List<Event> upcoming)
        {
            clock.SetEventTimes(upcoming.Select(x => x.StartTime));
        }

        private void UpdateState()
        {
            UpdateState(false);
        }

        List<Event> ongoingEvents = new();
        List<Event> upcomingEvents = new();

        private void UpdateEventState()
        {
            List<Event> ongoing = Schedule.GetOngoingEvents().ToList();
            List<Event> upcoming = Schedule.GetUpcomingEvents().ToList();

            ongoingEvents = ongoing;
            upcomingEvents = upcoming;
        }

        private void FilterEventState()
        {
            ongoingEvents.RemoveAll(x => x.EndTime < DateTime.Now);
            upcomingEvents.RemoveAll(x => x.StartTime < DateTime.Now);
        }

        private void UpdateState(bool forceUpdate)
        {
            if (forceUpdate || (DateTime.Now.Second == 0 && DateTime.Now.Subtract(LastUpdateTime) > TimeSpan.FromSeconds(1)))
            {
                LastUpdateTime = DateTime.Now;
                Task.Run(UpdateEventState);
            }

            UpdateClock(ongoingEvents, upcomingEvents);
            UpdateText(ongoingEvents, upcomingEvents);
            IntPtr exStyle = GetWindowLongPtr(this.Handle, GWL_EXSTYLE);
            bool ontop = ((long)exStyle & WS_EX_TOPMOST) == WS_EX_TOPMOST;
            if (ontop != checkBox1.Checked)
            {
                ToggleTopMost();
            }

        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            UpdateState();
            Refresh();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UpdateState(true);
        }

        private void ToggleTopMost()
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void FrmMain_DoubleClick(object sender, EventArgs e)
        {
            ToggleTopMost();
        }

        private void PicClock_DoubleClick(object sender, EventArgs e)
        {
            ToggleTopMost();
        }

        private void LabelNowAndNextInfo_DoubleClick(object sender, EventArgs e)
        {
            ToggleTopMost();
        }

        private void LabelCurrentTime_DoubleClick(object sender, EventArgs e)
        {
            ToggleTopMost();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? cb = sender as CheckBox;
            if (cb != null)
            {
                TopMost = cb.Checked;
            }
        }
   }
}