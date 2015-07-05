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
	public partial class Water : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<String> NoiseMap { get; set; }
		public SimpleSubrecord<Byte> Opacity { get; set; }
		public SimpleSubrecord<WaterFlags> WaterFlags { get; set; }
		public SimpleSubrecord<String> MaterialID { get; set; }
		public RecordReference Sound { get; set; }
		public RecordReference ActorEffect { get; set; }
		public SimpleSubrecord<UInt16> Damage { get; set; }
		public WaterData Data { get; set; }
		public RelatedWaters RelatedWaters { get; set; }
	
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
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "NNAM":
						if (NoiseMap == null)
							NoiseMap = new SimpleSubrecord<String>();

						NoiseMap.ReadBinary(reader);
						break;
					case "ANAM":
						if (Opacity == null)
							Opacity = new SimpleSubrecord<Byte>();

						Opacity.ReadBinary(reader);
						break;
					case "FNAM":
						if (WaterFlags == null)
							WaterFlags = new SimpleSubrecord<WaterFlags>();

						WaterFlags.ReadBinary(reader);
						break;
					case "MNAM":
						if (MaterialID == null)
							MaterialID = new SimpleSubrecord<String>();

						MaterialID.ReadBinary(reader);
						break;
					case "SNAM":
						if (Sound == null)
							Sound = new RecordReference();

						Sound.ReadBinary(reader);
						break;
					case "XNAM":
						if (ActorEffect == null)
							ActorEffect = new RecordReference();

						ActorEffect.ReadBinary(reader);
						break;
					case "DATA":
						ReadDamage(reader);
						break;
					case "DNAM":
						if (Data == null)
							Data = new WaterData();

						Data.ReadBinary(reader);
						break;
					case "GNAM":
						if (RelatedWaters == null)
							RelatedWaters = new RelatedWaters();

						RelatedWaters.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (NoiseMap != null)
				NoiseMap.WriteBinary(writer);
			if (Opacity != null)
				Opacity.WriteBinary(writer);
			if (WaterFlags != null)
				WaterFlags.WriteBinary(writer);
			if (MaterialID != null)
				MaterialID.WriteBinary(writer);
			if (Sound != null)
				Sound.WriteBinary(writer);
			if (ActorEffect != null)
				ActorEffect.WriteBinary(writer);
			if (Damage != null)
				Damage.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (RelatedWaters != null)
				RelatedWaters.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (NoiseMap != null)		
			{		
				ele.TryPathTo("NoiseMap", true, out subEle);
				NoiseMap.WriteXML(subEle, master);
			}
			if (Opacity != null)		
			{		
				ele.TryPathTo("Opacity", true, out subEle);
				Opacity.WriteXML(subEle, master);
			}
			if (WaterFlags != null)		
			{		
				ele.TryPathTo("WaterFlags", true, out subEle);
				WaterFlags.WriteXML(subEle, master);
			}
			if (MaterialID != null)		
			{		
				ele.TryPathTo("MaterialID", true, out subEle);
				MaterialID.WriteXML(subEle, master);
			}
			if (Sound != null)		
			{		
				ele.TryPathTo("Sound", true, out subEle);
				Sound.WriteXML(subEle, master);
			}
			if (ActorEffect != null)		
			{		
				ele.TryPathTo("ActorEffect", true, out subEle);
				ActorEffect.WriteXML(subEle, master);
			}
			if (Damage != null)		
			{		
				ele.TryPathTo("Damage", true, out subEle);
				Damage.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (RelatedWaters != null)		
			{		
				ele.TryPathTo("RelatedWaters", true, out subEle);
				RelatedWaters.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NoiseMap", false, out subEle))
			{
				if (NoiseMap == null)
					NoiseMap = new SimpleSubrecord<String>();
					
				NoiseMap.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Opacity", false, out subEle))
			{
				if (Opacity == null)
					Opacity = new SimpleSubrecord<Byte>();
					
				Opacity.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaterFlags", false, out subEle))
			{
				if (WaterFlags == null)
					WaterFlags = new SimpleSubrecord<WaterFlags>();
					
				WaterFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MaterialID", false, out subEle))
			{
				if (MaterialID == null)
					MaterialID = new SimpleSubrecord<String>();
					
				MaterialID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Sound", false, out subEle))
			{
				if (Sound == null)
					Sound = new RecordReference();
					
				Sound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ActorEffect", false, out subEle))
			{
				if (ActorEffect == null)
					ActorEffect = new RecordReference();
					
				ActorEffect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Damage", false, out subEle))
			{
				if (Damage == null)
					Damage = new SimpleSubrecord<UInt16>();
					
				Damage.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new WaterData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RelatedWaters", false, out subEle))
			{
				if (RelatedWaters == null)
					RelatedWaters = new RelatedWaters();
					
				RelatedWaters.ReadXML(subEle, master);
			}
		}

		partial void ReadDamage(ESPReader reader);
	}
}
