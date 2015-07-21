
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
	public partial class MusicType : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Filename { get; set; }
		public SimpleSubrecord<Single> Decibel { get; set; }

		public MusicType()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public MusicType(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Filename, SimpleSubrecord<Single> Decibel)
		{
			this.EditorID = EditorID;
		}

		public MusicType(MusicType copyObject)
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
					case "FNAM":
						if (Filename == null)
							Filename = new SimpleSubrecord<String>();

						Filename.ReadBinary(reader);
						break;
					case "ANAM":
						if (Decibel == null)
							Decibel = new SimpleSubrecord<Single>();

						Decibel.ReadBinary(reader);
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
			if (Filename != null)
				Filename.WriteBinary(writer);
			if (Decibel != null)
				Decibel.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Filename != null)		
			{		
				ele.TryPathTo("Filename", true, out subEle);
				Filename.WriteXML(subEle, master);
			}
			if (Decibel != null)		
			{		
				ele.TryPathTo("Decibel", true, out subEle);
				Decibel.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Filename", false, out subEle))
			{
				if (Filename == null)
					Filename = new SimpleSubrecord<String>();
					
				Filename.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel", false, out subEle))
			{
				if (Decibel == null)
					Decibel = new SimpleSubrecord<Single>();
					
				Decibel.ReadXML(subEle, master);
			}
		}		

		public MusicType Clone()
		{
			return new MusicType(this);
		}

	}
}