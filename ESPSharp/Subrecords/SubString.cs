
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
    public class SubString : Subrecord, ICloneable, IComparable<SubString>, IEquatable<SubString>
    {
        public String Value { get; set; }
        public UInt32 LocalizedID { get; set; }

        public SubString(string Tag = null)
            : base(Tag)
        {
            Value = "";
            LocalizedID = 0;
        }

        public SubString(String Value, UInt32 LocalizedID)
        {
            this.Value = Value;
            this.LocalizedID = LocalizedID;
        }

        public SubString(SubString copyObject)
        {
            if (copyObject.Value != null)
                Value = (String)copyObject.Value.Clone();
            LocalizedID = 0;
        }

        protected override void ReadData(ESPReader reader)
        {
            using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
            using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
            {
                try
                {
                    if (false)//subReader.Plugin.Header.Flags.HasFlag(RecordFlag.Localized) && size == 4)
                    {
                        LocalizedID = subReader.ReadUInt32();
                        if (LocalizedID == 0)
                            Value = "";
                        else
                            Value = LocalizedStrings.GetLocalizedString(LocalizedID, subReader.Plugin.Name.ToLower(), LocalizedStringType.Strings);
                    }
                    else
                    {
                        Value = subReader.ReadString();
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
            if (LocalizedID > 0)
                writer.Write(LocalizedID);
            else
                writer.Write(Value);
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Value", true, out subEle);
            subEle.Value = Value.ToString();

            if (LocalizedID > 0)
                subEle.Add(new XAttribute("LocalizedID", LocalizedID));
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Value", false, out subEle))
                Value = subEle.Value;

            if (subEle.Attribute("LocalizedID") != null)
                LocalizedID = uint.Parse(subEle.Attribute("LocalizedID").Value);
        }

        public override object Clone()
        {
            return new SubString(this);
        }

        public int CompareTo(SubString other)
        {
            return Value.CompareTo(other.Value);
        }

        public static bool operator >(SubString objA, SubString objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(SubString objA, SubString objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(SubString objA, SubString objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(SubString objA, SubString objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(SubString other)
        {
            if (System.Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (((object)this == null) || ((object)other == null))
            {
                return false;
            }

            return Value.SequenceEqual(other.Value) &&
                LocalizedID == other.LocalizedID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SubString other = obj as SubString;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(SubString objA, SubString objB)
        {
            if (System.Object.ReferenceEquals(objA, objB))
            {
                return true;
            }

            if (((object)objA == null) || ((object)objB == null))
            {
                return false;
            }

            return objA.Equals(objB);
        }

        public static bool operator !=(SubString objA, SubString objB)
        {
            if (System.Object.ReferenceEquals(objA, objB))
            {
                return false;
            }

            if (((object)objA == null) || ((object)objB == null))
            {
                return true;
            }

            return !objA.Equals(objB);
        }
    }
}