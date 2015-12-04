
















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
	public partial class IngestibleData : Subrecord, ICloneable, IComparable<IngestibleData>, IEquatable<IngestibleData>  
	{
		public Int32 Value { get; set; }
		public IngestibleFlags Flags { get; set; }
		public Byte[] Unused { get; set; }
		public FormID WithdrawalEffect { get; set; }
		public Single AddictionChance { get; set; }
		public FormID SoundConsume { get; set; }


		public IngestibleData(string Tag = null)
			:base(Tag)
		{
			Value = new Int32();
			Flags = new IngestibleFlags();
			Unused = new byte[3];
			WithdrawalEffect = new FormID();
			AddictionChance = new Single();
			SoundConsume = new FormID();

		}

		public IngestibleData(Int32 Value, IngestibleFlags Flags, Byte[] Unused, FormID WithdrawalEffect, Single AddictionChance, FormID SoundConsume)
		{
			this.Value = Value;
			this.Flags = Flags;
			this.Unused = Unused;
			this.WithdrawalEffect = WithdrawalEffect;
			this.AddictionChance = AddictionChance;
			this.SoundConsume = SoundConsume;

		}

		public IngestibleData(IngestibleData copyObject)
		{
			Value = copyObject.Value;
			Flags = copyObject.Flags;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			if (copyObject.WithdrawalEffect != null)
				WithdrawalEffect = (FormID)copyObject.WithdrawalEffect.Clone();
			AddictionChance = copyObject.AddictionChance;
			if (copyObject.SoundConsume != null)
				SoundConsume = (FormID)copyObject.SoundConsume.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Value = subReader.ReadInt32();
					Flags = subReader.ReadEnum<IngestibleFlags>();
					Unused = subReader.ReadBytes(3);
					WithdrawalEffect.ReadBinary(subReader);
					AddictionChance = subReader.ReadSingle();
					SoundConsume.ReadBinary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Value);
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);
			WithdrawalEffect.WriteBinary(writer);
			writer.Write(AddictionChance);
			SoundConsume.WriteBinary(writer);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("WithdrawalEffect", true, out subEle);
			WithdrawalEffect.WriteXML(subEle, master);

			ele.TryPathTo("AddictionChance", true, out subEle);
			subEle.Value = AddictionChance.ToString("G15");

			ele.TryPathTo("ConsumeSound", true, out subEle);
			SoundConsume.WriteXML(subEle, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Value", false, out subEle))
				Value = subEle.ToInt32();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<IngestibleFlags>();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("WithdrawalEffect", false, out subEle))
				WithdrawalEffect.ReadXML(subEle, master);

			if (ele.TryPathTo("AddictionChance", false, out subEle))
				AddictionChance = subEle.ToSingle();

			if (ele.TryPathTo("ConsumeSound", false, out subEle))
				SoundConsume.ReadXML(subEle, master);

		}

		public override object Clone()
		{
			return new IngestibleData(this);
		}


        public int CompareTo(IngestibleData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(IngestibleData objA, IngestibleData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(IngestibleData objA, IngestibleData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(IngestibleData objA, IngestibleData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(IngestibleData objA, IngestibleData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(IngestibleData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Value == other.Value &&
				Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused) &&
				WithdrawalEffect == other.WithdrawalEffect &&
				AddictionChance == other.AddictionChance &&
				SoundConsume == other.SoundConsume;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            IngestibleData other = obj as IngestibleData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return WithdrawalEffect.GetHashCode();
        }

        public static bool operator ==(IngestibleData objA, IngestibleData objB)
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

        public static bool operator !=(IngestibleData objA, IngestibleData objB)
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





		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);



		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);

	}
}