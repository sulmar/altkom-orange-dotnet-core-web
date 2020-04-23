using System;

namespace MyOrange.Web.TagHelpers
{
    public class TimeSinceService : ITimeSinceService
    {
        public string TimeSince(DateTime dateTime)
        {
            return PeriodOfTimeOutput(DateTime.Now.Subtract(dateTime));
        }

        private string PeriodOfTimeOutput(TimeSpan timeSpan)
        {
            // C# 8.0
            string how_long_ago = timeSpan switch
            {
                var t when t.Days > 1 => $"{t.Days} days ago",
                var t when t.Days == 1 => $"{t.Days} days ago",
                var t when t.Hours >= 1 => $"{t.Hours} hours ago",
                var t when t.Minutes >= 1 => $"{t.Minutes} min ago",
                var t when t.Seconds >= 1 => $"{t.Minutes} sec ago",

                _ => "ago" // default value
            };

            return how_long_ago;
        }
    }
}
