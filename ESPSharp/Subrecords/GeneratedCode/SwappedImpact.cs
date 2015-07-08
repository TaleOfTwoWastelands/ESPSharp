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
	public partial class SwappedImpact : Subrecord, ICloneable<SwappedImpact>, IReferenceContainer
	{
		public MaterialTypeUInt MaterialType { get; set; }
		public FormID OldImpact { get; set; }
		public FormID NewImpact { get; set; }

		public SwappedImpact()
		{
			MaterialType = new MaterialTypeUInt();
			OldImpact = new FormID();
			NewImpact = new FormID();
		}

		public SwappedImpact(MaterialTypeUInt MaterialType, FormID OldImpact, FormID NewImpact)
		{
			this.MaterialType = MaterialType;
			this.OldImpact = OldImpact;
			this.NewImpact = NewImpact;
		}

		public SwappedImpact(SwappedImpact copyObject)
		{
			MaterialType = copyObject.MaterialType;
			OldImpact = copyObject.OldImpact.Clone();
			NewImpact = copyObject.NewImpact.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					MaterialType = subReader.ReadEnum<MaterialTypeUInt>();
					OldImpact.ReadBinary(subReader);
					NewImpact.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)MaterialType);
			OldImpact.WriteBinary(writer);
			NewImpact.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("MaterialType", true, out subEle);
			subEle.Value = MaterialType.ToString();

			ele.TryPathTo("OldImpact", true, out subEle);
			OldImpact.WriteXML(subEle, master);

			ele.TryPathTo("NewImpact", true, out subEle);
			NewImpact.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("MaterialType", false, out subEle))
			{
				MaterialType = subEle.ToEnum<MaterialTypeUInt>();
			}

			if (ele.TryPathTo("OldImpact", false, out subEle))
			{
				OldImpact.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("NewImpact", false, out subEle))
			{
				NewImpact.ReadXML(subEle, master);
			}
		}

		public SwappedImpact Clone()
		{
			return new SwappedImpact(this);
		}

	}
}
