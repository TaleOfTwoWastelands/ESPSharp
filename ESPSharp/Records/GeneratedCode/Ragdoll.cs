
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
	public partial class Ragdoll : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<UInt32> Version { get; set; }
		public RagdollData GeneralData { get; set; }
		public RecordReference ActorBase { get; set; }
		public RecordReference BodyPartData { get; set; }
		public RagdollFeedbackData FeedbackData { get; set; }
		public RagdollDynamicBones DynamicBones { get; set; }
		public RagdollPoseMatching PoseMatchingData { get; set; }
		public SimpleSubrecord<String> DeathPose { get; set; }

		public Ragdoll()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			Version = new SimpleSubrecord<UInt32>("NVER");
			GeneralData = new RagdollData("DATA");
			ActorBase = new RecordReference("XNAM");
			BodyPartData = new RecordReference("TNAM");
			PoseMatchingData = new RagdollPoseMatching("RAPS");
		}

		public Ragdoll(SimpleSubrecord<String> EditorID, SimpleSubrecord<UInt32> Version, RagdollData GeneralData, RecordReference ActorBase, RecordReference BodyPartData, RagdollFeedbackData FeedbackData, RagdollDynamicBones DynamicBones, RagdollPoseMatching PoseMatchingData, SimpleSubrecord<String> DeathPose)
		{
			this.EditorID = EditorID;
			this.Version = Version;
			this.GeneralData = GeneralData;
			this.ActorBase = ActorBase;
			this.BodyPartData = BodyPartData;
			this.PoseMatchingData = PoseMatchingData;
		}

		public Ragdoll(Ragdoll copyObject)
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
					case "NVER":
						if (Version == null)
							Version = new SimpleSubrecord<UInt32>();

						Version.ReadBinary(reader);
						break;
					case "DATA":
						if (GeneralData == null)
							GeneralData = new RagdollData();

						GeneralData.ReadBinary(reader);
						break;
					case "XNAM":
						if (ActorBase == null)
							ActorBase = new RecordReference();

						ActorBase.ReadBinary(reader);
						break;
					case "TNAM":
						if (BodyPartData == null)
							BodyPartData = new RecordReference();

						BodyPartData.ReadBinary(reader);
						break;
					case "RAFD":
						if (FeedbackData == null)
							FeedbackData = new RagdollFeedbackData();

						FeedbackData.ReadBinary(reader);
						break;
					case "RAFB":
						if (DynamicBones == null)
							DynamicBones = new RagdollDynamicBones();

						DynamicBones.ReadBinary(reader);
						break;
					case "RAPS":
						if (PoseMatchingData == null)
							PoseMatchingData = new RagdollPoseMatching();

						PoseMatchingData.ReadBinary(reader);
						break;
					case "ANAM":
						if (DeathPose == null)
							DeathPose = new SimpleSubrecord<String>();

						DeathPose.ReadBinary(reader);
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
			if (GeneralData != null)
				GeneralData.WriteBinary(writer);
			if (ActorBase != null)
				ActorBase.WriteBinary(writer);
			if (BodyPartData != null)
				BodyPartData.WriteBinary(writer);
			if (FeedbackData != null)
				FeedbackData.WriteBinary(writer);
			if (DynamicBones != null)
				DynamicBones.WriteBinary(writer);
			if (PoseMatchingData != null)
				PoseMatchingData.WriteBinary(writer);
			if (DeathPose != null)
				DeathPose.WriteBinary(writer);
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
			if (GeneralData != null)		
			{		
				ele.TryPathTo("GeneralData", true, out subEle);
				GeneralData.WriteXML(subEle, master);
			}
			if (ActorBase != null)		
			{		
				ele.TryPathTo("ActorBase", true, out subEle);
				ActorBase.WriteXML(subEle, master);
			}
			if (BodyPartData != null)		
			{		
				ele.TryPathTo("BodyPartData", true, out subEle);
				BodyPartData.WriteXML(subEle, master);
			}
			if (FeedbackData != null)		
			{		
				ele.TryPathTo("FeedbackData", true, out subEle);
				FeedbackData.WriteXML(subEle, master);
			}
			if (DynamicBones != null)		
			{		
				ele.TryPathTo("DynamicBones", true, out subEle);
				DynamicBones.WriteXML(subEle, master);
			}
			if (PoseMatchingData != null)		
			{		
				ele.TryPathTo("PoseMatchingData", true, out subEle);
				PoseMatchingData.WriteXML(subEle, master);
			}
			if (DeathPose != null)		
			{		
				ele.TryPathTo("DeathPose", true, out subEle);
				DeathPose.WriteXML(subEle, master);
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
			if (ele.TryPathTo("GeneralData", false, out subEle))
			{
				if (GeneralData == null)
					GeneralData = new RagdollData();
					
				GeneralData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ActorBase", false, out subEle))
			{
				if (ActorBase == null)
					ActorBase = new RecordReference();
					
				ActorBase.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BodyPartData", false, out subEle))
			{
				if (BodyPartData == null)
					BodyPartData = new RecordReference();
					
				BodyPartData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FeedbackData", false, out subEle))
			{
				if (FeedbackData == null)
					FeedbackData = new RagdollFeedbackData();
					
				FeedbackData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DynamicBones", false, out subEle))
			{
				if (DynamicBones == null)
					DynamicBones = new RagdollDynamicBones();
					
				DynamicBones.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PoseMatchingData", false, out subEle))
			{
				if (PoseMatchingData == null)
					PoseMatchingData = new RagdollPoseMatching();
					
				PoseMatchingData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DeathPose", false, out subEle))
			{
				if (DeathPose == null)
					DeathPose = new SimpleSubrecord<String>();
					
				DeathPose.ReadXML(subEle, master);
			}
		}		

		public Ragdoll Clone()
		{
			return new Ragdoll(this);
		}

	}
}