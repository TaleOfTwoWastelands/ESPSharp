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
	public partial class EnchantData : Subrecord, ICloneable<EnchantData>
	{
		public EnchantType Type { get; set; }
		public Byte[] Unused1 { get; set; }
		public Byte[] Unused2 { get; set; }
		public EnchantFlags Flags { get; set; }
		public Byte[] Unused3 { get; set; }

		public EnchantData()
		{
			Type = new EnchantType();
			Unused1 = new byte[4];
			Unused2 = new byte[4];
			Flags = new EnchantFlags();
			Unused3 = new byte[3];
		}

		public EnchantData(EnchantType Type, Byte[] Unused1, Byte[] Unused2, EnchantFlags Flags, Byte[] Unused3)
		{
			this.Type = Type;
			this.Unused1 = Unused1;
			this.Unused2 = Unused2;
			this.Flags = Flags;
			this.Unused3 = Unused3;
		}

		public EnchantData(EnchantData copyObject)
		{
			Type = copyObject.Type;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			Unused2 = (Byte[])copyObject.Unused2.Clone();
			Flags = copyObject.Flags;
			Unused3 = (Byte[])copyObject.Unused3.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<EnchantType>();
					Unused1 = subReader.ReadBytes(4);
					Unused2 = subReader.ReadBytes(4);
					Flags = subReader.ReadEnum<EnchantFlags>();
					Unused3 = subReader.ReadBytes(3);
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
			if (Unused1 == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused1);
			if (Unused2 == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused2);
			writer.Write((Byte)Flags);
			if (Unused3 == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused3);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Unused/Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("Unused/Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused/Unused3", true, out subEle);
			subEle.Value = Unused3.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<EnchantType>();
			}

			if (ele.TryPathTo("Unused/Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Unused/Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<EnchantFlags>();
			}

			if (ele.TryPathTo("Unused/Unused3", false, out subEle))
			{
				Unused3 = subEle.ToBytes();
			}
		}

		public EnchantData Clone()
		{
			return new EnchantData(this);
		}

	}
}
