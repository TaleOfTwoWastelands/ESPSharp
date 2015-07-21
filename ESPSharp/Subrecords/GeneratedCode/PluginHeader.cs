
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
	public partial class PluginHeader : Subrecord, ICloneable, IComparable<PluginHeader>, IEquatable<PluginHeader>  
	{
		public Single Version { get; set; }
		public UInt32 RecordCount { get; set; }
		public UInt32 NextObjectID { get; set; }

		public PluginHeader(string Tag = null)
			:base(Tag)
		{
			Version = new Single();
			RecordCount = new UInt32();
			NextObjectID = new UInt32();
		}

		public PluginHeader(Single Version, UInt32 RecordCount, UInt32 NextObjectID)
		{
			this.Version = Version;
			this.RecordCount = RecordCount;
			this.NextObjectID = NextObjectID;
		}

		public PluginHeader(PluginHeader copyObject)
		{
			Version = copyObject.Version;
			RecordCount = copyObject.RecordCount;
			NextObjectID = copyObject.NextObjectID;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Version = subReader.ReadSingle();
					RecordCount = subReader.ReadUInt32();
					NextObjectID = subReader.ReadUInt32();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Version);
			writer.Write(RecordCount);
			writer.Write(NextObjectID);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Version", true, out subEle);
			subEle.Value = Version.ToString("G15");

			ele.TryPathTo("RecordCount", true, out subEle);
			subEle.Value = RecordCount.ToString();

			ele.TryPathTo("NextObjectID", true, out subEle);
			subEle.Value = NextObjectID.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Version", false, out subEle))
				Version = subEle.ToSingle();

			if (ele.TryPathTo("RecordCount", false, out subEle))
				RecordCount = subEle.ToUInt32();

			if (ele.TryPathTo("NextObjectID", false, out subEle))
				NextObjectID = subEle.ToUInt32();
		}

		public override object Clone()
		{
			return new PluginHeader(this);
		}

        public int CompareTo(PluginHeader other)
        {
			return RecordCount.CompareTo(other.RecordCount);
        }

        public static bool operator >(PluginHeader objA, PluginHeader objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(PluginHeader objA, PluginHeader objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(PluginHeader objA, PluginHeader objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(PluginHeader objA, PluginHeader objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(PluginHeader other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Version == other.Version &&
				RecordCount == other.RecordCount &&
				NextObjectID == other.NextObjectID;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            PluginHeader other = obj as PluginHeader;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return RecordCount.GetHashCode();
        }

        public static bool operator ==(PluginHeader objA, PluginHeader objB)
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

        public static bool operator !=(PluginHeader objA, PluginHeader objB)
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