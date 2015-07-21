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
	public partial class NavigationConnectionInfo : Subrecord, ICloneable, IComparable<NavigationConnectionInfo>, IEquatable<NavigationConnectionInfo>, IReferenceContainer  
	{
		public FormID Unknown1 { get; set; }
		public List<FormID> Unknown2 { get; set; }
		public List<FormID> Unknown3 { get; set; }
		public List<FormID> Doors { get; set; }

		public NavigationConnectionInfo(string Tag = null)
			:base(Tag)
		{
			Unknown1 = new FormID();
			Unknown2 = new List<FormID>();
			Unknown3 = new List<FormID>();
			Doors = new List<FormID>();
		}

		public NavigationConnectionInfo(FormID Unknown1, List<FormID> Unknown2, List<FormID> Unknown3, List<FormID> Doors)
		{
			this.Unknown1 = Unknown1;
			this.Unknown2 = Unknown2;
			this.Unknown3 = Unknown3;
			this.Doors = Doors;
		}

		public NavigationConnectionInfo(NavigationConnectionInfo copyObject)
		{
			if (copyObject.Unknown1 != null)
				Unknown1 = (FormID)copyObject.Unknown1.Clone();
			if (copyObject.Unknown2 != null)
				foreach(var temp in copyObject.Unknown2)
					Unknown2.Add((FormID)temp.Clone());
			if (copyObject.Unknown3 != null)
				foreach(var temp in copyObject.Unknown3)
					Unknown3.Add((FormID)temp.Clone());
			if (copyObject.Doors != null)
				foreach(var temp in copyObject.Doors)
					Doors.Add((FormID)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Unknown1.ReadBinary(subReader);
					Int32 Unknown2Count = subReader.ReadInt32();

					for (int i = 0; i < Unknown2Count; i++)
					{
						var temp = new FormID();
						temp.ReadBinary(subReader);
						Unknown2.Add(temp);
					}
					Int32 Unknown3Count = subReader.ReadInt32();

					for (int i = 0; i < Unknown3Count; i++)
					{
						var temp = new FormID();
						temp.ReadBinary(subReader);
						Unknown3.Add(temp);
					}
					Int32 DoorsCount = subReader.ReadInt32();

					for (int i = 0; i < DoorsCount; i++)
					{
						var temp = new FormID();
						temp.ReadBinary(subReader);
						Doors.Add(temp);
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
			Unknown1.WriteBinary(writer);
			writer.Write((Int32)Unknown2.Count);
			foreach (var temp in Unknown2)
			{
				temp.WriteBinary(writer);
			}
			writer.Write((Int32)Unknown3.Count);
			foreach (var temp in Unknown3)
			{
				temp.WriteBinary(writer);
			}
			writer.Write((Int32)Doors.Count);
			foreach (var temp in Doors)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Unknown1", true, out subEle);
			Unknown1.WriteXML(subEle, master);

			ele.TryPathTo("Unknown2", true, out subEle);
			foreach (var temp in Unknown2)
			{
				XElement e = new XElement("Unknown");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

			ele.TryPathTo("Unknown3", true, out subEle);
			foreach (var temp in Unknown3)
			{
				XElement e = new XElement("Unknown");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

			ele.TryPathTo("Doors", true, out subEle);
			foreach (var temp in Doors)
			{
				XElement e = new XElement("Door");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Unknown1", false, out subEle))
				Unknown1.ReadXML(subEle, master);

			if (ele.TryPathTo("Unknown2", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new FormID();
					temp.ReadXML(e, master);
					Unknown2.Add(temp);
				}

			if (ele.TryPathTo("Unknown3", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new FormID();
					temp.ReadXML(e, master);
					Unknown3.Add(temp);
				}

			if (ele.TryPathTo("Doors", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new FormID();
					temp.ReadXML(e, master);
					Doors.Add(temp);
				}
		}

		public override object Clone()
		{
			return new NavigationConnectionInfo(this);
		}

        public int CompareTo(NavigationConnectionInfo other)
        {
			return Unknown1.CompareTo(other.Unknown1);
        }

        public static bool operator >(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(NavigationConnectionInfo other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Unknown1 == other.Unknown1 &&
				Unknown2.SequenceEqual(other.Unknown2) &&
				Unknown3.SequenceEqual(other.Unknown3) &&
				Doors.SequenceEqual(other.Doors);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavigationConnectionInfo other = obj as NavigationConnectionInfo;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Unknown1.GetHashCode();
        }

        public static bool operator ==(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
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

        public static bool operator !=(NavigationConnectionInfo objA, NavigationConnectionInfo objB)
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