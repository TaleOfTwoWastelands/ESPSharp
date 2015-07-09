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
    public class NavMeshExternalConnectionList : Subrecord, IReferenceContainer, ICloneable<NavMeshExternalConnectionList>
    {
        List<NavMeshExternalConnection> ExternalConnections { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            ExternalConnections = new List<NavMeshExternalConnection>();

            for (int i = 0; i < size / 10; i++)
            {
                NavMeshExternalConnection temp = new NavMeshExternalConnection();
                temp.ReadBinary(reader);
                ExternalConnections.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in ExternalConnections)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in ExternalConnections)
            {
                XElement subEle = new XElement("ExternalConnection");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            ExternalConnections = new List<NavMeshExternalConnection>();

            foreach (var subEle in ele.Elements("ExternalConnection"))
            {
                NavMeshExternalConnection temp = new NavMeshExternalConnection();
                temp.ReadXML(subEle, master);
                ExternalConnections.Add(temp);
            }
        }

        public NavMeshExternalConnectionList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
