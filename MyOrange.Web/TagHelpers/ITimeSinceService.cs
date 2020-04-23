using System;

namespace MyOrange.Web.TagHelpers
{
    public interface ITimeSinceService
    {
        string TimeSince(DateTime dateTime);
    }
}
