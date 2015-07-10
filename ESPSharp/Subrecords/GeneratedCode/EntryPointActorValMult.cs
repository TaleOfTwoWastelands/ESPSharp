
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
	public partial class EntryPointActorValMult : Subrecord, ICloneable<EntryPointActorValMult>, IComparable<EntryPointActorValMult>, IEquatable<EntryPointActorValMult>  
	{
		public ActorValues ActorValue { get; set; }
		public Single Multiplier { get; set; }

		public EntryPointActorValMult()
		{
			ActorValue = new ActorValues();
			Multiplier = new Single();
		}

		public EntryPointActorValMult(ActorValues ActorValue, Single Multiplier)
		{
			this.ActorValue = ActorValue;
			this.Multiplier = Multiplier;
		}

		public EntryPointActorValMult(EntryPointActorValMult copyObject)
		{
			ActorValue = copyObject.ActorValue;
			Multiplier = copyObject.Multiplier;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					ActorValue = subReader.ReadEnum<ActorValues>();
					Multiplier = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Int32)ActorValue);
			writer.Write(Multiplier);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("ActorValue", true, out subEle);
			subEle.Value = ActorValue.ToString();

			ele.TryPathTo("Multiplier", true, out subEle);
			subEle.Value = Multiplier.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ActorValue", false, out subEle))
				ActorValue = subEle.ToEnum<ActorValues>();

			if (ele.TryPathTo("Multiplier", false, out subEle))
				Multiplier = subEle.ToSingle();
		}

		public EntryPointActorValMult Clone()
		{
			return new EntryPointActorValMult(this);
		}

        public int CompareTo(EntryPointActorValMult other)
        {
			return ActorValue.CompareTo(other.ActorValue);
        }

        public static bool operator >(EntryPointActorValMult objA, EntryPointActorValMult objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EntryPointActorValMult objA, EntryPointActorValMult objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EntryPointActorValMult objA, EntryPointActorValMult objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EntryPointActorValMult objA, EntryPointActorValMult objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(EntryPointActorValMult other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ActorValue == other.ActorValue &&
				Multiplier == other.Multiplier;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EntryPointActorValMult other = obj as EntryPointActorValMult;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ActorValue.GetHashCode();
        }

        public static bool operator ==(EntryPointActorValMult objA, EntryPointActorValMult objB)
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

        public static bool operator !=(EntryPointActorValMult objA, EntryPointActorValMult objB)
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