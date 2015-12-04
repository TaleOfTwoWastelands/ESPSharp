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
    public class PackageLocation : Subrecord, ICloneable
    {
        public PackageLocationType Type { get; set; }
        public dynamic Location { get; set; }
        public Int32 Radius { get; set; }

        public PackageLocation()
        {
            Type = new PackageLocationType();
            Location = new UInt32();
            Radius = new Int32();
        }

        public PackageLocation(PackageLocationType Type, dynamic Location, Int32 Radius)
        {
            this.Type = Type;
            this.Location = Location;
            this.Radius = Radius;
        }

        public PackageLocation(PackageLocation copyObject)
        {
            Type = copyObject.Type;
            Location = copyObject.Location;
            Radius = copyObject.Radius;
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
            {
                try
                {
                    Type = subReader.ReadEnum<PackageLocationType>();

                    switch (Type)
                    {
                        case PackageLocationType.NearReference:
                            Location = new FormID(subReader.ReadUInt32());
                            break;
                        case PackageLocationType.InCell:
                            Location = new FormID(subReader.ReadUInt32());
                            break;
                        case PackageLocationType.NearCurrentLocation:
                            Location = subReader.ReadBytes(4);
                            break;
                        case PackageLocationType.NearEditorLocation:
                            Location = subReader.ReadBytes(4);
                            break;
                        case PackageLocationType.ObjectID:
                            Location = new FormID(subReader.ReadUInt32());
                            break;
                        case PackageLocationType.ObjectType:
                            Location = (ObjectType)subReader.ReadUInt32();
                            break;
                        case PackageLocationType.NearLinkedReference:
                            Location = subReader.ReadBytes(4);
                            break;
                        case PackageLocationType.AtPackageLocation:
                            Location = subReader.ReadBytes(4);
                            break;
                    }

                    Radius = subReader.ReadInt32();
                }
                catch
                {
                    return;
                }
            }
        }

        protected override void WriteData(ESPWriter writer)
        {
            writer.Write((uint)Type);

            switch (Type)
            {
                case PackageLocationType.NearReference:
                    (Location as FormID).WriteBinary(writer);
                    break;
                case PackageLocationType.InCell:
                    (Location as FormID).WriteBinary(writer);
                    break;
                case PackageLocationType.NearCurrentLocation:
                    writer.Write(Location);
                    break;
                case PackageLocationType.NearEditorLocation:
                    writer.Write(Location);
                    break;
                case PackageLocationType.ObjectID:
                    (Location as FormID).WriteBinary(writer);
                    break;
                case PackageLocationType.ObjectType:
                    writer.Write((uint)Location);
                    break;
                case PackageLocationType.NearLinkedReference:
                    writer.Write(Location);
                    break;
                case PackageLocationType.AtPackageLocation:
                    writer.Write(Location);
                    break;
            }

            writer.Write(Radius);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Type", true, out subEle);
            subEle.Value = Type.ToString();

            ele.TryPathTo("Location", true, out subEle);
            switch (Type)
            {
                case PackageLocationType.NearReference:
                    ((FormID)Location).WriteXML(subEle, master);
                    break;
                case PackageLocationType.InCell:
                    ((FormID)Location).WriteXML(subEle, master);
                    break;
                case PackageLocationType.NearCurrentLocation:
                    subEle.Value = ((byte[])Location).ToBase64();
                    break;
                case PackageLocationType.NearEditorLocation:
                    subEle.Value = ((byte[])Location).ToBase64();
                    break;
                case PackageLocationType.ObjectID:
                    ((FormID)Location).WriteXML(subEle, master);
                    break;
                case PackageLocationType.ObjectType:
                    subEle.Value = Location.ToString();
                    break;
                case PackageLocationType.NearLinkedReference:
                    subEle.Value = ((byte[])Location).ToBase64();
                    break;
                case PackageLocationType.AtPackageLocation:
                    subEle.Value = ((byte[])Location).ToBase64();
                    break;
            }

            ele.TryPathTo("Radius", true, out subEle);
            subEle.Value = Radius.ToString();
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Type", false, out subEle))
            {
                Type = subEle.ToEnum<PackageLocationType>();
            }

            if (ele.TryPathTo("Location", false, out subEle))
            {
                switch (Type)
                {
                    case PackageLocationType.NearReference:
                        Location = new FormID();
                        (Location as FormID).ReadXML(subEle, master);
                        break;
                    case PackageLocationType.InCell:
                        Location = new FormID();
                        (Location as FormID).ReadXML(subEle, master);
                        break;
                    case PackageLocationType.NearCurrentLocation:
                        Location = subEle.ToBytes();
                        break;
                    case PackageLocationType.NearEditorLocation:
                        Location = subEle.ToBytes();
                        break;
                    case PackageLocationType.ObjectID:
                        Location = new FormID();
                        (Location as FormID).ReadXML(subEle, master);
                        break;
                    case PackageLocationType.ObjectType:
                        Location = subEle.ToEnum<ObjectType>();
                        break;
                    case PackageLocationType.NearLinkedReference:
                        Location = subEle.ToBytes();
                        break;
                    case PackageLocationType.AtPackageLocation:
                        Location = subEle.ToBytes();
                        break;
                }
            }

            if (ele.TryPathTo("Radius", false, out subEle))
            {
                Radius = subEle.ToInt32();
            }
        }

        public override object Clone()
        {
            return new PackageLocation(this);
        }

    }
}
