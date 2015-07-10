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
    public class RagdollDynamicBones : Subrecord, IReferenceContainer, ICloneable<RagdollDynamicBones>
    {
        List<ushort> Bones { get; set; }

        protected override void ReadData(ESPReader reader)
        {
            Bones = new List<ushort>();

            for (int i = 0; i < size / 2; i++)
                Bones.Add(reader.ReadUInt16());
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var temp in Bones)
                writer.Write(temp);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            foreach (var temp in Bones)
            {
                XElement subEle = new XElement("Bone", temp);
                ele.Add(subEle);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            Bones = new List<ushort>();

            foreach (var subEle in ele.Elements("Bone"))
                Bones.Add(subEle.ToUInt16());
        }

        public RagdollDynamicBones Clone()
        {
            throw new NotImplementedException();
        }
    }
}
