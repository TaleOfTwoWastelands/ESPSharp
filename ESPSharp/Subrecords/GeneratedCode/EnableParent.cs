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
	public partial class EnableParent : Subrecord, ICloneable<EnableParent>, IReferenceContainer
	{
		public FormID Parent { get; set; }
		public EnableParentFlags Flags { get; set; }
		public Byte[] Unknown { get; set; }

		public EnableParent()
		{
			Parent = new FormID();
			Flags = new EnableParentFlags();
			Unknown = new byte[3];
		}

		public EnableParent(FormID Parent, EnableParentFlags Flags, Byte[] Unknown)
		{
			this.Parent = Parent;
			this.Flags = Flags;
			this.Unknown = Unknown;
		}

		public EnableParent(EnableParent copyObject)
		{
			Parent = copyObject.Parent.Clone();
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
					Parent.ReadBinary(subReader);
					Flags = subReader.ReadEnum<EnableParentFlags>();
					Unknown = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Parent.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unknown == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Parent", false, out subEle))
			{
				Parent.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<EnableParentFlags>();
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public EnableParent Clone()
		{
			return new EnableParent(this);
		}

	}
}
