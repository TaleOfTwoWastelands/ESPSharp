using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ESPSharp.DataTypes;
using ESPSharp.Interfaces;

namespace ESPSharp.Subrecords
{
    public class NavMeshDoorList : Subrecord, IReferenceContainer, ICloneable<NavMeshDoorList>
    {
        List<NavMeshDoor> Doors { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Doors = new List<NavMeshDoor>();

            for (int i = 0; i < size / 8; i++)
            {
                NavMeshDoor temp = new NavMeshDoor();
                temp.ReadBinary(reader);
                Doors.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Doors)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Doors)
            {
                XElement subEle = new XElement("Door");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Doors = new List<NavMeshDoor>();

            foreach (var subEle in ele.Elements("Door"))
            {
                NavMeshDoor temp = new NavMeshDoor();
                temp.ReadXML(subEle, master);
                Doors.Add(temp);
            }
        }

        public NavMeshDoorList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
