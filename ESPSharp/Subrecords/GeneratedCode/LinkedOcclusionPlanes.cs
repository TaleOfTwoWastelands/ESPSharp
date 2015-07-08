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
	public partial class LinkedOcclusionPlanes : Subrecord, ICloneable<LinkedOcclusionPlanes>, IReferenceContainer
	{
		public FormID Right { get; set; }
		public FormID Left { get; set; }
		public FormID Bottom { get; set; }
		public FormID Top { get; set; }

		public LinkedOcclusionPlanes()
		{
			Right = new FormID();
			Left = new FormID();
			Bottom = new FormID();
			Top = new FormID();
		}

		public LinkedOcclusionPlanes(FormID Right, FormID Left, FormID Bottom, FormID Top)
		{
			this.Right = Right;
			this.Left = Left;
			this.Bottom = Bottom;
			this.Top = Top;
		}

		public LinkedOcclusionPlanes(LinkedOcclusionPlanes copyObject)
		{
			Right = copyObject.Right.Clone();
			Left = copyObject.Left.Clone();
			Bottom = copyObject.Bottom.Clone();
			Top = copyObject.Top.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Right.ReadBinary(subReader);
					Left.ReadBinary(subReader);
					Bottom.ReadBinary(subReader);
					Top.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Right.WriteBinary(writer);
			Left.WriteBinary(writer);
			Bottom.WriteBinary(writer);
			Top.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Right", true, out subEle);
			Right.WriteXML(subEle, master);

			ele.TryPathTo("Left", true, out subEle);
			Left.WriteXML(subEle, master);

			ele.TryPathTo("Bottom", true, out subEle);
			Bottom.WriteXML(subEle, master);

			ele.TryPathTo("Top", true, out subEle);
			Top.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Right", false, out subEle))
			{
				Right.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Left", false, out subEle))
			{
				Left.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Bottom", false, out subEle))
			{
				Bottom.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Top", false, out subEle))
			{
				Top.ReadXML(subEle, master);
			}
		}

		public LinkedOcclusionPlanes Clone()
		{
			return new LinkedOcclusionPlanes(this);
		}

	}
}
