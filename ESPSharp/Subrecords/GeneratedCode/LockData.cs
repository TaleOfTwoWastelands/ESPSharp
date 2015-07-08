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
	public partial class LockData : Subrecord, ICloneable<LockData>, IReferenceContainer
	{
		public Byte Level { get; set; }
		public Byte[] Unused { get; set; }
		public FormID Key { get; set; }
		public LockFlags Flags { get; set; }
		public Byte[] Unknown { get; set; }

		public LockData()
		{
			Level = new Byte();
			Unused = new byte[3];
			Key = new FormID();
			Flags = new LockFlags();
			Unknown = new byte[11];
		}

		public LockData(Byte Level, Byte[] Unused, FormID Key, LockFlags Flags, Byte[] Unknown)
		{
			this.Level = Level;
			this.Unused = Unused;
			this.Key = Key;
			this.Flags = Flags;
			this.Unknown = Unknown;
		}

		public LockData(LockData copyObject)
		{
			Level = copyObject.Level;
			Unused = (Byte[])copyObject.Unused.Clone();
			Key = copyObject.Key.Clone();
			Flags = copyObject.Flags;
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Level = subReader.ReadByte();
					Unused = subReader.ReadBytes(3);
					Key.ReadBinary(subReader);
					Flags = subReader.ReadEnum<LockFlags>();
					Unknown = subReader.ReadBytes(11);
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
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
			Key.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unknown == null)
				writer.Write(new byte[11]);
			else
				writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Level", true, out subEle);
			subEle.Value = Level.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("Key", true, out subEle);
			Key.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Level", false, out subEle))
			{
				Level = subEle.ToByte();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("Key", false, out subEle))
			{
				Key.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<LockFlags>();
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public LockData Clone()
		{
			return new LockData(this);
		}

	}
}
