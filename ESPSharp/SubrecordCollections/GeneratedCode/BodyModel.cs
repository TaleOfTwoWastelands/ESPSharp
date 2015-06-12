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
	public partial class BodyModel : SubrecordCollection, ICloneable<BodyModel>, IReferenceContainer
	{
		public SimpleSubrecord<BodyPartIndex> Index { get; set; }
		public Icon Icon { get; set; }
		public Model Model { get; set; }

		public BodyModel()
		{
			Index = new SimpleSubrecord<BodyPartIndex>();
			Model = new Model();
		}

		public BodyModel(SimpleSubrecord<BodyPartIndex> Index, Icon Icon, Model Model)
		{
			this.Index = Index;
			this.Icon = Icon;
			this.Model = Model;
		}

		public BodyModel(BodyModel copyObject)
		{
			Index = copyObject.Index.Clone();
			Icon = copyObject.Icon.Clone();
			Model = copyObject.Model.Clone();
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
					case "ICON":
						if (readTags.Contains("ICON"))
							return;
						if (Icon == null)
							Icon = new Icon();

						Icon.ReadBinary(reader);
						break;
					case "MODL":
						if (readTags.Contains("MODL"))
							return;
						Model.ReadBinary(reader);
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
			if (Icon != null)
				Icon.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Index != null)		
			{		
				ele.TryPathTo("Index", true, out subEle);
				Index.WriteXML(subEle, master);
			}
			if (Icon != null)		
			{		
				ele.TryPathTo("Icon", true, out subEle);
				Icon.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Index", false, out subEle))
			{
				if (Index == null)
					Index = new SimpleSubrecord<BodyPartIndex>();
					
				Index.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon", false, out subEle))
			{
				if (Icon == null)
					Icon = new Icon();
					
				Icon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
		}

		public BodyModel Clone()
		{
			return new BodyModel(this);
		}

	}
}
