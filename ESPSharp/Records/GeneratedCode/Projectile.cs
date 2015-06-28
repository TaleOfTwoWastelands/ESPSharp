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
	public partial class Projectile : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public Destructable Destructable { get; set; }
		public ProjectileData ProjectileData { get; set; }
		public SimpleSubrecord<String> MuzzleFlashModelFilename { get; set; }
		public SimpleSubrecord<Byte[]> MuzzleFlashModelTextureHash { get; set; }
		public SimpleSubrecord<SoundLevel> SoundLevel { get; set; }
	
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
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "DEST":
						if (Destructable == null)
							Destructable = new Destructable();

						Destructable.ReadBinary(reader);
						break;
					case "DATA":
						if (ProjectileData == null)
							ProjectileData = new ProjectileData();

						ProjectileData.ReadBinary(reader);
						break;
					case "NAM1":
						if (MuzzleFlashModelFilename == null)
							MuzzleFlashModelFilename = new SimpleSubrecord<String>();

						MuzzleFlashModelFilename.ReadBinary(reader);
						break;
					case "NAM2":
						if (MuzzleFlashModelTextureHash == null)
							MuzzleFlashModelTextureHash = new SimpleSubrecord<Byte[]>();

						MuzzleFlashModelTextureHash.ReadBinary(reader);
						break;
					case "VNAM":
						if (SoundLevel == null)
							SoundLevel = new SimpleSubrecord<SoundLevel>();

						SoundLevel.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (Destructable != null)
				Destructable.WriteBinary(writer);
			if (ProjectileData != null)
				ProjectileData.WriteBinary(writer);
			if (MuzzleFlashModelFilename != null)
				MuzzleFlashModelFilename.WriteBinary(writer);
			if (MuzzleFlashModelTextureHash != null)
				MuzzleFlashModelTextureHash.WriteBinary(writer);
			if (SoundLevel != null)
				SoundLevel.WriteBinary(writer);
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
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (Destructable != null)		
			{		
				ele.TryPathTo("Destructable", true, out subEle);
				Destructable.WriteXML(subEle, master);
			}
			if (ProjectileData != null)		
			{		
				ele.TryPathTo("ProjectileData", true, out subEle);
				ProjectileData.WriteXML(subEle, master);
			}
			if (MuzzleFlashModelFilename != null)		
			{		
				ele.TryPathTo("MuzzleFlash/Model/Filename", true, out subEle);
				MuzzleFlashModelFilename.WriteXML(subEle, master);
			}
			if (MuzzleFlashModelTextureHash != null)		
			{		
				ele.TryPathTo("MuzzleFlash/Model/TextureHash", true, out subEle);
				MuzzleFlashModelTextureHash.WriteXML(subEle, master);
			}
			if (SoundLevel != null)		
			{		
				ele.TryPathTo("SoundLevel", true, out subEle);
				SoundLevel.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Destructable", false, out subEle))
			{
				if (Destructable == null)
					Destructable = new Destructable();
					
				Destructable.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ProjectileData", false, out subEle))
			{
				if (ProjectileData == null)
					ProjectileData = new ProjectileData();
					
				ProjectileData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MuzzleFlash/Model/Filename", false, out subEle))
			{
				if (MuzzleFlashModelFilename == null)
					MuzzleFlashModelFilename = new SimpleSubrecord<String>();
					
				MuzzleFlashModelFilename.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MuzzleFlash/Model/TextureHash", false, out subEle))
			{
				if (MuzzleFlashModelTextureHash == null)
					MuzzleFlashModelTextureHash = new SimpleSubrecord<Byte[]>();
					
				MuzzleFlashModelTextureHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SoundLevel", false, out subEle))
			{
				if (SoundLevel == null)
					SoundLevel = new SimpleSubrecord<SoundLevel>();
					
				SoundLevel.ReadXML(subEle, master);
			}
		}

	}
}
