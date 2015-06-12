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
	public partial class LocalVariableData : Subrecord, ICloneable<LocalVariableData>
	{
		public UInt32 Index { get; set; }
		public Byte[] Unused1 { get; set; }
		public LocalVariableFlag Flags { get; set; }
		public Byte[] Unused2 { get; set; }

		public LocalVariableData()
		{
			Index = new UInt32();
			Unused1 = new byte[12];
			Flags = new LocalVariableFlag();
			Unused2 = new byte[7];
		}

		public LocalVariableData(UInt32 Index, Byte[] Unused1, LocalVariableFlag Flags, Byte[] Unused2)
		{
			this.Index = Index;
			this.Unused1 = Unused1;
			this.Flags = Flags;
			this.Unused2 = Unused2;
		}

		public LocalVariableData(LocalVariableData copyObject)
		{
			Index = copyObject.Index;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			Flags = copyObject.Flags;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Master))
			{
				try
				{
					Index = subReader.ReadUInt32();
					Unused1 = subReader.ReadBytes(12);
					Flags = subReader.ReadEnum<LocalVariableFlag>();
					Unused2 = subReader.ReadBytes(7);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Index);			
			if (Unused1 == null)
				writer.Write(new byte[12]);
			else
				writer.Write(Unused1);
			writer.Write((Byte)Flags);
			if (Unused2 == null)
				writer.Write(new byte[7]);
			else
				writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Index", true, out subEle);
			subEle.Value = Index.ToString();

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Index", false, out subEle))
			{
				Index = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<LocalVariableFlag>();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}
		}

		public LocalVariableData Clone()
		{
			return new LocalVariableData(this);
		}
	}
}
