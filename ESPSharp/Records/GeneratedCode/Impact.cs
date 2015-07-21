
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

namespace ESPSharp.Records
{
	public partial class Impact : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Model Model { get; set; }
		public ImpactData Data { get; set; }
		public DecalData DecalData { get; set; }
		public RecordReference TextureSet { get; set; }
		public RecordReference Sound1 { get; set; }
		public RecordReference Sound2 { get; set; }

		public Impact()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Data = new ImpactData("DATA");
		}

		public Impact(SimpleSubrecord<String> EditorID, Model Model, ImpactData Data, DecalData DecalData, RecordReference TextureSet, RecordReference Sound1, RecordReference Sound2)
		{
			this.EditorID = EditorID;
			this.Data = Data;
		}

		public Impact(Impact copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new ImpactData();

						Data.ReadBinary(reader);
						break;
					case "DODT":
						if (DecalData == null)
							DecalData = new DecalData();

						DecalData.ReadBinary(reader);
						break;
					case "DNAM":
						if (TextureSet == null)
							TextureSet = new RecordReference();

						TextureSet.ReadBinary(reader);
						break;
					case "SNAM":
						if (Sound1 == null)
							Sound1 = new RecordReference();

						Sound1.ReadBinary(reader);
						break;
					case "NAM1":
						if (Sound2 == null)
							Sound2 = new RecordReference();

						Sound2.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (DecalData != null)
				DecalData.WriteBinary(writer);
			if (TextureSet != null)
				TextureSet.WriteBinary(writer);
			if (Sound1 != null)
				Sound1.WriteBinary(writer);
			if (Sound2 != null)
				Sound2.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (DecalData != null)		
			{		
				ele.TryPathTo("DecalData", true, out subEle);
				DecalData.WriteXML(subEle, master);
			}
			if (TextureSet != null)		
			{		
				ele.TryPathTo("TextureSet", true, out subEle);
				TextureSet.WriteXML(subEle, master);
			}
			if (Sound1 != null)		
			{		
				ele.TryPathTo("Sound1", true, out subEle);
				Sound1.WriteXML(subEle, master);
			}
			if (Sound2 != null)		
			{		
				ele.TryPathTo("Sound2", true, out subEle);
				Sound2.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new ImpactData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DecalData", false, out subEle))
			{
				if (DecalData == null)
					DecalData = new DecalData();
					
				DecalData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureSet", false, out subEle))
			{
				if (TextureSet == null)
					TextureSet = new RecordReference();
					
				TextureSet.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound1", false, out subEle))
			{
				if (Sound1 == null)
					Sound1 = new RecordReference();
					
				Sound1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound2", false, out subEle))
			{
				if (Sound2 == null)
					Sound2 = new RecordReference();
					
				Sound2.ReadXML(subEle, master);
			}
		}		

		public Impact Clone()
		{
			return new Impact(this);
		}

	}
}