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
	public partial class Header : Record	{
		public PluginHeader FileHeader { get; set; }
		public SimpleSubrecord<Byte[]> OffsetData { get; set; }
		public SimpleSubrecord<Byte[]> DeletionsData { get; set; }
		public SimpleSubrecord<String> Author { get; set; }
		public SimpleSubrecord<String> Description { get; set; }
		public List<MasterFileData> MasterFiles { get; set; }
		public FormArray OverriddenRecords { get; set; }
		public SimpleSubrecord<Byte[]> ScreenshotData { get; set; }
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "HEDR":
						if (FileHeader == null)
							FileHeader = new PluginHeader();

						FileHeader.ReadBinary(reader);
						break;
					case "OFST":
						if (OffsetData == null)
							OffsetData = new SimpleSubrecord<Byte[]>();

						OffsetData.ReadBinary(reader);
						break;
					case "DELE":
						if (DeletionsData == null)
							DeletionsData = new SimpleSubrecord<Byte[]>();

						DeletionsData.ReadBinary(reader);
						break;
					case "CNAM":
						if (Author == null)
							Author = new SimpleSubrecord<String>();

						Author.ReadBinary(reader);
						break;
					case "SNAM":
						if (Description == null)
							Description = new SimpleSubrecord<String>();

						Description.ReadBinary(reader);
						break;
					case "MAST":
						if (MasterFiles == null)
							MasterFiles = new List<MasterFileData>();

						MasterFileData tempMAST = new MasterFileData();
						tempMAST.ReadBinary(reader);
						MasterFiles.Add(tempMAST);
						break;
					case "ONAM":
						if (OverriddenRecords == null)
							OverriddenRecords = new FormArray();

						OverriddenRecords.ReadBinary(reader);
						break;
					case "SCRN":
						if (ScreenshotData == null)
							ScreenshotData = new SimpleSubrecord<Byte[]>();

						ScreenshotData.ReadBinary(reader);
						break;
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (FileHeader != null)
				FileHeader.WriteBinary(writer);
			if (OffsetData != null)
				OffsetData.WriteBinary(writer);
			if (DeletionsData != null)
				DeletionsData.WriteBinary(writer);
			if (Author != null)
				Author.WriteBinary(writer);
			if (Description != null)
				Description.WriteBinary(writer);
			if (MasterFiles != null)
				foreach (var item in MasterFiles)
					item.WriteBinary(writer);
			if (OverriddenRecords != null)
				OverriddenRecords.WriteBinary(writer);
			if (ScreenshotData != null)
				ScreenshotData.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (FileHeader != null)		
			{		
				ele.TryPathTo("FileHeader", true, out subEle);
				FileHeader.WriteXML(subEle, master);
			}
			if (OffsetData != null)		
			{		
				ele.TryPathTo("OffsetData", true, out subEle);
				OffsetData.WriteXML(subEle, master);
			}
			if (DeletionsData != null)		
			{		
				ele.TryPathTo("DeletionsData", true, out subEle);
				DeletionsData.WriteXML(subEle, master);
			}
			if (Author != null)		
			{		
				ele.TryPathTo("Author", true, out subEle);
				Author.WriteXML(subEle, master);
			}
			if (Description != null)		
			{		
				ele.TryPathTo("Description", true, out subEle);
				Description.WriteXML(subEle, master);
			}
			if (MasterFiles != null)		
			{		
				ele.TryPathTo("MasterFiles", true, out subEle);
				List<string> xmlNames = new List<string>{"MasterFile"};
				int i = 0;
				foreach (var entry in MasterFiles)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (OverriddenRecords != null)		
			{		
				ele.TryPathTo("OverriddenRecords", true, out subEle);
				OverriddenRecords.WriteXML(subEle, master);
			}
			if (ScreenshotData != null)		
			{		
				ele.TryPathTo("ScreenshotData", true, out subEle);
				ScreenshotData.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("FileHeader", false, out subEle))
			{
				if (FileHeader == null)
					FileHeader = new PluginHeader();
					
				FileHeader.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OffsetData", false, out subEle))
			{
				if (OffsetData == null)
					OffsetData = new SimpleSubrecord<Byte[]>();
					
				OffsetData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DeletionsData", false, out subEle))
			{
				if (DeletionsData == null)
					DeletionsData = new SimpleSubrecord<Byte[]>();
					
				DeletionsData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Author", false, out subEle))
			{
				if (Author == null)
					Author = new SimpleSubrecord<String>();
					
				Author.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Description", false, out subEle))
			{
				if (Description == null)
					Description = new SimpleSubrecord<String>();
					
				Description.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MasterFiles", false, out subEle))
			{
				if (MasterFiles == null)
					MasterFiles = new List<MasterFileData>();
					
				foreach (XElement e in subEle.Elements())
				{
					MasterFileData tempMAST = new MasterFileData();
					tempMAST.ReadXML(e, master);
					MasterFiles.Add(tempMAST);
				}
			}
			if (ele.TryPathTo("OverriddenRecords", false, out subEle))
			{
				if (OverriddenRecords == null)
					OverriddenRecords = new FormArray();
					
				OverriddenRecords.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ScreenshotData", false, out subEle))
			{
				if (ScreenshotData == null)
					ScreenshotData = new SimpleSubrecord<Byte[]>();
					
				ScreenshotData.ReadXML(subEle, master);
			}
		}

	}
}
