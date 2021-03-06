﻿
















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
	public partial class EffectData : Subrecord, ICloneable, IComparable<EffectData>, IEquatable<EffectData>  
	{
		public UInt32 Magnitude { get; set; }
		public UInt32 Area { get; set; }
		public UInt32 Duration { get; set; }
		public EffectType Type { get; set; }
		public ActorValues ActorValue { get; set; }


		public EffectData(string Tag = null)
			:base(Tag)
		{
			Magnitude = new UInt32();
			Area = new UInt32();
			Duration = new UInt32();
			Type = new EffectType();
			ActorValue = new ActorValues();

		}

		public EffectData(UInt32 Magnitude, UInt32 Area, UInt32 Duration, EffectType Type, ActorValues ActorValue)
		{
			this.Magnitude = Magnitude;
			this.Area = Area;
			this.Duration = Duration;
			this.Type = Type;
			this.ActorValue = ActorValue;

		}

		public EffectData(EffectData copyObject)
		{
			Magnitude = copyObject.Magnitude;
			Area = copyObject.Area;
			Duration = copyObject.Duration;
			Type = copyObject.Type;
			ActorValue = copyObject.ActorValue;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Magnitude = subReader.ReadUInt32();
					Area = subReader.ReadUInt32();
					Duration = subReader.ReadUInt32();
					Type = subReader.ReadEnum<EffectType>();
					ActorValue = subReader.ReadEnum<ActorValues>();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Magnitude);
			writer.Write(Area);
			writer.Write(Duration);
			writer.Write((UInt32)Type);
			writer.Write((Int32)ActorValue);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Magnitude", true, out subEle);
			subEle.Value = Magnitude.ToString();

			ele.TryPathTo("Area", true, out subEle);
			subEle.Value = Area.ToString();

			ele.TryPathTo("Duration", true, out subEle);
			subEle.Value = Duration.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("ActorValue", true, out subEle);
			subEle.Value = ActorValue.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Magnitude", false, out subEle))
				Magnitude = subEle.ToUInt32();

			if (ele.TryPathTo("Area", false, out subEle))
				Area = subEle.ToUInt32();

			if (ele.TryPathTo("Duration", false, out subEle))
				Duration = subEle.ToUInt32();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<EffectType>();

			if (ele.TryPathTo("ActorValue", false, out subEle))
				ActorValue = subEle.ToEnum<ActorValues>();

		}

		public override object Clone()
		{
			return new EffectData(this);
		}


        public int CompareTo(EffectData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(EffectData objA, EffectData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(EffectData objA, EffectData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(EffectData objA, EffectData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(EffectData objA, EffectData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(EffectData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Magnitude == other.Magnitude &&
				Area == other.Area &&
				Duration == other.Duration &&
				Type == other.Type &&
				ActorValue == other.ActorValue;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            EffectData other = obj as EffectData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Magnitude.GetHashCode();
        }

        public static bool operator ==(EffectData objA, EffectData objB)
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

        public static bool operator !=(EffectData objA, EffectData objB)
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