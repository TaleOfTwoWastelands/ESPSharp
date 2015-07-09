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
    public class NavMeshVertexList : Subrecord, IReferenceContainer, ICloneable<NavMeshVertexList>
    {
        List<XYZFloat> Vertices { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Vertices = new List<XYZFloat>();

            for (int i = 0; i < size / 52; i++)
            {
                XYZFloat temp = new XYZFloat();
                temp.ReadBinary(reader);
                Vertices.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Vertices)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Vertices)
            {
                XElement subEle = new XElement("Vertex");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Vertices = new List<XYZFloat>();

            foreach (var subEle in ele.Elements("Vertex"))
            {
                XYZFloat temp = new XYZFloat();
                temp.ReadXML(subEle, master);
                Vertices.Add(temp);
            }
        }

        public NavMeshVertexList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
