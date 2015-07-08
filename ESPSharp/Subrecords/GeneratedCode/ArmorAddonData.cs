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
	public partial class ArmorAddonData : Subrecord, ICloneable<ArmorAddonData>
	{
		public Int16 ArmorRating { get; set; }
		public NoYesShort ModulatesVoice { get; set; }
		public Byte[] Unknown { get; set; }

		public ArmorAddonData()
		{
			ArmorRating = new Int16();
			ModulatesVoice = new NoYesShort();
			Unknown = new byte[8];
		}

		public ArmorAddonData(Int16 ArmorRating, NoYesShort ModulatesVoice, Byte[] Unknown)
		{
			this.ArmorRating = ArmorRating;
			this.ModulatesVoice = ModulatesVoice;
			this.Unknown = Unknown;
		}

		public ArmorAddonData(ArmorAddonData copyObject)
		{
			ArmorRating = copyObject.ArmorRating;
			ModulatesVoice = copyObject.ModulatesVoice;
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					ArmorRating = subReader.ReadInt16();
					ModulatesVoice = subReader.ReadEnum<NoYesShort>();
					Unknown = subReader.ReadBytes(8);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(ArmorRating);			
			writer.Write((UInt16)ModulatesVoice);
			if (Unknown == null)
				writer.Write(new byte[8]);
			else
				writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("ArmorRating", true, out subEle);
			subEle.Value = ArmorRating.ToString();

			ele.TryPathTo("ModulatesVoice", true, out subEle);
			subEle.Value = ModulatesVoice.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("ArmorRating", false, out subEle))
			{
				ArmorRating = subEle.ToInt16();
			}

			if (ele.TryPathTo("ModulatesVoice", false, out subEle))
			{
				ModulatesVoice = subEle.ToEnum<NoYesShort>();
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public ArmorAddonData Clone()
		{
			return new ArmorAddonData(this);
		}

	}
}
