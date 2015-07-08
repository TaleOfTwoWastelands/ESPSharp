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
	public partial class BodyPart : SubrecordCollection, ICloneable<BodyPart>, IReferenceContainer
	{
		public SimpleSubrecord<String> PartNode { get; set; }
		public SimpleSubrecord<String> VATSTarget { get; set; }
		public SimpleSubrecord<String> IKDataStartNode { get; set; }
		public BodyPartInfo Data { get; set; }
		public SimpleSubrecord<String> LimbReplacementModel { get; set; }
		public SimpleSubrecord<String> GoreEffectsTargetBone { get; set; }
		public SimpleSubrecord<Byte[]> TextureFileHashes { get; set; }

		public BodyPart()
		{
			PartNode = new SimpleSubrecord<String>();
			VATSTarget = new SimpleSubrecord<String>();
			IKDataStartNode = new SimpleSubrecord<String>();
			Data = new BodyPartInfo();
			LimbReplacementModel = new SimpleSubrecord<String>();
			GoreEffectsTargetBone = new SimpleSubrecord<String>();
		}

		public BodyPart(SimpleSubrecord<String> PartNode, SimpleSubrecord<String> VATSTarget, SimpleSubrecord<String> IKDataStartNode, BodyPartInfo Data, SimpleSubrecord<String> LimbReplacementModel, SimpleSubrecord<String> GoreEffectsTargetBone, SimpleSubrecord<Byte[]> TextureFileHashes)
		{
			this.PartNode = PartNode;
			this.VATSTarget = VATSTarget;
			this.IKDataStartNode = IKDataStartNode;
			this.Data = Data;
			this.LimbReplacementModel = LimbReplacementModel;
			this.GoreEffectsTargetBone = GoreEffectsTargetBone;
			this.TextureFileHashes = TextureFileHashes;
		}

		public BodyPart(BodyPart copyObject)
		{
			PartNode = copyObject.PartNode.Clone();
			VATSTarget = copyObject.VATSTarget.Clone();
			IKDataStartNode = copyObject.IKDataStartNode.Clone();
			Data = copyObject.Data.Clone();
			LimbReplacementModel = copyObject.LimbReplacementModel.Clone();
			GoreEffectsTargetBone = copyObject.GoreEffectsTargetBone.Clone();
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
					case "BPNN":
						if (readTags.Contains("BPNN"))
							return;
						PartNode.ReadBinary(reader);
						break;
					case "BPNT":
						if (readTags.Contains("BPNT"))
							return;
						VATSTarget.ReadBinary(reader);
						break;
					case "BPNI":
						if (readTags.Contains("BPNI"))
							return;
						IKDataStartNode.ReadBinary(reader);
						break;
					case "BPND":
						if (readTags.Contains("BPND"))
							return;
						Data.ReadBinary(reader);
						break;
					case "NAM1":
						if (readTags.Contains("NAM1"))
							return;
						LimbReplacementModel.ReadBinary(reader);
						break;
					case "NAM4":
						if (readTags.Contains("NAM4"))
							return;
						GoreEffectsTargetBone.ReadBinary(reader);
						break;
					case "NAM5":
						if (readTags.Contains("NAM5"))
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
			if (PartNode != null)
				PartNode.WriteBinary(writer);
			if (VATSTarget != null)
				VATSTarget.WriteBinary(writer);
			if (IKDataStartNode != null)
				IKDataStartNode.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (LimbReplacementModel != null)
				LimbReplacementModel.WriteBinary(writer);
			if (GoreEffectsTargetBone != null)
				GoreEffectsTargetBone.WriteBinary(writer);
			if (TextureFileHashes != null)
				TextureFileHashes.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (PartNode != null)		
			{		
				ele.TryPathTo("PartNode", true, out subEle);
				PartNode.WriteXML(subEle, master);
			}
			if (VATSTarget != null)		
			{		
				ele.TryPathTo("VATSTarget", true, out subEle);
				VATSTarget.WriteXML(subEle, master);
			}
			if (IKDataStartNode != null)		
			{		
				ele.TryPathTo("IKData/StartNode", true, out subEle);
				IKDataStartNode.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (LimbReplacementModel != null)		
			{		
				ele.TryPathTo("LimbReplacementModel", true, out subEle);
				LimbReplacementModel.WriteXML(subEle, master);
			}
			if (GoreEffectsTargetBone != null)		
			{		
				ele.TryPathTo("GoreEffectsTargetBone", true, out subEle);
				GoreEffectsTargetBone.WriteXML(subEle, master);
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
			
			if (ele.TryPathTo("PartNode", false, out subEle))
			{
				if (PartNode == null)
					PartNode = new SimpleSubrecord<String>();
					
				PartNode.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("VATSTarget", false, out subEle))
			{
				if (VATSTarget == null)
					VATSTarget = new SimpleSubrecord<String>();
					
				VATSTarget.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IKData/StartNode", false, out subEle))
			{
				if (IKDataStartNode == null)
					IKDataStartNode = new SimpleSubrecord<String>();
					
				IKDataStartNode.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new BodyPartInfo();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LimbReplacementModel", false, out subEle))
			{
				if (LimbReplacementModel == null)
					LimbReplacementModel = new SimpleSubrecord<String>();
					
				LimbReplacementModel.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("GoreEffectsTargetBone", false, out subEle))
			{
				if (GoreEffectsTargetBone == null)
					GoreEffectsTargetBone = new SimpleSubrecord<String>();
					
				GoreEffectsTargetBone.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureFileHashes", false, out subEle))
			{
				if (TextureFileHashes == null)
					TextureFileHashes = new SimpleSubrecord<Byte[]>();
					
				TextureFileHashes.ReadXML(subEle, master);
			}
		}

		public BodyPart Clone()
		{
			return new BodyPart(this);
		}

	}
}
