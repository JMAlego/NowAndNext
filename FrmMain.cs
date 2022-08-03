using System.Drawing.Drawing2D;
using System.Text;
using System.Drawing.Text;
using System.Globalization;

namespace NowAndNext
{
    public partial class FrmMain : Form
    {
        private readonly Clock clock;
        private DateTime LastUpdateTime = DateTime.Now;

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
            if (ongoing.Any())
            {
                sb.Append("Now:\n");
                foreach (Event entry in ongoing)
                {
                    sb.Append($"    {entry.Subject}\n");
                }
            }
            DateTime? nextStartTime = null;
            if (upcoming.Any())
            {
                sb.Append("Next:\n");
                foreach (Event entry in upcoming)
                {
                    sb.Append("    ");
                    if (nextStartTime is not null)
                    {
                        sb.Append($"+{entry.StartTime.Subtract(nextStartTime ?? DateTime.Now).Minutes}m ");
                    }
                    sb.Append($"{entry.Subject}\n");
                    nextStartTime ??= entry.StartTime;
                }
            }
            LabelNowAndNextInfo.Text = sb.ToString();
            LabelCurrentTime.Text = DateTime.Now.ToString($"yyyy-MM-dd HH:mm (CW{GetIso8601WeekOfYear()})");
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
            TopMost = !TopMost;
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
    }
}