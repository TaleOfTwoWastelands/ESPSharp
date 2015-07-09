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
    public class NavMeshGrid : Subrecord, ICloneable<NavMeshGrid>
    {
        public UInt32 Divisor { get; set; }
        public Single MaxDistanceX { get; set; }
        public Single MaxDistanceY { get; set; }
        public Single MinX { get; set; }
        public Single MinY { get; set; }
        public Single MinZ { get; set; }
        public Single MaxX { get; set; }
        public Single MaxY { get; set; }
        public Single MaxZ { get; set; }
        public List<List<Int16>> Cell { get; set; }

        public NavMeshGrid()
        {
            Divisor = new UInt32();
            MaxDistanceX = new Single();
            MaxDistanceY = new Single();
            MinX = new Single();
            MinY = new Single();
            MinZ = new Single();
            MaxX = new Single();
            MaxY = new Single();
            MaxZ = new Single();
            Cell = new List<List<short>>();
        }

        public NavMeshGrid(UInt32 Divisor, Single MaxDistanceX, Single MaxDistanceY, Single MinX, Single MinY, Single MinZ, Single MaxX, Single MaxY, Single MaxZ, List<List<short>> Cell)
        {
            this.Divisor = Divisor;
            this.MaxDistanceX = MaxDistanceX;
            this.MaxDistanceY = MaxDistanceY;
            this.MinX = MinX;
            this.MinY = MinY;
            this.MinZ = MinZ;
            this.MaxX = MaxX;
            this.MaxY = MaxY;
            this.MaxZ = MaxZ;
            this.Cell = Cell;
        }

        public NavMeshGrid(NavMeshGrid copyObject)
        {
            Divisor = copyObject.Divisor;
            MaxDistanceX = copyObject.MaxDistanceX;
            MaxDistanceY = copyObject.MaxDistanceY;
            MinX = copyObject.MinX;
            MinY = copyObject.MinY;
            MinZ = copyObject.MinZ;
            MaxX = copyObject.MaxX;
            MaxY = copyObject.MaxY;
            MaxZ = copyObject.MaxZ;
            foreach(List<short> list in copyObject.Cell)
            {
                List<short> newList = new List<short>();
                foreach (short num in list)
                {
                    newList.Add(num);
                }
                Cell.Add(newList);
            }
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream))
            {
                try
                {
                    Divisor = subReader.ReadUInt32();
                    MaxDistanceX = subReader.ReadSingle();
                    MaxDistanceY = subReader.ReadSingle();
                    MinX = subReader.ReadSingle();
                    MinY = subReader.ReadSingle();
                    MinZ = subReader.ReadSingle();
                    MaxX = subReader.ReadSingle();
                    MaxY = subReader.ReadSingle();
                    MaxZ = subReader.ReadSingle();

                    for (int i = 0; i < Divisor; i++ )
                    {
                        List<short> newList = new List<short>();
                        for (int j = 0; j < (size - 36)/(2*Divisor); j++)
                            newList.Add(reader.ReadInt16());
                        Cell.Add(newList);
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
            writer.Write(Divisor);
            writer.Write(MaxDistanceX);
            writer.Write(MaxDistanceY);
            writer.Write(MinX);
            writer.Write(MinY);
            writer.Write(MinZ);
            writer.Write(MaxX);
            writer.Write(MaxY);
            writer.Write(MaxZ);
            foreach (List<short> list in Cell)
                foreach (short num in list)
                    writer.Write(num);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Divisor", true, out subEle);
            subEle.Value = Divisor.ToString();

            ele.TryPathTo("MaxDistance/X", true, out subEle);
            subEle.Value = MaxDistanceX.ToString("G15");

            ele.TryPathTo("MaxDistance/Y", true, out subEle);
            subEle.Value = MaxDistanceY.ToString("G15");

            ele.TryPathTo("Min/X", true, out subEle);
            subEle.Value = MinX.ToString("G15");

            ele.TryPathTo("Min/Y", true, out subEle);
            subEle.Value = MinY.ToString("G15");

            ele.TryPathTo("Min/Z", true, out subEle);
            subEle.Value = MinZ.ToString("G15");

            ele.TryPathTo("Max/X", true, out subEle);
            subEle.Value = MaxX.ToString("G15");

            ele.TryPathTo("Max/Y", true, out subEle);
            subEle.Value = MaxY.ToString("G15");

            ele.TryPathTo("Max/Z", true, out subEle);
            subEle.Value = MaxZ.ToString("G15");

            ele.TryPathTo("Cell", true, out subEle);
            foreach (List<short> list in Cell)
            {
                XElement cell = new XElement("Row");
                foreach (short num in list)
                    cell.Add(new XElement("Triangle", num));
                subEle.Add(cell);
            }
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Divisor", false, out subEle))
            {
                Divisor = subEle.ToUInt32();
            }

            if (ele.TryPathTo("MaxDistance/X", false, out subEle))
            {
                MaxDistanceX = subEle.ToSingle();
            }

            if (ele.TryPathTo("MaxDistance/Y", false, out subEle))
            {
                MaxDistanceY = subEle.ToSingle();
            }

            if (ele.TryPathTo("Min/X", false, out subEle))
            {
                MinX = subEle.ToSingle();
            }

            if (ele.TryPathTo("Min/Y", false, out subEle))
            {
                MinY = subEle.ToSingle();
            }

            if (ele.TryPathTo("Min/Z", false, out subEle))
            {
                MinZ = subEle.ToSingle();
            }

            if (ele.TryPathTo("Max/X", false, out subEle))
            {
                MaxX = subEle.ToSingle();
            }

            if (ele.TryPathTo("Max/Y", false, out subEle))
            {
                MaxY = subEle.ToSingle();
            }

            if (ele.TryPathTo("Max/Z", false, out subEle))
            {
                MaxZ = subEle.ToSingle();
            }

            if (ele.TryPathTo("Cell", false, out subEle))
            {
                foreach (XElement cell in subEle.Elements("Row"))
                {
                    List<short> newList = new List<short>();
                    foreach (XElement num in cell.Elements("Triangle"))
                        newList.Add(num.ToInt16());
                    Cell.Add(newList);
                }
            }
        }

        public NavMeshGrid Clone()
        {
            return new NavMeshGrid(this);
        }

    }
}
