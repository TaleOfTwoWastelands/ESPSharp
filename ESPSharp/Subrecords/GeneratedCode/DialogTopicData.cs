
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
	public partial class DialogTopicData : Subrecord, ICloneable<DialogTopicData>, IComparable<DialogTopicData>, IEquatable<DialogTopicData>  
	{
		public DialogType Type { get; set; }
		public DialogFlags Flags { get; set; }

		public DialogTopicData()
		{
			Type = new DialogType();
			Flags = new DialogFlags();
		}

		public DialogTopicData(DialogType Type, DialogFlags Flags)
		{
			this.Type = Type;
			this.Flags = Flags;
		}

		public DialogTopicData(DialogTopicData copyObject)
		{
			Type = copyObject.Type;
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<DialogType>();
					Flags = subReader.ReadEnum<DialogFlags>();
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
			writer.Write((Byte)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<DialogType>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<DialogFlags>();
		}

		public DialogTopicData Clone()
		{
			return new DialogTopicData(this);
		}

        public int CompareTo(DialogTopicData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(DialogTopicData objA, DialogTopicData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(DialogTopicData objA, DialogTopicData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(DialogTopicData objA, DialogTopicData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(DialogTopicData objA, DialogTopicData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(DialogTopicData other)
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
				Flags == other.Flags;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            DialogTopicData other = obj as DialogTopicData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(DialogTopicData objA, DialogTopicData objB)
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

        public static bool operator !=(DialogTopicData objA, DialogTopicData objB)
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