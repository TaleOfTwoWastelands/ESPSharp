
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
	public partial class RelatedIdleAnims : Subrecord, ICloneable<RelatedIdleAnims>, IComparable<RelatedIdleAnims>, IEquatable<RelatedIdleAnims>  
	{
		public FormID Parent { get; set; }
		public FormID Sibling { get; set; }

		public RelatedIdleAnims()
		{
			Parent = new FormID();
			Sibling = new FormID();
		}

		public RelatedIdleAnims(FormID Parent, FormID Sibling)
		{
			this.Parent = Parent;
			this.Sibling = Sibling;
		}

		public RelatedIdleAnims(RelatedIdleAnims copyObject)
		{
			Parent = copyObject.Parent.Clone();
			Sibling = copyObject.Sibling.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					Sibling.ReadBinary(subReader);
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
			Sibling.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("Sibling", true, out subEle);
			Sibling.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Parent", false, out subEle))
				Parent.ReadXML(subEle, master);

			if (ele.TryPathTo("Sibling", false, out subEle))
				Sibling.ReadXML(subEle, master);
		}

		public RelatedIdleAnims Clone()
		{
			return new RelatedIdleAnims(this);
		}

        public int CompareTo(RelatedIdleAnims other)
        {
			return Parent.CompareTo(other.Parent);
        }

        public static bool operator >(RelatedIdleAnims objA, RelatedIdleAnims objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RelatedIdleAnims objA, RelatedIdleAnims objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RelatedIdleAnims objA, RelatedIdleAnims objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RelatedIdleAnims objA, RelatedIdleAnims objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RelatedIdleAnims other)
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
				Sibling == other.Sibling;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RelatedIdleAnims other = obj as RelatedIdleAnims;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Parent.GetHashCode();
        }

        public static bool operator ==(RelatedIdleAnims objA, RelatedIdleAnims objB)
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

        public static bool operator !=(RelatedIdleAnims objA, RelatedIdleAnims objB)
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