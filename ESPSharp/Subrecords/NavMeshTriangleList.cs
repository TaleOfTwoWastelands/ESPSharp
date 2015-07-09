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
    public class NavMeshTriangleList : Subrecord, IReferenceContainer, ICloneable<NavMeshTriangleList>
    {
        List<NavMeshTriangle> Triangles { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Triangles = new List<NavMeshTriangle>();

            for (int i = 0; i < size / 52; i++)
            {
                NavMeshTriangle temp = new NavMeshTriangle();
                temp.ReadBinary(reader);
                Triangles.Add(temp);
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Triangles)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Triangles)
            {
                XElement subEle = new XElement("Triangle");
                temp.WriteXML(subEle, master);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Triangles = new List<NavMeshTriangle>();

            foreach (var subEle in ele.Elements("Triangle"))
            {
                NavMeshTriangle temp = new NavMeshTriangle();
                temp.ReadXML(subEle, master);
                Triangles.Add(temp);
            }
        }

        public NavMeshTriangleList Clone()
        {
            throw new NotImplementedException();
        }
    }
}
