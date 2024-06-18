using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Core.Util
{
    public static class DatetimeUtil
    {
        public static DateTime getDate(DateTime date, bool zeroHour = true)
        {
            if(zeroHour)
                return new DateTime(date.Year, date.Month, date.Day);
            else
                return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, 999);
        }
    }
}
