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

namespace ESPSharp.SubrecordCollections
{
	public partial class HeadData : SubrecordCollection, ICloneable<HeadData>, IReferenceContainer
	{
		public SimpleSubrecord<HeadPartIndex> Index { get; set; }
		public Model Model { get; set; }
		public Icon Icon { get; set; }

		public HeadData()
		{
			Index = new SimpleSubrecord<HeadPartIndex>();
			Model = new Model();
		}

		public HeadData(SimpleSubrecord<HeadPartIndex> Index, Model Model, Icon Icon)
		{
			this.Index = Index;
			this.Model = Model;
			this.Icon = Icon;
		}

		public HeadData(HeadData copyObject)
		{
			Index = copyObject.Index.Clone();
			Model = copyObject.Model.Clone();
			Icon = copyObject.Icon.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "INDX":
						if (readTags.Contains("INDX"))
							return;
						Index.ReadBinary(reader);
						break;
					case "MODL":
						if (readTags.Contains("MODL"))
							return;
						Model.ReadBinary(reader);
						break;
					case "ICON":
						if (readTags.Contains("ICON"))
							return;
						if (Icon == null)
							Icon = new Icon();

						Icon.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Index != null)
				Index.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Icon != null)
				Icon.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;
			if (Index != null)		
			{		
				ele.TryPathTo("Index", true, out subEle);
				Index.WriteXML(subEle);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
			}
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Index", false, out subEle))
			{
				if (Index == null)
					Index = new SimpleSubrecord<HeadPartIndex>();
					
				Index.ReadXML(subEle);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
			}
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new Icon();
					
			}
		}

		public HeadData Clone()
		{
			return new HeadData(this);
		}

	}
}
