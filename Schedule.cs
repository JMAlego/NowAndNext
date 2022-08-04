using System.Globalization;
using Microsoft.Office.Interop.Outlook;

namespace NowAndNext
{
    internal class Event
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public string Subject { get; }

        public Event(DateTime StartTime, DateTime EndTime, string Subject)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Subject = Subject;
        }
    }

    internal class Schedule
    {
        private static readonly ISet<OlResponseStatus> IGNORED_STATUSES = new HashSet<OlResponseStatus>() { OlResponseStatus.olResponseDeclined, OlResponseStatus.olResponseTentative };

        private static Items? GetDefaultFolderItems()
        {
            Microsoft.Office.Interop.Outlook.Application application = new();
            NameSpace? mapiNamespace = application.Application.GetNamespace("MAPI");

            if (mapiNamespace is null)
                return null;

            MAPIFolder? calendar = mapiNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            if (calendar is null)
                return null;

            return calendar.Items;
        }

        private static long GetCursorTime()
        {
            return DateTime.Now.Ticks;
        }

        private static IEnumerable<Event> GetCalendarEntriesForPeriod(DateTime periodStart)
        {
            return GetCalendarEntriesForPeriod(periodStart, TimeSpan.FromDays(1));
        }

        private static IEnumerable<Event> GetCalendarEntriesForPeriod(DateTime periodStart, TimeSpan period)
        {
            if (period < TimeSpan.FromDays(1))
                period = TimeSpan.FromDays(1);

            Items? appointments = GetDefaultFolderItems();

            if (appointments is null)
                yield break;

            appointments.Sort("[Start]");
            appointments.IncludeRecurrences = true;

            DateTime periodEnd = periodStart.Add(period);

            string periodStartString = periodStart.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            string periodEndString = periodEnd.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);

            Items restrictedAppointments = appointments.Restrict($"[Start] >= '{periodStartString}' AND [Start] < '{periodEndString}'");

            foreach (var item in restrictedAppointments)
            {
                if (item is not AppointmentItem appointmentItem)
                    continue;

                if (IGNORED_STATUSES.Contains(appointmentItem.ResponseStatus))
                    continue;

                yield return new Event(appointmentItem.Start, appointmentItem.Start.AddMinutes(appointmentItem.Duration), appointmentItem.Subject);
            }
        }

        public static IEnumerable<Event> GetOngoingEvents()
        {
            IEnumerable<Event> events = GetCalendarEntriesForPeriod(DateTime.Today);
            foreach (Event entry in events)
            {
                TimeSpan minutesToStart = entry.StartTime.Subtract(DateTime.Now);
                TimeSpan minutesToEnd = entry.EndTime.Subtract(DateTime.Now);

                if (minutesToStart < TimeSpan.Zero && minutesToEnd > TimeSpan.Zero)
                    yield return entry;
            }
        }

        public static IEnumerable<Event> GetUpcomingEvents()
        {
            IEnumerable<Event> events = GetCalendarEntriesForPeriod(DateTime.Today);
            foreach (Event entry in events)
            {
                TimeSpan minutesToStart = entry.StartTime.Subtract(DateTime.Now);

                if (minutesToStart < TimeSpan.FromMinutes(60) && minutesToStart > TimeSpan.Zero)
                    yield return entry;
            }
        }
    }
}
