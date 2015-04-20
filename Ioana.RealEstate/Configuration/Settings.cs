using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Configuration
{
    public class Settings
    {
        public static readonly TimeZoneInfo DisplayDateTimeZone;

        public static readonly CultureInfo DisplayCulture;

        public static readonly string DisplayDateFormat;

        static Settings()
        {
            Settings.DisplayDateTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            Settings.DisplayCulture = CultureInfo.GetCultureInfo("bg-BG");
            Settings.DisplayDateFormat = "F";
        }
    }
}