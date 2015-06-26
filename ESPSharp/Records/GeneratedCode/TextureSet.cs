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
	public partial class TextureSet : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> BaseImage_Transparency { get; set; }
		public SimpleSubrecord<String> NormalMap_Specular { get; set; }
		public SimpleSubrecord<String> EnvironmentMapMask { get; set; }
		public SimpleSubrecord<String> GlowMap { get; set; }
		public SimpleSubrecord<String> ParallaxMap { get; set; }
		public SimpleSubrecord<String> EnvironmentMap { get; set; }
		public DecalData DecalData { get; set; }
		public SimpleSubrecord<TXSTFlags> TextureSetFlags { get; set; }
	
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
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "TX00":
						if (BaseImage_Transparency == null)
							BaseImage_Transparency = new SimpleSubrecord<String>();

						BaseImage_Transparency.ReadBinary(reader);
						break;
					case "TX01":
						if (NormalMap_Specular == null)
							NormalMap_Specular = new SimpleSubrecord<String>();

						NormalMap_Specular.ReadBinary(reader);
						break;
					case "TX02":
						if (EnvironmentMapMask == null)
							EnvironmentMapMask = new SimpleSubrecord<String>();

						EnvironmentMapMask.ReadBinary(reader);
						break;
					case "TX03":
						if (GlowMap == null)
							GlowMap = new SimpleSubrecord<String>();

						GlowMap.ReadBinary(reader);
						break;
					case "TX04":
						if (ParallaxMap == null)
							ParallaxMap = new SimpleSubrecord<String>();

						ParallaxMap.ReadBinary(reader);
						break;
					case "TX05":
						if (EnvironmentMap == null)
							EnvironmentMap = new SimpleSubrecord<String>();

						EnvironmentMap.ReadBinary(reader);
						break;
					case "DODT":
						if (DecalData == null)
							DecalData = new DecalData();

						DecalData.ReadBinary(reader);
						break;
					case "DNAM":
						if (TextureSetFlags == null)
							TextureSetFlags = new SimpleSubrecord<TXSTFlags>();

						TextureSetFlags.ReadBinary(reader);
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
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (BaseImage_Transparency != null)
				BaseImage_Transparency.WriteBinary(writer);
			if (NormalMap_Specular != null)
				NormalMap_Specular.WriteBinary(writer);
			if (EnvironmentMapMask != null)
				EnvironmentMapMask.WriteBinary(writer);
			if (GlowMap != null)
				GlowMap.WriteBinary(writer);
			if (ParallaxMap != null)
				ParallaxMap.WriteBinary(writer);
			if (EnvironmentMap != null)
				EnvironmentMap.WriteBinary(writer);
			if (DecalData != null)
				DecalData.WriteBinary(writer);
			if (TextureSetFlags != null)
				TextureSetFlags.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle, master);
			}
			if (BaseImage_Transparency != null)		
			{		
				ele.TryPathTo("BaseImage_Transparency", true, out subEle);
				BaseImage_Transparency.WriteXML(subEle, master);
			}
			if (NormalMap_Specular != null)		
			{		
				ele.TryPathTo("NormalMap_Specular", true, out subEle);
				NormalMap_Specular.WriteXML(subEle, master);
			}
			if (EnvironmentMapMask != null)		
			{		
				ele.TryPathTo("EnvironmentMapMask", true, out subEle);
				EnvironmentMapMask.WriteXML(subEle, master);
			}
			if (GlowMap != null)		
			{		
				ele.TryPathTo("GlowMap", true, out subEle);
				GlowMap.WriteXML(subEle, master);
			}
			if (ParallaxMap != null)		
			{		
				ele.TryPathTo("ParallaxMap", true, out subEle);
				ParallaxMap.WriteXML(subEle, master);
			}
			if (EnvironmentMap != null)		
			{		
				ele.TryPathTo("EnvironmentMap", true, out subEle);
				EnvironmentMap.WriteXML(subEle, master);
			}
			if (DecalData != null)		
			{		
				ele.TryPathTo("DecalData", true, out subEle);
				DecalData.WriteXML(subEle, master);
			}
			if (TextureSetFlags != null)		
			{		
				ele.TryPathTo("TextureSetFlags", true, out subEle);
				TextureSetFlags.WriteXML(subEle, master);
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
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BaseImage_Transparency", false, out subEle))
			{
				if (BaseImage_Transparency == null)
					BaseImage_Transparency = new SimpleSubrecord<String>();
					
				BaseImage_Transparency.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NormalMap_Specular", false, out subEle))
			{
				if (NormalMap_Specular == null)
					NormalMap_Specular = new SimpleSubrecord<String>();
					
				NormalMap_Specular.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnvironmentMapMask", false, out subEle))
			{
				if (EnvironmentMapMask == null)
					EnvironmentMapMask = new SimpleSubrecord<String>();
					
				EnvironmentMapMask.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("GlowMap", false, out subEle))
			{
				if (GlowMap == null)
					GlowMap = new SimpleSubrecord<String>();
					
				GlowMap.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ParallaxMap", false, out subEle))
			{
				if (ParallaxMap == null)
					ParallaxMap = new SimpleSubrecord<String>();
					
				ParallaxMap.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnvironmentMap", false, out subEle))
			{
				if (EnvironmentMap == null)
					EnvironmentMap = new SimpleSubrecord<String>();
					
				EnvironmentMap.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DecalData", false, out subEle))
			{
				if (DecalData == null)
					DecalData = new DecalData();
					
				DecalData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureSetFlags", false, out subEle))
			{
				if (TextureSetFlags == null)
					TextureSetFlags = new SimpleSubrecord<TXSTFlags>();
					
				TextureSetFlags.ReadXML(subEle, master);
			}
		}

	}
}
