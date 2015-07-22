
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
	public partial class RecordReference : Subrecord, ICloneable, IComparable<RecordReference>, IEquatable<RecordReference>  
	{
		public FormID Reference { get; set; }

		public RecordReference(string Tag = null)
			:base(Tag)
		{
			Reference = new FormID();
		}

		public RecordReference(FormID Reference)
		{
			this.Reference = Reference;
		}

		public RecordReference(RecordReference copyObject)
		{
			if (copyObject.Reference != null)
				Reference = (FormID)copyObject.Reference.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Reference.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Reference.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Reference", true, out subEle);
			Reference.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Reference", false, out subEle))
				Reference.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new RecordReference(this);
		}

        public int CompareTo(RecordReference other)
        {
			int result = 0;

			if (result == 0 && Reference != null && other.Reference != null)	
				result = Reference.CompareTo(other.Reference);

			return result;
		}

        public static bool operator >(RecordReference objA, RecordReference objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RecordReference objA, RecordReference objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RecordReference objA, RecordReference objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RecordReference objA, RecordReference objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(RecordReference other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Reference == other.Reference;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RecordReference other = obj as RecordReference;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        public static bool operator ==(RecordReference objA, RecordReference objB)
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

        public static bool operator !=(RecordReference objA, RecordReference objB)
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