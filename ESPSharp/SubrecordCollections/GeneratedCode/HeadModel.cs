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
	public partial class HeadModel : SubrecordCollection	{
		public SimpleSubrecord<HeadPartIndex> Index { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }

		public HeadModel()
		{
			Index = new SimpleSubrecord<HeadPartIndex>();
			Model = new Model();
		}

		public HeadModel(SimpleSubrecord<HeadPartIndex> Index, Model Model, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon)
		{
			this.Index = Index;
			this.Model = Model;
			this.LargeIcon = LargeIcon;
			this.SmallIcon = SmallIcon;
		}

		public HeadModel(HeadModel copyObject)
		{
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
						if (LargeIcon == null)
							LargeIcon = new SimpleSubrecord<String>();

						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (readTags.Contains("MICO"))
							return;
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();

						SmallIcon.ReadBinary(reader);
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
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Index != null)		
			{		
				ele.TryPathTo("Index", true, out subEle);
				Index.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon/Large", true, out subEle);
				LargeIcon.WriteXML(subEle, master);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon/Small", true, out subEle);
				SmallIcon.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Index", false, out subEle))
			{
				if (Index == null)
					Index = new SimpleSubrecord<HeadPartIndex>();
					
				Index.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle, master);
			}
		}

		public HeadModel Clone()
		{
			return new HeadModel(this);
		}

	}
}
