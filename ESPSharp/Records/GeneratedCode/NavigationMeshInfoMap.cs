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
	public partial class NavigationMeshInfoMap : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<UInt32> Version { get; set; }
		public List<NavigationMapInfo> NavigationMapInfoList { get; set; }
		public List<NavigationConnectionInfo> NavigationConnectionInfoList { get; set; }
	
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
					case "NVER":
						if (Version == null)
							Version = new SimpleSubrecord<UInt32>();

						Version.ReadBinary(reader);
						break;
					case "NVMI":
						if (NavigationMapInfoList == null)
							NavigationMapInfoList = new List<NavigationMapInfo>();

						NavigationMapInfo tempNVMI = new NavigationMapInfo();
						tempNVMI.ReadBinary(reader);
						NavigationMapInfoList.Add(tempNVMI);
						break;
					case "NVCI":
						if (NavigationConnectionInfoList == null)
							NavigationConnectionInfoList = new List<NavigationConnectionInfo>();

						NavigationConnectionInfo tempNVCI = new NavigationConnectionInfo();
						tempNVCI.ReadBinary(reader);
						NavigationConnectionInfoList.Add(tempNVCI);
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
			if (Version != null)
				Version.WriteBinary(writer);
			if (NavigationMapInfoList != null)
				foreach (var item in NavigationMapInfoList)
					item.WriteBinary(writer);
			if (NavigationConnectionInfoList != null)
				foreach (var item in NavigationConnectionInfoList)
					item.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Version != null)		
			{		
				ele.TryPathTo("Version", true, out subEle);
				Version.WriteXML(subEle, master);
			}
			if (NavigationMapInfoList != null)		
			{		
				ele.TryPathTo("NavigationMapInfoList", true, out subEle);
				List<string> xmlNames = new List<string>{"NavigationMapInfo"};
				int i = 0;
				foreach (var entry in NavigationMapInfoList)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (NavigationConnectionInfoList != null)		
			{		
				ele.TryPathTo("NavigationConnectionInfoList", true, out subEle);
				List<string> xmlNames = new List<string>{"NavigationConnectionInfo"};
				int i = 0;
				foreach (var entry in NavigationConnectionInfoList)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
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
			if (ele.TryPathTo("Version", false, out subEle))
			{
				if (Version == null)
					Version = new SimpleSubrecord<UInt32>();
					
				Version.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NavigationMapInfoList", false, out subEle))
			{
				if (NavigationMapInfoList == null)
					NavigationMapInfoList = new List<NavigationMapInfo>();
					
				foreach (XElement e in subEle.Elements())
				{
					NavigationMapInfo tempNVMI = new NavigationMapInfo();
					tempNVMI.ReadXML(e, master);
					NavigationMapInfoList.Add(tempNVMI);
				}
			}
			if (ele.TryPathTo("NavigationConnectionInfoList", false, out subEle))
			{
				if (NavigationConnectionInfoList == null)
					NavigationConnectionInfoList = new List<NavigationConnectionInfo>();
					
				foreach (XElement e in subEle.Elements())
				{
					NavigationConnectionInfo tempNVCI = new NavigationConnectionInfo();
					tempNVCI.ReadXML(e, master);
					NavigationConnectionInfoList.Add(tempNVCI);
				}
			}
		}

	}
}
