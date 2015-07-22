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

namespace ESPSharp.DataTypes
{
	public partial class FormID : IESPSerializable, ICloneable, IComparable<FormID>, IEquatable<FormID>  
	{
		public UInt32 RawValue { get; protected set; }

		public FormID()
		{
			RawValue = new UInt32();
		}

		public FormID(UInt32 RawValue)
		{
			this.RawValue = RawValue;
		}

		public FormID(FormID copyObject)
		{
			RawValue = copyObject.RawValue;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				RawValue = reader.ReadUInt32();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(RawValue);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			WriteRawValueXML(ele, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ReadRawValueXML(ele, master);
		}

		public object Clone()
		{
			return new FormID(this);
		}

        public int CompareTo(FormID other)
        {
			int result = 0;

			if (result == 0 && RawValue != null && other.RawValue != null)	
				result = RawValue.CompareTo(other.RawValue);

			return result;
		}

        public static bool operator >(FormID objA, FormID objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(FormID objA, FormID objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(FormID objA, FormID objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(FormID objA, FormID objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(FormID other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return RawValue == other.RawValue;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            FormID other = obj as FormID;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return RawValue.GetHashCode();
        }

        public static bool operator ==(FormID objA, FormID objB)
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

        public static bool operator !=(FormID objA, FormID objB)
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

		partial void ReadRawValueXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteRawValueXML(XElement ele, ElderScrollsPlugin master);
	}
}