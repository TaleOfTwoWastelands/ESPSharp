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
	public partial class RelatedCameraPaths : Subrecord, ICloneable<RelatedCameraPaths>, IReferenceContainer
	{
		public FormID Parent { get; set; }
		public FormID PreviousSibling { get; set; }

		public RelatedCameraPaths()
		{
			Parent = new FormID();
			PreviousSibling = new FormID();
		}

		public RelatedCameraPaths(FormID Parent, FormID PreviousSibling)
		{
			this.Parent = Parent;
			this.PreviousSibling = PreviousSibling;
		}

		public RelatedCameraPaths(RelatedCameraPaths copyObject)
		{
			Parent = copyObject.Parent.Clone();
			PreviousSibling = copyObject.PreviousSibling.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					PreviousSibling.ReadBinary(subReader);
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
			PreviousSibling.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("PreviousSibling", true, out subEle);
			PreviousSibling.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Parent", false, out subEle))
			{
				Parent.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("PreviousSibling", false, out subEle))
			{
				PreviousSibling.ReadXML(subEle, master);
			}
		}

		public RelatedCameraPaths Clone()
		{
			return new RelatedCameraPaths(this);
		}

	}
}
