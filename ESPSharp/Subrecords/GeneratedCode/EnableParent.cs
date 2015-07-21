
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
	public partial class EnableParent : Subrecord, ICloneable, IComparable<EnableParent>, IEquatable<EnableParent>  
	{
		public FormID Parent { get; set; }
		public EnableParentFlags Flags { get; set; }
		public Byte[] Unknown { get; set; }

		public EnableParent(string Tag = null)
			:base(Tag)
		{
			Parent = new FormID();
			Flags = new EnableParentFlags();
			Unknown = new byte[3];
		}

		public EnableParent(FormID Parent, EnableParentFlags Flags, Byte[] Unknown)
		{
			this.Parent = Parent;
			this.Flags = Flags;
			this.Unknown = Unknown;
		}

		public EnableParent(EnableParent copyObject)
		{
			if (copyObject.Parent != null)
				Parent = (FormID)copyObject.Parent.Clone();
			Flags = copyObject.Flags;
			if (copyObject.Unknown != null)
				Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					Flags = subReader.ReadEnum<EnableParentFlags>();
					Unknown = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Parent.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unknown == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnknownXML(ele, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Parent", false, out subEle))
				Parent.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<EnableParentFlags>();

			ReadUnknownXML(ele, master);
		}

		public override object Clone()
		{
			return new EnableParent(this);
		}

        public int CompareTo(EnableParent other)
        {
			return Parent.CompareTo(other.Parent);
        }

        public static bool operator >(EnableParent objA, EnableParent objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EnableParent objA, EnableParent objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EnableParent objA, EnableParent objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EnableParent objA, EnableParent objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(EnableParent other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Parent == other.Parent &&
				Flags == other.Flags &&
				Unknown.SequenceEqual(other.Unknown);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EnableParent other = obj as EnableParent;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Parent.GetHashCode();
        }

        public static bool operator ==(EnableParent objA, EnableParent objB)
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

        public static bool operator !=(EnableParent objA, EnableParent objB)
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

		partial void ReadUnknownXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnknownXML(XElement ele, ElderScrollsPlugin master);
	}
}