using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum PackageScheduleDays : sbyte
    {
        Any = -1,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Weekdays,
        Weekends,
        Mon_Wed_Fri,
        Tue_Thur
    }
}
