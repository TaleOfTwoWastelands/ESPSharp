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

namespace ESPSharp.Subrecords
{
    public partial class SubMarker : Subrecord, ICloneable<SubMarker>
    {

        public SubMarker()
        {
        }

        public SubMarker(SubMarker copyObject)
        {
        }

        protected override void ReadData(ESPReader reader)
        {
        }

        protected override void WriteData(ESPWriter writer)
        {
        }

        protected override void WriteDataXML(XElement ele)
        {
        }

        protected override void ReadDataXML(XElement ele)
        {
        }

        public SubMarker Clone()
        {
            return new SubMarker(this);
        }
    }
}