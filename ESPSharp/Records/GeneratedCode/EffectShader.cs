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
	public partial class EffectShader : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> FillTexture { get; set; }
		public SimpleSubrecord<String> ParticleShaderTexture { get; set; }
		public SimpleSubrecord<String> HolesTexture { get; set; }
		public EffectShaderData Data { get; set; }
	
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
					case "ICON":
						if (FillTexture == null)
							FillTexture = new SimpleSubrecord<String>();

						FillTexture.ReadBinary(reader);
						break;
					case "ICO2":
						if (ParticleShaderTexture == null)
							ParticleShaderTexture = new SimpleSubrecord<String>();

						ParticleShaderTexture.ReadBinary(reader);
						break;
					case "NAM7":
						if (HolesTexture == null)
							HolesTexture = new SimpleSubrecord<String>();

						HolesTexture.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new EffectShaderData();

						Data.ReadBinary(reader);
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
			if (FillTexture != null)
				FillTexture.WriteBinary(writer);
			if (ParticleShaderTexture != null)
				ParticleShaderTexture.WriteBinary(writer);
			if (HolesTexture != null)
				HolesTexture.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (FillTexture != null)		
			{		
				ele.TryPathTo("FillTexture", true, out subEle);
				FillTexture.WriteXML(subEle, master);
			}
			if (ParticleShaderTexture != null)		
			{		
				ele.TryPathTo("ParticleShaderTexture", true, out subEle);
				ParticleShaderTexture.WriteXML(subEle, master);
			}
			if (HolesTexture != null)		
			{		
				ele.TryPathTo("HolesTexture", true, out subEle);
				HolesTexture.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
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
			if (ele.TryPathTo("FillTexture", false, out subEle))
			{
				if (FillTexture == null)
					FillTexture = new SimpleSubrecord<String>();
					
				FillTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ParticleShaderTexture", false, out subEle))
			{
				if (ParticleShaderTexture == null)
					ParticleShaderTexture = new SimpleSubrecord<String>();
					
				ParticleShaderTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("HolesTexture", false, out subEle))
			{
				if (HolesTexture == null)
					HolesTexture = new SimpleSubrecord<String>();
					
				HolesTexture.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new EffectShaderData();
					
				Data.ReadXML(subEle, master);
			}
		}

	}
}
