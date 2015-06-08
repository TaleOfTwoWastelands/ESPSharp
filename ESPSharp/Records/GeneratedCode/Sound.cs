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
	public partial class Sound : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Filename { get; set; }
		public SimpleSubrecord<Byte> RandomChance { get; set; }
		public SoundData SoundData { get; set; }
		public SoundDataShort SoundDataShort { get; set; }
		public SoundAttenuation AttenuationCurve { get; set; }
		public SimpleSubrecord<Int16> ReverbAttenuationControl { get; set; }
		public SimpleSubrecord<Int32> SoundPriority { get; set; }
	
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
					case "FNAM":
						if (Filename == null)
							Filename = new SimpleSubrecord<String>();

						Filename.ReadBinary(reader);
						break;
					case "RNAM":
						if (RandomChance == null)
							RandomChance = new SimpleSubrecord<Byte>();

						RandomChance.ReadBinary(reader);
						break;
					case "SNDD":
						if (SoundData == null)
							SoundData = new SoundData();

						SoundData.ReadBinary(reader);
						break;
					case "SNDX":
						if (SoundDataShort == null)
							SoundDataShort = new SoundDataShort();

						SoundDataShort.ReadBinary(reader);
						break;
					case "ANAM":
						if (AttenuationCurve == null)
							AttenuationCurve = new SoundAttenuation();

						AttenuationCurve.ReadBinary(reader);
						break;
					case "GNAM":
						if (ReverbAttenuationControl == null)
							ReverbAttenuationControl = new SimpleSubrecord<Int16>();

						ReverbAttenuationControl.ReadBinary(reader);
						break;
					case "HNAM":
						if (SoundPriority == null)
							SoundPriority = new SimpleSubrecord<Int32>();

						SoundPriority.ReadBinary(reader);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (Filename != null)
				Filename.WriteBinary(writer);
			if (RandomChance != null)
				RandomChance.WriteBinary(writer);
			if (SoundData != null)
				SoundData.WriteBinary(writer);
			if (SoundDataShort != null)
				SoundDataShort.WriteBinary(writer);
			if (AttenuationCurve != null)
				AttenuationCurve.WriteBinary(writer);
			if (ReverbAttenuationControl != null)
				ReverbAttenuationControl.WriteBinary(writer);
			if (SoundPriority != null)
				SoundPriority.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle);
			}
			if (Filename != null)		
			{		
				ele.TryPathTo("Filename", true, out subEle);
				Filename.WriteXML(subEle);
			}
			if (RandomChance != null)		
			{		
				ele.TryPathTo("RandomChance", true, out subEle);
				RandomChance.WriteXML(subEle);
			}
			if (SoundData != null)		
			{		
				ele.TryPathTo("SoundData", true, out subEle);
				SoundData.WriteXML(subEle);
			}
			if (SoundDataShort != null)		
			{		
				ele.TryPathTo("SoundDataShort", true, out subEle);
				SoundDataShort.WriteXML(subEle);
			}
			if (AttenuationCurve != null)		
			{		
				ele.TryPathTo("AttenuationCurve", true, out subEle);
				AttenuationCurve.WriteXML(subEle);
			}
			if (ReverbAttenuationControl != null)		
			{		
				ele.TryPathTo("ReverbAttenuationControl", true, out subEle);
				ReverbAttenuationControl.WriteXML(subEle);
			}
			if (SoundPriority != null)		
			{		
				ele.TryPathTo("SoundPriority", true, out subEle);
				SoundPriority.WriteXML(subEle);
			}
		}

		public override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle);
			}
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle);
			}
			if (ele.TryPathTo("Filename", false, out subEle))
			{
				if (Filename == null)
					Filename = new SimpleSubrecord<String>();
					
				Filename.ReadXML(subEle);
			}
			if (ele.TryPathTo("RandomChance", false, out subEle))
			{
				if (RandomChance == null)
					RandomChance = new SimpleSubrecord<Byte>();
					
				RandomChance.ReadXML(subEle);
			}
			if (ele.TryPathTo("SoundData", false, out subEle))
			{
				if (SoundData == null)
					SoundData = new SoundData();
					
				SoundData.ReadXML(subEle);
			}
			if (ele.TryPathTo("SoundDataShort", false, out subEle))
			{
				if (SoundDataShort == null)
					SoundDataShort = new SoundDataShort();
					
				SoundDataShort.ReadXML(subEle);
			}
			if (ele.TryPathTo("AttenuationCurve", false, out subEle))
			{
				if (AttenuationCurve == null)
					AttenuationCurve = new SoundAttenuation();
					
				AttenuationCurve.ReadXML(subEle);
			}
			if (ele.TryPathTo("ReverbAttenuationControl", false, out subEle))
			{
				if (ReverbAttenuationControl == null)
					ReverbAttenuationControl = new SimpleSubrecord<Int16>();
					
				ReverbAttenuationControl.ReadXML(subEle);
			}
			if (ele.TryPathTo("SoundPriority", false, out subEle))
			{
				if (SoundPriority == null)
					SoundPriority = new SimpleSubrecord<Int32>();
					
				SoundPriority.ReadXML(subEle);
			}
		}

	}
}
