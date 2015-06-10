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
	public partial class TerminalData : Subrecord, ICloneable<TerminalData>
	{
		public HackingDifficulty HackingDifficulty { get; set; }
		public TerminalFlags Flags { get; set; }
		public TerminalServerType ServerType { get; set; }
		public Byte[] Unused { get; set; }

		public TerminalData()
		{
			HackingDifficulty = new HackingDifficulty();
			Flags = new TerminalFlags();
			ServerType = new TerminalServerType();
			Unused = new byte[1];
		}

		public TerminalData(HackingDifficulty HackingDifficulty, TerminalFlags Flags, TerminalServerType ServerType, Byte[] Unused)
		{
			this.HackingDifficulty = HackingDifficulty;
			this.Flags = Flags;
			this.ServerType = ServerType;
			this.Unused = Unused;
		}

		public TerminalData(TerminalData copyObject)
		{
			HackingDifficulty = copyObject.HackingDifficulty;
			Flags = copyObject.Flags;
			ServerType = copyObject.ServerType;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					HackingDifficulty = subReader.ReadEnum<HackingDifficulty>();
					Flags = subReader.ReadEnum<TerminalFlags>();
					ServerType = subReader.ReadEnum<TerminalServerType>();
					Unused = subReader.ReadBytes(1);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)HackingDifficulty);
			writer.Write((Byte)Flags);
			writer.Write((Byte)ServerType);
			if (Unused == null)
				writer.Write(new byte[1]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("HackingDifficulty", true, out subEle);
			subEle.Value = HackingDifficulty.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("ServerType", true, out subEle);
			subEle.Value = ServerType.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("HackingDifficulty", false, out subEle))
			{
				HackingDifficulty = subEle.ToEnum<HackingDifficulty>();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<TerminalFlags>();
			}

			if (ele.TryPathTo("ServerType", false, out subEle))
			{
				ServerType = subEle.ToEnum<TerminalServerType>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public TerminalData Clone()
		{
			return new TerminalData(this);
		}
	}
}
