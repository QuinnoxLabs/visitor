using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Core.Helpers
{
    public class ApiCustomValues
    {
        public string UserExistsWithEmail { get; set; }
        public string UserExistsWithUsername { get; set; }
        public string Conflict { get; set; }

        public DateTime CurrentDateTime
        {
            get {
                var cetZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                var cetTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                return cetTime;
            }
        }
    }
}
