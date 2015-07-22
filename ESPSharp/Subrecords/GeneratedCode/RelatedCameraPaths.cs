
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
	public partial class RelatedCameraPaths : Subrecord, ICloneable, IComparable<RelatedCameraPaths>, IEquatable<RelatedCameraPaths>  
	{
		public FormID Parent { get; set; }
		public FormID PreviousSibling { get; set; }

		public RelatedCameraPaths(string Tag = null)
			:base(Tag)
		{
			Parent = new FormID();
			PreviousSibling = new FormID();
		}

		public RelatedCameraPaths(FormID Parent, FormID PreviousSibling)
		{
			this.Parent = Parent;
			this.PreviousSibling = PreviousSibling;
		}

		public RelatedCameraPaths(RelatedCameraPaths copyObject)
		{
			if (copyObject.Parent != null)
				Parent = (FormID)copyObject.Parent.Clone();
			if (copyObject.PreviousSibling != null)
				PreviousSibling = (FormID)copyObject.PreviousSibling.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					PreviousSibling.ReadBinary(subReader);
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
			PreviousSibling.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("PreviousSibling", true, out subEle);
			PreviousSibling.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Parent", false, out subEle))
				Parent.ReadXML(subEle, master);

			if (ele.TryPathTo("PreviousSibling", false, out subEle))
				PreviousSibling.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new RelatedCameraPaths(this);
		}

        public int CompareTo(RelatedCameraPaths other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(RelatedCameraPaths objA, RelatedCameraPaths objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RelatedCameraPaths objA, RelatedCameraPaths objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RelatedCameraPaths objA, RelatedCameraPaths objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RelatedCameraPaths objA, RelatedCameraPaths objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RelatedCameraPaths other)
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
				PreviousSibling == other.PreviousSibling;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RelatedCameraPaths other = obj as RelatedCameraPaths;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Parent.GetHashCode();
        }

        public static bool operator ==(RelatedCameraPaths objA, RelatedCameraPaths objB)
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

        public static bool operator !=(RelatedCameraPaths objA, RelatedCameraPaths objB)
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