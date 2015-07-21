
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
	public partial class GameSetting : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public Subrecord Value { get; set; }

		public GameSetting()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public GameSetting(SimpleSubrecord<String> EditorID, Subrecord Value)
		{
			this.EditorID = EditorID;
		}

		public GameSetting(GameSetting copyObject)
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
					case "DATA":
						ReadValue(reader);
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

			WriteValue(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}

			WriteValueXML(ele, master);
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

			ReadValueXML(ele, master);
		}		

		public GameSetting Clone()
		{
			return new GameSetting(this);
		}


		partial void ReadValue(ESPReader reader);

		partial void WriteValue(ESPWriter writer);

		partial void WriteValueXML(XElement ele, ElderScrollsPlugin master);

		partial void ReadValueXML(XElement ele, ElderScrollsPlugin master);
	}
}