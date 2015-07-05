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
	public partial class PackageDialogData : Subrecord, ICloneable<PackageDialogData>, IReferenceContainer
	{
		public Single FOV { get; set; }
		public FormID Topic { get; set; }
		public PackageDialogFlags Flags { get; set; }
		public Byte[] Unused { get; set; }
		public PackageDialogType Type { get; set; }

		public PackageDialogData()
		{
			FOV = new Single();
			Topic = new FormID();
			Flags = new PackageDialogFlags();
			Unused = new byte[4];
			Type = new PackageDialogType();
		}

		public PackageDialogData(Single FOV, FormID Topic, PackageDialogFlags Flags, Byte[] Unused, PackageDialogType Type)
		{
			this.FOV = FOV;
			this.Topic = Topic;
			this.Flags = Flags;
			this.Unused = Unused;
			this.Type = Type;
		}

		public PackageDialogData(PackageDialogData copyObject)
		{
			FOV = copyObject.FOV;
			Topic = copyObject.Topic.Clone();
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
			Type = copyObject.Type;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					FOV = subReader.ReadSingle();
					Topic.ReadBinary(subReader);
					Flags = subReader.ReadEnum<PackageDialogFlags>();
					Unused = subReader.ReadBytes(4);
					Type = subReader.ReadEnum<PackageDialogType>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(FOV);			
			Topic.WriteBinary(writer);
			writer.Write((UInt32)Flags);
			if (Unused == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused);
			writer.Write((UInt32)Type);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("FOV", true, out subEle);
			subEle.Value = FOV.ToString();

			ele.TryPathTo("Topic", true, out subEle);
			Topic.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("FOV", false, out subEle))
			{
				FOV = subEle.ToSingle();
			}

			if (ele.TryPathTo("Topic", false, out subEle))
			{
				Topic.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<PackageDialogFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<PackageDialogType>();
			}
		}

		public PackageDialogData Clone()
		{
			return new PackageDialogData(this);
		}

	}
}
