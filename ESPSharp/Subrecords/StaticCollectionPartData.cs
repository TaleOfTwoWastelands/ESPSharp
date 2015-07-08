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
    public class StaticCollectionPartData : Subrecord, ICloneable<StaticCollectionPartData>
    {
        List<StaticPlacement> Placements { get; set; }

        public StaticCollectionPartData()
        {
            Placements = new List<StaticPlacement>();
        }

        public StaticCollectionPartData(List<StaticPlacement> Placements)
        {
            foreach (var placement in Placements)
            {
                this.Placements.Add(placement);
            }
        }

        public StaticCollectionPartData(StaticCollectionPartData copyObject)
        {
            foreach (var placement in copyObject.Placements)
            {
                Placements.Add(placement);
            }
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream))
            {
                try
                {
                    int count = (int)stream.Length / 28;

                    for (int i = 0; i < count; i++)
                    {
                        StaticPlacement placement = new StaticPlacement();
                        placement.PosX = subReader.ReadSingle();
                        placement.PosY = subReader.ReadSingle();
                        placement.PosZ = subReader.ReadSingle();
                        placement.RotX = subReader.ReadSingle();
                        placement.RotY = subReader.ReadSingle();
                        placement.RotZ = subReader.ReadSingle();
                        placement.Scale = subReader.ReadSingle();

                        Placements.Add(placement);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            foreach (var placement in Placements)
            {
                writer.Write(placement.PosX);
                writer.Write(placement.PosY);
                writer.Write(placement.PosZ);
                writer.Write(placement.RotX);
                writer.Write(placement.RotY);
                writer.Write(placement.RotZ);
                writer.Write(placement.Scale);
            }
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;
            XElement subSubEle;

            foreach (var placement in Placements)
            {
                subEle = new XElement("Placement");
                ele.Add(subEle);

                subEle.TryPathTo("Position/X", true, out subSubEle);
                subSubEle.Value = placement.PosX.ToString("G15");

                subEle.TryPathTo("Position/Y", true, out subSubEle);
                subSubEle.Value = placement.PosY.ToString("G15");

                subEle.TryPathTo("Position/Z", true, out subSubEle);
                subSubEle.Value = placement.PosZ.ToString("G15");

                subEle.TryPathTo("Rotation/X", true, out subSubEle);
                subSubEle.Value = placement.RotX.ToString("G15");

                subEle.TryPathTo("Rotation/Y", true, out subSubEle);
                subSubEle.Value = placement.RotY.ToString("G15");

                subEle.TryPathTo("Rotation/Z", true, out subSubEle);
                subSubEle.Value = placement.RotZ.ToString("G15");

                subEle.TryPathTo("Scale", true, out subSubEle);
                subSubEle.Value = placement.Scale.ToString("G15");
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subSubEle;

            foreach (XElement subEle in ele.Elements("Placement"))
            {
                StaticPlacement placement = new StaticPlacement();

                if (subEle.TryPathTo("Position/X", false, out subSubEle))
                {
                    placement.PosX = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Position/Y", false, out subSubEle))
                {
                    placement.PosY = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Position/Z", false, out subSubEle))
                {
                    placement.PosZ = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Rotation/X", false, out subSubEle))
                {
                    placement.RotX = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Rotation/Y", false, out subSubEle))
                {
                    placement.RotY = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Rotation/Z", false, out subSubEle))
                {
                    placement.RotZ = subSubEle.ToSingle();
                }

                if (subEle.TryPathTo("Scale", false, out subSubEle))
                {
                    placement.Scale = subSubEle.ToSingle();
                }

                Placements.Add(placement);
            }
        }

        public StaticCollectionPartData Clone()
        {
            return new StaticCollectionPartData(this);
        }

    }

    public struct StaticPlacement
    {
        public Single PosX { get; set; }
        public Single PosY { get; set; }
        public Single PosZ { get; set; }
        public Single RotX { get; set; }
        public Single RotY { get; set; }
        public Single RotZ { get; set; }
        public Single Scale { get; set; }
    }
}
