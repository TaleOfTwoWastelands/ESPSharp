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
	public partial class CombatStyle : Record, IEditorID	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public CombatStyleDecision DecisionData { get; set; }
		public CombatStyleAdvanced AdvancedData { get; set; }
		public CombatStyleSimple SimpleData { get; set; }
	
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
					case "CSTD":
						if (DecisionData == null)
							DecisionData = new CombatStyleDecision();

						DecisionData.ReadBinary(reader);
						break;
					case "CSAD":
						if (AdvancedData == null)
							AdvancedData = new CombatStyleAdvanced();

						AdvancedData.ReadBinary(reader);
						break;
					case "CSSD":
						if (SimpleData == null)
							SimpleData = new CombatStyleSimple();

						SimpleData.ReadBinary(reader);
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
			if (DecisionData != null)
				DecisionData.WriteBinary(writer);
			if (AdvancedData != null)
				AdvancedData.WriteBinary(writer);
			if (SimpleData != null)
				SimpleData.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (DecisionData != null)		
			{		
				ele.TryPathTo("DecisionData", true, out subEle);
				DecisionData.WriteXML(subEle, master);
			}
			if (AdvancedData != null)		
			{		
				ele.TryPathTo("AdvancedData", true, out subEle);
				AdvancedData.WriteXML(subEle, master);
			}
			if (SimpleData != null)		
			{		
				ele.TryPathTo("SimpleData", true, out subEle);
				SimpleData.WriteXML(subEle, master);
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
			if (ele.TryPathTo("DecisionData", false, out subEle))
			{
				if (DecisionData == null)
					DecisionData = new CombatStyleDecision();
					
				DecisionData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AdvancedData", false, out subEle))
			{
				if (AdvancedData == null)
					AdvancedData = new CombatStyleAdvanced();
					
				AdvancedData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SimpleData", false, out subEle))
			{
				if (SimpleData == null)
					SimpleData = new CombatStyleSimple();
					
				SimpleData.ReadXML(subEle, master);
			}
		}

	}
}
