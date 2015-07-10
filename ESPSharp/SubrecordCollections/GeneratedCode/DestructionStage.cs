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
	public partial class DestructionStage : SubrecordCollection, ICloneable<DestructionStage>
	{
		public DestructionStageData StageData { get; set; }
		public SimpleSubrecord<String> ModelFilename { get; set; }
		public SimpleSubrecord<Byte[]> ModelTextureHash { get; set; }
		public SubMarker EndMarker { get; set; }

		public DestructionStage()
		{
			StageData = new DestructionStageData();
		}

		public DestructionStage(DestructionStageData StageData, SimpleSubrecord<String> ModelFilename, SimpleSubrecord<Byte[]> ModelTextureHash, SubMarker EndMarker)
		{
			this.StageData = StageData;
			this.ModelFilename = ModelFilename;
			this.ModelTextureHash = ModelTextureHash;
			this.EndMarker = EndMarker;
		}

		public DestructionStage(DestructionStage copyObject)
		{
			StageData = copyObject.StageData.Clone();
			ModelFilename = copyObject.ModelFilename.Clone();
			ModelTextureHash = copyObject.ModelTextureHash.Clone();
			EndMarker = copyObject.EndMarker.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "DSTD":
						if (readTags.Contains("DSTD"))
							return;
						StageData.ReadBinary(reader);
						break;
					case "DMDL":
						if (readTags.Contains("DMDL"))
							return;
						if (ModelFilename == null)
							ModelFilename = new SimpleSubrecord<String>();

						ModelFilename.ReadBinary(reader);
						break;
					case "DMDT":
						if (readTags.Contains("DMDT"))
							return;
						if (ModelTextureHash == null)
							ModelTextureHash = new SimpleSubrecord<Byte[]>();

						ModelTextureHash.ReadBinary(reader);
						break;
					case "DSTF":
						if (readTags.Contains("DSTF"))
							return;
						if (EndMarker == null)
							EndMarker = new SubMarker();

						EndMarker.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (StageData != null)
				StageData.WriteBinary(writer);
			if (ModelFilename != null)
				ModelFilename.WriteBinary(writer);
			if (ModelTextureHash != null)
				ModelTextureHash.WriteBinary(writer);
			if (EndMarker != null)
				EndMarker.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (StageData != null)		
			{		
				ele.TryPathTo("StageData", true, out subEle);
				StageData.WriteXML(subEle, master);
			}
			if (ModelFilename != null)		
			{		
				ele.TryPathTo("ModelFilename", true, out subEle);
				ModelFilename.WriteXML(subEle, master);
			}
			if (ModelTextureHash != null)		
			{		
				ele.TryPathTo("ModelTextureHash", true, out subEle);
				ModelTextureHash.WriteXML(subEle, master);
			}
			if (EndMarker != null)		
			{		
				ele.TryPathTo("EndMarker", true, out subEle);
				EndMarker.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("StageData", false, out subEle))
			{
				if (StageData == null)
					StageData = new DestructionStageData();
					
				StageData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelFilename", false, out subEle))
			{
				if (ModelFilename == null)
					ModelFilename = new SimpleSubrecord<String>();
					
				ModelFilename.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ModelTextureHash", false, out subEle))
			{
				if (ModelTextureHash == null)
					ModelTextureHash = new SimpleSubrecord<Byte[]>();
					
				ModelTextureHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EndMarker", false, out subEle))
			{
				if (EndMarker == null)
					EndMarker = new SubMarker();
					
				EndMarker.ReadXML(subEle, master);
			}
		}

		public DestructionStage Clone()
		{
			return new DestructionStage(this);
		}

	}
}
