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
	public partial class LocalVariable : SubrecordCollection, ICloneable<LocalVariable>
	{
		public LocalVariableData Data { get; set; }
		public SimpleSubrecord<String> Name { get; set; }

		public LocalVariable()
		{
			Data = new LocalVariableData();
		}

		public LocalVariable(LocalVariableData Data, SimpleSubrecord<String> Name)
		{
			this.Data = Data;
			this.Name = Name;
		}

		public LocalVariable(LocalVariable copyObject)
		{
			Data = copyObject.Data.Clone();
			Name = copyObject.Name.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "SLSD":
						if (readTags.Contains("SLSD"))
							return;
						Data.ReadBinary(reader);
						break;
					case "SCVR":
						if (readTags.Contains("SCVR"))
							return;
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;

			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new LocalVariableData();
					
				Data.ReadXML(subEle);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle);
			}
		}

		public LocalVariable Clone()
		{
			return new LocalVariable(this);
		}

	}
}
