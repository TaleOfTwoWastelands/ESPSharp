
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
	public partial class DialogResponseData : Subrecord, ICloneable<DialogResponseData>, IComparable<DialogResponseData>, IEquatable<DialogResponseData>  
	{
		public DialogResponseType Type { get; set; }
		public NextSpeaker NextSpeaker { get; set; }
		public DialogResponseFlags Flags { get; set; }

		public DialogResponseData()
		{
			Type = new DialogResponseType();
			NextSpeaker = new NextSpeaker();
			Flags = new DialogResponseFlags();
		}

		public DialogResponseData(DialogResponseType Type, NextSpeaker NextSpeaker, DialogResponseFlags Flags)
		{
			this.Type = Type;
			this.NextSpeaker = NextSpeaker;
			this.Flags = Flags;
		}

		public DialogResponseData(DialogResponseData copyObject)
		{
			Type = copyObject.Type;
			NextSpeaker = copyObject.NextSpeaker;
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<DialogResponseType>();
					NextSpeaker = subReader.ReadEnum<NextSpeaker>();
					Flags = subReader.ReadEnum<DialogResponseFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Type);
			writer.Write((Byte)NextSpeaker);
			writer.Write((UInt16)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("NextSpeaker", true, out subEle);
			subEle.Value = NextSpeaker.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<DialogResponseType>();

			if (ele.TryPathTo("NextSpeaker", false, out subEle))
				NextSpeaker = subEle.ToEnum<NextSpeaker>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<DialogResponseFlags>();
		}

		public DialogResponseData Clone()
		{
			return new DialogResponseData(this);
		}

        public int CompareTo(DialogResponseData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(DialogResponseData objA, DialogResponseData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DialogResponseData objA, DialogResponseData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DialogResponseData objA, DialogResponseData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DialogResponseData objA, DialogResponseData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DialogResponseData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Type == other.Type &&
				NextSpeaker == other.NextSpeaker &&
				Flags == other.Flags;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DialogResponseData other = obj as DialogResponseData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(DialogResponseData objA, DialogResponseData objB)
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

        public static bool operator !=(DialogResponseData objA, DialogResponseData objB)
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