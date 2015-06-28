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
	public partial class IdleMarker : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<IdleMarkerFlags> IdleMarkerFlags { get; set; }
		public SimpleSubrecord<Byte> AnimationCount { get; set; }
		public SimpleSubrecord<Single> IdleTimer { get; set; }
		public FormArray Animations { get; set; }
	
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
					case "IDLF":
						if (IdleMarkerFlags == null)
							IdleMarkerFlags = new SimpleSubrecord<IdleMarkerFlags>();

						IdleMarkerFlags.ReadBinary(reader);
						break;
					case "IDLC":
						if (AnimationCount == null)
							AnimationCount = new SimpleSubrecord<Byte>();

						AnimationCount.ReadBinary(reader);
						break;
					case "IDLT":
						if (IdleTimer == null)
							IdleTimer = new SimpleSubrecord<Single>();

						IdleTimer.ReadBinary(reader);
						break;
					case "IDLA":
						if (Animations == null)
							Animations = new FormArray();

						Animations.ReadBinary(reader);
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
			if (IdleMarkerFlags != null)
				IdleMarkerFlags.WriteBinary(writer);
			if (AnimationCount != null)
				AnimationCount.WriteBinary(writer);
			if (IdleTimer != null)
				IdleTimer.WriteBinary(writer);
			if (Animations != null)
				Animations.WriteBinary(writer);
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
			if (IdleMarkerFlags != null)		
			{		
				ele.TryPathTo("IdleMarkerFlags", true, out subEle);
				IdleMarkerFlags.WriteXML(subEle, master);
			}
			if (AnimationCount != null)		
			{		
				ele.TryPathTo("AnimationCount", true, out subEle);
				AnimationCount.WriteXML(subEle, master);
			}
			if (IdleTimer != null)		
			{		
				ele.TryPathTo("IdleTimer", true, out subEle);
				IdleTimer.WriteXML(subEle, master);
			}
			if (Animations != null)		
			{		
				ele.TryPathTo("Animations", true, out subEle);
				Animations.WriteXML(subEle, master);
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
			if (ele.TryPathTo("IdleMarkerFlags", false, out subEle))
			{
				if (IdleMarkerFlags == null)
					IdleMarkerFlags = new SimpleSubrecord<IdleMarkerFlags>();
					
				IdleMarkerFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AnimationCount", false, out subEle))
			{
				if (AnimationCount == null)
					AnimationCount = new SimpleSubrecord<Byte>();
					
				AnimationCount.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IdleTimer", false, out subEle))
			{
				if (IdleTimer == null)
					IdleTimer = new SimpleSubrecord<Single>();
					
				IdleTimer.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Animations", false, out subEle))
			{
				if (Animations == null)
					Animations = new FormArray();
					
				Animations.ReadXML(subEle, master);
			}
		}

	}
}
