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
	public partial class FactionMembership : Subrecord, ICloneable<FactionMembership>, IReferenceContainer
	{
		public FormID Faction { get; set; }
		public Byte Rank { get; set; }
		public Byte[] Unused { get; set; }

		public FactionMembership()
		{
			Faction = new FormID();
			Rank = new Byte();
			Unused = new byte[3];
		}

		public FactionMembership(FormID Faction, Byte Rank, Byte[] Unused)
		{
			this.Faction = Faction;
			this.Rank = Rank;
			this.Unused = Unused;
		}

		public FactionMembership(FactionMembership copyObject)
		{
			Faction = copyObject.Faction.Clone();
			Rank = copyObject.Rank;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Faction.ReadBinary(subReader);
					Rank = subReader.ReadByte();
					Unused = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Faction.WriteBinary(writer);
			writer.Write(Rank);			
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Faction", true, out subEle);
			Faction.WriteXML(subEle, master);

			ele.TryPathTo("Rank", true, out subEle);
			subEle.Value = Rank.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Faction", false, out subEle))
			{
				Faction.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Rank", false, out subEle))
			{
				Rank = subEle.ToByte();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public FactionMembership Clone()
		{
			return new FactionMembership(this);
		}

	}
}
