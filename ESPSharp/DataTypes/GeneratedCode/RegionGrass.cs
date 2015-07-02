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

namespace ESPSharp.DataTypes
{
	public partial class RegionGrass : IESPSerializable, ICloneable<RegionGrass>, IReferenceContainer
	{
		public FormID Form { get; set; }
		public Byte[] Unknown { get; set; }

		public RegionGrass()
		{
			Form = new FormID();
			Unknown = new byte[4];
		}

		public RegionGrass(FormID Form, Byte[] Unknown)
		{
			this.Form = Form;
			this.Unknown = Unknown;
		}

		public RegionGrass(RegionGrass copyObject)
		{
			Form = copyObject.Form.Clone();
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Form.ReadBinary(reader);
				Unknown = reader.ReadBytes(4);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Form.WriteBinary(writer);
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unknown);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Form", true, out subEle);
			Form.WriteXML(subEle, master);

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Form", false, out subEle))
			{
				Form.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public RegionGrass Clone()
		{
			return new RegionGrass(this);
		}
	}
}
