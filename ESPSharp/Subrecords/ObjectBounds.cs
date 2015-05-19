using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp.Subrecords
{
    public class ObjectBounds : Subrecord
    {
        public ShortVector3 Point1;
        public ShortVector3 Point2;

        protected override void ReadData(ESPReader reader)
        {
            Point1.x = reader.ReadInt16();
            Point1.y = reader.ReadInt16();
            Point1.z = reader.ReadInt16();

            Point2.x = reader.ReadInt16();
            Point2.y = reader.ReadInt16();
            Point2.z = reader.ReadInt16();
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write(Point1.x);
            writer.Write(Point1.y);
            writer.Write(Point1.z);

            writer.Write(Point2.x);
            writer.Write(Point2.y);
            writer.Write(Point2.z);
        }

        protected override void WriteDataXML(XElement ele)
        {
            ele.Add(
                new XElement("Point1",
                    new XElement("X", Point1.x),
                    new XElement("Y", Point1.y),
                    new XElement("Z", Point1.z)),
                new XElement("Point2",
                    new XElement("X", Point2.x),
                    new XElement("Y", Point2.y),
                    new XElement("Z", Point2.z)));
        }

        protected override void ReadDataXML(XElement ele)
        {
            XElement point = ele.Element("Point1");

            Point1.x = point.Element("X").ToInt16();
            Point1.y = point.Element("Y").ToInt16();
            Point1.z = point.Element("Z").ToInt16();

            point = ele.Element("Point2");

            Point2.x = point.Element("X").ToInt16();
            Point2.y = point.Element("Y").ToInt16();
            Point2.z = point.Element("Z").ToInt16();
        }
    }
}
