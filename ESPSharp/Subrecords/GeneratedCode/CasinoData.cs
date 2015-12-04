
















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
	public partial class CasinoData : Subrecord, ICloneable, IComparable<CasinoData>, IEquatable<CasinoData>  
	{
		public Single DecksPercentBeforeShuffle { get; set; }
		public Single BlackjackPayoutRatio { get; set; }
		public UInt32 SlotReelStop1 { get; set; }
		public UInt32 SlotReelStop2 { get; set; }
		public UInt32 SlotReelStop3 { get; set; }
		public UInt32 SlotReelStop4 { get; set; }
		public UInt32 SlotReelStop5 { get; set; }
		public UInt32 SlotReelStop6 { get; set; }
		public UInt32 SlotReelStopW { get; set; }
		public UInt32 NumberOfDecks { get; set; }
		public UInt32 MaxWinnings { get; set; }
		public FormID Currency { get; set; }
		public FormID WinningsQuest { get; set; }
		public NoYes DealerStayOnSoft17 { get; set; }


		public CasinoData(string Tag = null)
			:base(Tag)
		{
			DecksPercentBeforeShuffle = new Single();
			BlackjackPayoutRatio = new Single();
			SlotReelStop1 = new UInt32();
			SlotReelStop2 = new UInt32();
			SlotReelStop3 = new UInt32();
			SlotReelStop4 = new UInt32();
			SlotReelStop5 = new UInt32();
			SlotReelStop6 = new UInt32();
			SlotReelStopW = new UInt32();
			NumberOfDecks = new UInt32();
			MaxWinnings = new UInt32();
			Currency = new FormID();
			WinningsQuest = new FormID();
			DealerStayOnSoft17 = new NoYes();

		}

		public CasinoData(Single DecksPercentBeforeShuffle, Single BlackjackPayoutRatio, UInt32 SlotReelStop1, UInt32 SlotReelStop2, UInt32 SlotReelStop3, UInt32 SlotReelStop4, UInt32 SlotReelStop5, UInt32 SlotReelStop6, UInt32 SlotReelStopW, UInt32 NumberOfDecks, UInt32 MaxWinnings, FormID Currency, FormID WinningsQuest, NoYes DealerStayOnSoft17)
		{
			this.DecksPercentBeforeShuffle = DecksPercentBeforeShuffle;
			this.BlackjackPayoutRatio = BlackjackPayoutRatio;
			this.SlotReelStop1 = SlotReelStop1;
			this.SlotReelStop2 = SlotReelStop2;
			this.SlotReelStop3 = SlotReelStop3;
			this.SlotReelStop4 = SlotReelStop4;
			this.SlotReelStop5 = SlotReelStop5;
			this.SlotReelStop6 = SlotReelStop6;
			this.SlotReelStopW = SlotReelStopW;
			this.NumberOfDecks = NumberOfDecks;
			this.MaxWinnings = MaxWinnings;
			this.Currency = Currency;
			this.WinningsQuest = WinningsQuest;
			this.DealerStayOnSoft17 = DealerStayOnSoft17;

		}

		public CasinoData(CasinoData copyObject)
		{
			DecksPercentBeforeShuffle = copyObject.DecksPercentBeforeShuffle;
			BlackjackPayoutRatio = copyObject.BlackjackPayoutRatio;
			SlotReelStop1 = copyObject.SlotReelStop1;
			SlotReelStop2 = copyObject.SlotReelStop2;
			SlotReelStop3 = copyObject.SlotReelStop3;
			SlotReelStop4 = copyObject.SlotReelStop4;
			SlotReelStop5 = copyObject.SlotReelStop5;
			SlotReelStop6 = copyObject.SlotReelStop6;
			SlotReelStopW = copyObject.SlotReelStopW;
			NumberOfDecks = copyObject.NumberOfDecks;
			MaxWinnings = copyObject.MaxWinnings;
			if (copyObject.Currency != null)
				Currency = (FormID)copyObject.Currency.Clone();
			if (copyObject.WinningsQuest != null)
				WinningsQuest = (FormID)copyObject.WinningsQuest.Clone();
			DealerStayOnSoft17 = copyObject.DealerStayOnSoft17;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					DecksPercentBeforeShuffle = subReader.ReadSingle();
					BlackjackPayoutRatio = subReader.ReadSingle();
					SlotReelStop1 = subReader.ReadUInt32();
					SlotReelStop2 = subReader.ReadUInt32();
					SlotReelStop3 = subReader.ReadUInt32();
					SlotReelStop4 = subReader.ReadUInt32();
					SlotReelStop5 = subReader.ReadUInt32();
					SlotReelStop6 = subReader.ReadUInt32();
					SlotReelStopW = subReader.ReadUInt32();
					NumberOfDecks = subReader.ReadUInt32();
					MaxWinnings = subReader.ReadUInt32();
					Currency.ReadBinary(subReader);
					WinningsQuest.ReadBinary(subReader);
					DealerStayOnSoft17 = subReader.ReadEnum<NoYes>();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DecksPercentBeforeShuffle);
			writer.Write(BlackjackPayoutRatio);
			writer.Write(SlotReelStop1);
			writer.Write(SlotReelStop2);
			writer.Write(SlotReelStop3);
			writer.Write(SlotReelStop4);
			writer.Write(SlotReelStop5);
			writer.Write(SlotReelStop6);
			writer.Write(SlotReelStopW);
			writer.Write(NumberOfDecks);
			writer.Write(MaxWinnings);
			Currency.WriteBinary(writer);
			WinningsQuest.WriteBinary(writer);
			writer.Write((UInt32)DealerStayOnSoft17);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("DecksPercentBeforeShuffle", true, out subEle);
			subEle.Value = DecksPercentBeforeShuffle.ToString("G15");

			ele.TryPathTo("BlackjackPayoutRatio", true, out subEle);
			subEle.Value = BlackjackPayoutRatio.ToString("G15");

			ele.TryPathTo("SlotReelStop/Symbol1", true, out subEle);
			subEle.Value = SlotReelStop1.ToString();

			ele.TryPathTo("SlotReelStop/Symbol2", true, out subEle);
			subEle.Value = SlotReelStop2.ToString();

			ele.TryPathTo("SlotReelStop/Symbol3", true, out subEle);
			subEle.Value = SlotReelStop3.ToString();

			ele.TryPathTo("SlotReelStop/Symbol4", true, out subEle);
			subEle.Value = SlotReelStop4.ToString();

			ele.TryPathTo("SlotReelStop/Symbol5", true, out subEle);
			subEle.Value = SlotReelStop5.ToString();

			ele.TryPathTo("SlotReelStop/Symbol6", true, out subEle);
			subEle.Value = SlotReelStop6.ToString();

			ele.TryPathTo("SlotReelStop/SymbolW", true, out subEle);
			subEle.Value = SlotReelStopW.ToString();

			ele.TryPathTo("NumberOfDecks", true, out subEle);
			subEle.Value = NumberOfDecks.ToString();

			ele.TryPathTo("MaxWinnings", true, out subEle);
			subEle.Value = MaxWinnings.ToString();

			ele.TryPathTo("Currency", true, out subEle);
			Currency.WriteXML(subEle, master);

			ele.TryPathTo("WinningsQuest", true, out subEle);
			WinningsQuest.WriteXML(subEle, master);

			ele.TryPathTo("DealerStayOnSoft17", true, out subEle);
			subEle.Value = DealerStayOnSoft17.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("DecksPercentBeforeShuffle", false, out subEle))
				DecksPercentBeforeShuffle = subEle.ToSingle();

			if (ele.TryPathTo("BlackjackPayoutRatio", false, out subEle))
				BlackjackPayoutRatio = subEle.ToSingle();

			if (ele.TryPathTo("SlotReelStop/Symbol1", false, out subEle))
				SlotReelStop1 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/Symbol2", false, out subEle))
				SlotReelStop2 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/Symbol3", false, out subEle))
				SlotReelStop3 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/Symbol4", false, out subEle))
				SlotReelStop4 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/Symbol5", false, out subEle))
				SlotReelStop5 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/Symbol6", false, out subEle))
				SlotReelStop6 = subEle.ToUInt32();

			if (ele.TryPathTo("SlotReelStop/SymbolW", false, out subEle))
				SlotReelStopW = subEle.ToUInt32();

			if (ele.TryPathTo("NumberOfDecks", false, out subEle))
				NumberOfDecks = subEle.ToUInt32();

			if (ele.TryPathTo("MaxWinnings", false, out subEle))
				MaxWinnings = subEle.ToUInt32();

			if (ele.TryPathTo("Currency", false, out subEle))
				Currency.ReadXML(subEle, master);

			if (ele.TryPathTo("WinningsQuest", false, out subEle))
				WinningsQuest.ReadXML(subEle, master);

			if (ele.TryPathTo("DealerStayOnSoft17", false, out subEle))
				DealerStayOnSoft17 = subEle.ToEnum<NoYes>();

		}

		public override object Clone()
		{
			return new CasinoData(this);
		}


        public int CompareTo(CasinoData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(CasinoData objA, CasinoData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CasinoData objA, CasinoData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CasinoData objA, CasinoData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CasinoData objA, CasinoData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(CasinoData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return DecksPercentBeforeShuffle == other.DecksPercentBeforeShuffle &&
				BlackjackPayoutRatio == other.BlackjackPayoutRatio &&
				SlotReelStop1 == other.SlotReelStop1 &&
				SlotReelStop2 == other.SlotReelStop2 &&
				SlotReelStop3 == other.SlotReelStop3 &&
				SlotReelStop4 == other.SlotReelStop4 &&
				SlotReelStop5 == other.SlotReelStop5 &&
				SlotReelStop6 == other.SlotReelStop6 &&
				SlotReelStopW == other.SlotReelStopW &&
				NumberOfDecks == other.NumberOfDecks &&
				MaxWinnings == other.MaxWinnings &&
				Currency == other.Currency &&
				WinningsQuest == other.WinningsQuest &&
				DealerStayOnSoft17 == other.DealerStayOnSoft17;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CasinoData other = obj as CasinoData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return WinningsQuest.GetHashCode();
        }

        public static bool operator ==(CasinoData objA, CasinoData objB)
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

        public static bool operator !=(CasinoData objA, CasinoData objB)
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