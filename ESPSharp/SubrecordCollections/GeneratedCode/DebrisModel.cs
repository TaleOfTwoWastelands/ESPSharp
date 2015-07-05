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
	public partial class DebrisModel : SubrecordCollection, ICloneable<DebrisModel>
	{
		public DebrisData Data { get; set; }
		public SimpleSubrecord<Byte[]> TextureFileHashes { get; set; }

		public DebrisModel()
		{
			Data = new DebrisData();
		}

		public DebrisModel(DebrisData Data, SimpleSubrecord<Byte[]> TextureFileHashes)
		{
			this.Data = Data;
			this.TextureFileHashes = TextureFileHashes;
		}

		public DebrisModel(DebrisModel copyObject)
		{
			Data = copyObject.Data.Clone();
			TextureFileHashes = copyObject.TextureFileHashes.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "DATA":
						if (readTags.Contains("DATA"))
							return;
						Data.ReadBinary(reader);
						break;
					case "MODT":
						if (readTags.Contains("MODT"))
							return;
						if (TextureFileHashes == null)
							TextureFileHashes = new SimpleSubrecord<Byte[]>();

						TextureFileHashes.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Data != null)
				Data.WriteBinary(writer);
			if (TextureFileHashes != null)
				TextureFileHashes.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (TextureFileHashes != null)		
			{		
				ele.TryPathTo("TextureFileHashes", true, out subEle);
				TextureFileHashes.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new DebrisData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureFileHashes", false, out subEle))
			{
				if (TextureFileHashes == null)
					TextureFileHashes = new SimpleSubrecord<Byte[]>();
					
				TextureFileHashes.ReadXML(subEle, master);
			}
		}

		public DebrisModel Clone()
		{
			return new DebrisModel(this);
		}

	}
}
