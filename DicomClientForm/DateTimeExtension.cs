using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomClientForm
{
    public static class DateTimeExtension
    {
        private static DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static long Timestamp(this DateTime dt)
        {
            TimeSpan ts = dt - startTime;
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
