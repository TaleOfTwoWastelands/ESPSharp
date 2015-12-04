
















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
	public partial class ThresholdData : Subrecord, ICloneable, IComparable<ThresholdData>, IEquatable<ThresholdData>  
	{
		public UInt32 TriggerThreshold { get; set; }
		public FormID Effect { get; set; }


		public ThresholdData(string Tag = null)
			:base(Tag)
		{
			TriggerThreshold = new UInt32();
			Effect = new FormID();

		}

		public ThresholdData(UInt32 TriggerThreshold, FormID Effect)
		{
			this.TriggerThreshold = TriggerThreshold;
			this.Effect = Effect;

		}

		public ThresholdData(ThresholdData copyObject)
		{
			TriggerThreshold = copyObject.TriggerThreshold;
			if (copyObject.Effect != null)
				Effect = (FormID)copyObject.Effect.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					TriggerThreshold = subReader.ReadUInt32();
					Effect.ReadBinary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(TriggerThreshold);
			Effect.WriteBinary(writer);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("TriggerThreshold", true, out subEle);
			subEle.Value = TriggerThreshold.ToString();

			ele.TryPathTo("Effect", true, out subEle);
			Effect.WriteXML(subEle, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("TriggerThreshold", false, out subEle))
				TriggerThreshold = subEle.ToUInt32();

			if (ele.TryPathTo("Effect", false, out subEle))
				Effect.ReadXML(subEle, master);

		}

		public override object Clone()
		{
			return new ThresholdData(this);
		}


        public int CompareTo(ThresholdData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(ThresholdData objA, ThresholdData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ThresholdData objA, ThresholdData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ThresholdData objA, ThresholdData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ThresholdData objA, ThresholdData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(ThresholdData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return TriggerThreshold == other.TriggerThreshold &&
				Effect == other.Effect;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ThresholdData other = obj as ThresholdData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return TriggerThreshold.GetHashCode();
        }

        public static bool operator ==(ThresholdData objA, ThresholdData objB)
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

        public static bool operator !=(ThresholdData objA, ThresholdData objB)
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