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
	public partial class LeveledObjectData : Subrecord, ICloneable<LeveledObjectData>, IReferenceContainer
	{
		public Int16 Level { get; set; }
		public Byte[] Unused1 { get; set; }
		public FormID Reference { get; set; }
		public Int16 Count { get; set; }
		public Byte[] Unused2 { get; set; }

		public LeveledObjectData()
		{
			Level = new Int16();
			Unused1 = new byte[2];
			Reference = new FormID();
			Count = new Int16();
			Unused2 = new byte[2];
		}

		public LeveledObjectData(Int16 Level, Byte[] Unused1, FormID Reference, Int16 Count, Byte[] Unused2)
		{
			this.Level = Level;
			this.Unused1 = Unused1;
			this.Reference = Reference;
			this.Count = Count;
			this.Unused2 = Unused2;
		}

		public LeveledObjectData(LeveledObjectData copyObject)
		{
			Level = copyObject.Level;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			Reference = copyObject.Reference.Clone();
			Count = copyObject.Count;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Level = subReader.ReadInt16();
					Unused1 = subReader.ReadBytes(2);
					Reference.ReadBinary(subReader);
					Count = subReader.ReadInt16();
					Unused2 = subReader.ReadBytes(2);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Level);			
			if (Unused1 == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused1);
			Reference.WriteBinary(writer);
			writer.Write(Count);			
			if (Unused2 == null)
				writer.Write(new byte[2]);
			else
				writer.Write(Unused2);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("Reference", true, out subEle);
			Reference.WriteXML(subEle, master);

			ele.TryPathTo("Count", true, out subEle);
			subEle.Value = Count.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Level", false, out subEle))
			{
				Level = subEle.ToInt16();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Reference", false, out subEle))
			{
				Reference.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Count", false, out subEle))
			{
				Count = subEle.ToInt16();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}
		}

		public LeveledObjectData Clone()
		{
			return new LeveledObjectData(this);
		}

	}
}
