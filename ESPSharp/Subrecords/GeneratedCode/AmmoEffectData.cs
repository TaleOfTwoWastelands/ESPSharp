
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
	public partial class AmmoEffectData : Subrecord, ICloneable<AmmoEffectData>, IComparable<AmmoEffectData>, IEquatable<AmmoEffectData>  
	{
		public AmmoEffectType Type { get; set; }
		public AmmoEffectOperation Operation { get; set; }
		public Single Value { get; set; }

		public AmmoEffectData()
		{
			Type = new AmmoEffectType();
			Operation = new AmmoEffectOperation();
			Value = new Single();
		}

		public AmmoEffectData(AmmoEffectType Type, AmmoEffectOperation Operation, Single Value)
		{
			this.Type = Type;
			this.Operation = Operation;
			this.Value = Value;
		}

		public AmmoEffectData(AmmoEffectData copyObject)
		{
			Type = copyObject.Type;
			Operation = copyObject.Operation;
			Value = copyObject.Value;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<AmmoEffectType>();
					Operation = subReader.ReadEnum<AmmoEffectOperation>();
					Value = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Type);
			writer.Write((UInt32)Operation);
			writer.Write(Value);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Operation", true, out subEle);
			subEle.Value = Operation.ToString();

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<AmmoEffectType>();

			if (ele.TryPathTo("Operation", false, out subEle))
				Operation = subEle.ToEnum<AmmoEffectOperation>();

			if (ele.TryPathTo("Value", false, out subEle))
				Value = subEle.ToSingle();
		}

		public AmmoEffectData Clone()
		{
			return new AmmoEffectData(this);
		}

        public int CompareTo(AmmoEffectData other)
        {
			return Type.CompareTo(other.Type);
        }

        public static bool operator >(AmmoEffectData objA, AmmoEffectData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AmmoEffectData objA, AmmoEffectData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AmmoEffectData objA, AmmoEffectData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AmmoEffectData objA, AmmoEffectData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(AmmoEffectData other)
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
				Operation == other.Operation &&
				Value == other.Value;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AmmoEffectData other = obj as AmmoEffectData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(AmmoEffectData objA, AmmoEffectData objB)
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

        public static bool operator !=(AmmoEffectData objA, AmmoEffectData objB)
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