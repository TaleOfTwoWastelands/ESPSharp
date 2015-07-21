using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.DataTypes
{
    public partial class DateStamp : IESPSerializable, ICloneable
    {
        public static DateStamp Now
        {
            get
            {
                DateStamp now = new DateStamp();
                now.DayOfMonth = (byte)DateTime.Now.Day;
                now.MonthsSince2001 = GetMonthsSince2001();

                return now;
            }
        }

        private static byte GetMonthsSince2001()
        {
            int years = DateTime.Now.Year - 2001;
            int months = DateTime.Now.Month + years*12;

            return (byte)months;
        }
    }
}