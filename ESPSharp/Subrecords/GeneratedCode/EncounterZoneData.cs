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
	public partial class EncounterZoneData : Subrecord, ICloneable<EncounterZoneData>, IReferenceContainer
	{
		public FormID Owner { get; set; }
		public Byte OwnerRank { get; set; }
		public Byte MinimumLevel { get; set; }
		public EncounterZoneFlags Flags { get; set; }
		public Byte Unused { get; set; }

		public EncounterZoneData()
		{
			Owner = new FormID();
			OwnerRank = new Byte();
			MinimumLevel = new Byte();
			Flags = new EncounterZoneFlags();
			Unused = new Byte();
		}

		public EncounterZoneData(FormID Owner, Byte OwnerRank, Byte MinimumLevel, EncounterZoneFlags Flags, Byte Unused)
		{
			this.Owner = Owner;
			this.OwnerRank = OwnerRank;
			this.MinimumLevel = MinimumLevel;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public EncounterZoneData(EncounterZoneData copyObject)
		{
			Owner = copyObject.Owner.Clone();
			OwnerRank = copyObject.OwnerRank;
			MinimumLevel = copyObject.MinimumLevel;
			Flags = copyObject.Flags;
			Unused = copyObject.Unused;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Owner.ReadBinary(subReader);
					OwnerRank = subReader.ReadByte();
					MinimumLevel = subReader.ReadByte();
					Flags = subReader.ReadEnum<EncounterZoneFlags>();
					Unused = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Owner.WriteBinary(writer);
			writer.Write(OwnerRank);			
			writer.Write(MinimumLevel);			
			writer.Write((Byte)Flags);
			writer.Write(Unused);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Ownership/Owner", true, out subEle);
			Owner.WriteXML(subEle, master);

			ele.TryPathTo("Ownership/Rank", true, out subEle);
			subEle.Value = OwnerRank.ToString();

			ele.TryPathTo("MinimumLevel", true, out subEle);
			subEle.Value = MinimumLevel.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Ownership/Owner", false, out subEle))
			{
				Owner.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Ownership/Rank", false, out subEle))
			{
				OwnerRank = subEle.ToByte();
			}

			if (ele.TryPathTo("MinimumLevel", false, out subEle))
			{
				MinimumLevel = subEle.ToByte();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<EncounterZoneFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToByte();
			}
		}

		public EncounterZoneData Clone()
		{
			return new EncounterZoneData(this);
		}

	}
}
