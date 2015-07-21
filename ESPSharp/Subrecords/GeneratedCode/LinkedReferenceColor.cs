
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
	public partial class LinkedReferenceColor : Subrecord, ICloneable, IComparable<LinkedReferenceColor>, IEquatable<LinkedReferenceColor>  
	{
		public Color Start { get; set; }
		public Color End { get; set; }

		public LinkedReferenceColor(string Tag = null)
			:base(Tag)
		{
			Start = new Color();
			End = new Color();
		}

		public LinkedReferenceColor(Color Start, Color End)
		{
			this.Start = Start;
			this.End = End;
		}

		public LinkedReferenceColor(LinkedReferenceColor copyObject)
		{
			if (copyObject.Start != null)
				Start = (Color)copyObject.Start.Clone();
			if (copyObject.End != null)
				End = (Color)copyObject.End.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Start.ReadBinary(subReader);
					End.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Start.WriteBinary(writer);
			End.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Start", true, out subEle);
			Start.WriteXML(subEle, master);

			ele.TryPathTo("End", true, out subEle);
			End.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Start", false, out subEle))
				Start.ReadXML(subEle, master);

			if (ele.TryPathTo("End", false, out subEle))
				End.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new LinkedReferenceColor(this);
		}

        public int CompareTo(LinkedReferenceColor other)
        {
			return Start.CompareTo(other.Start);
        }

        public static bool operator >(LinkedReferenceColor objA, LinkedReferenceColor objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LinkedReferenceColor objA, LinkedReferenceColor objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LinkedReferenceColor objA, LinkedReferenceColor objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LinkedReferenceColor objA, LinkedReferenceColor objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LinkedReferenceColor other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Start == other.Start &&
				End == other.End;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LinkedReferenceColor other = obj as LinkedReferenceColor;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode();
        }

        public static bool operator ==(LinkedReferenceColor objA, LinkedReferenceColor objB)
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

        public static bool operator !=(LinkedReferenceColor objA, LinkedReferenceColor objB)
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