
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
	public partial class PlacedGrenade : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public RecordReference Base { get; set; }
		public RecordReference EncounterZone { get; set; }
		public SimpleSubrecord<Byte[]> RagdollData { get; set; }
		public SimpleSubrecord<Byte[]> RagdollBipedData { get; set; }
		public ReferencePatrolData Patrol { get; set; }
		public RecordReference Owner { get; set; }
		public SimpleSubrecord<Int32> FactionRank { get; set; }
		public SimpleSubrecord<Int32> Count { get; set; }
		public SimpleSubrecord<Single> Radius { get; set; }
		public SimpleSubrecord<Single> Health { get; set; }
		public List<WaterReflection> WaterReflections { get; set; }
		public List<SimpleSubrecord<Byte[]>> Decals { get; set; }
		public RecordReference LinkedReference { get; set; }
		public LinkedReferenceColor LinkedReferenceColor { get; set; }
		public SimpleSubrecord<NoYesByte> ParentActivateOnly { get; set; }
		public List<ActivateParent> ActivateParents { get; set; }
		public SimpleSubrecord<String> ActivationPrompt { get; set; }
		public EnableParent EnableParent { get; set; }
		public RecordReference Emittance { get; set; }
		public RecordReference MultiBound { get; set; }
		public SubMarker IgnoredBySandbox { get; set; }
		public SimpleSubrecord<Single> Scale { get; set; }
		public PositionRotation PositionRotation { get; set; }

		public PlacedGrenade()
		{
					}

		public PlacedGrenade(SimpleSubrecord<String> EditorID, RecordReference Base, RecordReference EncounterZone, SimpleSubrecord<Byte[]> RagdollData, SimpleSubrecord<Byte[]> RagdollBipedData, ReferencePatrolData Patrol, RecordReference Owner, SimpleSubrecord<Int32> FactionRank, SimpleSubrecord<Int32> Count, SimpleSubrecord<Single> Radius, SimpleSubrecord<Single> Health, List<WaterReflection> WaterReflections, List<SimpleSubrecord<Byte[]>> Decals, RecordReference LinkedReference, LinkedReferenceColor LinkedReferenceColor, SimpleSubrecord<NoYesByte> ParentActivateOnly, List<ActivateParent> ActivateParents, SimpleSubrecord<String> ActivationPrompt, EnableParent EnableParent, RecordReference Emittance, RecordReference MultiBound, SubMarker IgnoredBySandbox, SimpleSubrecord<Single> Scale, PositionRotation PositionRotation)
		{
					}

		public PlacedGrenade(PlacedGrenade copyObject)
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
					case "NAME":
						if (Base == null)
							Base = new RecordReference();

						Base.ReadBinary(reader);
						break;
					case "XEZN":
						if (EncounterZone == null)
							EncounterZone = new RecordReference();

						EncounterZone.ReadBinary(reader);
						break;
					case "XRGD":
						if (RagdollData == null)
							RagdollData = new SimpleSubrecord<Byte[]>();

						RagdollData.ReadBinary(reader);
						break;
					case "XRGB":
						if (RagdollBipedData == null)
							RagdollBipedData = new SimpleSubrecord<Byte[]>();

						RagdollBipedData.ReadBinary(reader);
						break;
					case "XPRD":
						if (Patrol == null)
							Patrol = new ReferencePatrolData();

						Patrol.ReadBinary(reader);
						break;
					case "XOWN":
						if (Owner == null)
							Owner = new RecordReference();

						Owner.ReadBinary(reader);
						break;
					case "XRNK":
						if (FactionRank == null)
							FactionRank = new SimpleSubrecord<Int32>();

						FactionRank.ReadBinary(reader);
						break;
					case "XCNT":
						if (Count == null)
							Count = new SimpleSubrecord<Int32>();

						Count.ReadBinary(reader);
						break;
					case "XRDS":
						if (Radius == null)
							Radius = new SimpleSubrecord<Single>();

						Radius.ReadBinary(reader);
						break;
					case "XHLP":
						if (Health == null)
							Health = new SimpleSubrecord<Single>();

						Health.ReadBinary(reader);
						break;
					case "XPWR":
						if (WaterReflections == null)
							WaterReflections = new List<WaterReflection>();

						WaterReflection tempXPWR = new WaterReflection();
						tempXPWR.ReadBinary(reader);
						WaterReflections.Add(tempXPWR);
						break;
					case "XDCR":
						if (Decals == null)
							Decals = new List<SimpleSubrecord<Byte[]>>();

						SimpleSubrecord<Byte[]> tempXDCR = new SimpleSubrecord<Byte[]>();
						tempXDCR.ReadBinary(reader);
						Decals.Add(tempXDCR);
						break;
					case "XLKR":
						if (LinkedReference == null)
							LinkedReference = new RecordReference();

						LinkedReference.ReadBinary(reader);
						break;
					case "XCLP":
						if (LinkedReferenceColor == null)
							LinkedReferenceColor = new LinkedReferenceColor();

						LinkedReferenceColor.ReadBinary(reader);
						break;
					case "XAPD":
						if (ParentActivateOnly == null)
							ParentActivateOnly = new SimpleSubrecord<NoYesByte>();

						ParentActivateOnly.ReadBinary(reader);
						break;
					case "XAPR":
						if (ActivateParents == null)
							ActivateParents = new List<ActivateParent>();

						ActivateParent tempXAPR = new ActivateParent();
						tempXAPR.ReadBinary(reader);
						ActivateParents.Add(tempXAPR);
						break;
					case "XATO":
						if (ActivationPrompt == null)
							ActivationPrompt = new SimpleSubrecord<String>();

						ActivationPrompt.ReadBinary(reader);
						break;
					case "XESP":
						if (EnableParent == null)
							EnableParent = new EnableParent();

						EnableParent.ReadBinary(reader);
						break;
					case "XEMI":
						if (Emittance == null)
							Emittance = new RecordReference();

						Emittance.ReadBinary(reader);
						break;
					case "XMBR":
						if (MultiBound == null)
							MultiBound = new RecordReference();

						MultiBound.ReadBinary(reader);
						break;
					case "XIBS":
						if (IgnoredBySandbox == null)
							IgnoredBySandbox = new SubMarker();

						IgnoredBySandbox.ReadBinary(reader);
						break;
					case "XSCL":
						if (Scale == null)
							Scale = new SimpleSubrecord<Single>();

						Scale.ReadBinary(reader);
						break;
					case "DATA":
						if (PositionRotation == null)
							PositionRotation = new PositionRotation();

						PositionRotation.ReadBinary(reader);
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
			if (Base != null)
				Base.WriteBinary(writer);
			if (EncounterZone != null)
				EncounterZone.WriteBinary(writer);
			if (RagdollData != null)
				RagdollData.WriteBinary(writer);
			if (RagdollBipedData != null)
				RagdollBipedData.WriteBinary(writer);
			if (Patrol != null)
				Patrol.WriteBinary(writer);
			if (Owner != null)
				Owner.WriteBinary(writer);
			if (FactionRank != null)
				FactionRank.WriteBinary(writer);
			if (Count != null)
				Count.WriteBinary(writer);
			if (Radius != null)
				Radius.WriteBinary(writer);
			if (Health != null)
				Health.WriteBinary(writer);
			if (WaterReflections != null)
				foreach (var item in WaterReflections)
					item.WriteBinary(writer);
			if (Decals != null)
				foreach (var item in Decals)
					item.WriteBinary(writer);
			if (LinkedReference != null)
				LinkedReference.WriteBinary(writer);
			if (LinkedReferenceColor != null)
				LinkedReferenceColor.WriteBinary(writer);
			if (ParentActivateOnly != null)
				ParentActivateOnly.WriteBinary(writer);
			if (ActivateParents != null)
				foreach (var item in ActivateParents)
					item.WriteBinary(writer);
			if (ActivationPrompt != null)
				ActivationPrompt.WriteBinary(writer);
			if (EnableParent != null)
				EnableParent.WriteBinary(writer);
			if (Emittance != null)
				Emittance.WriteBinary(writer);
			if (MultiBound != null)
				MultiBound.WriteBinary(writer);
			if (IgnoredBySandbox != null)
				IgnoredBySandbox.WriteBinary(writer);
			if (Scale != null)
				Scale.WriteBinary(writer);
			if (PositionRotation != null)
				PositionRotation.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Base != null)		
			{		
				ele.TryPathTo("Base", true, out subEle);
				Base.WriteXML(subEle, master);
			}
			if (EncounterZone != null)		
			{		
				ele.TryPathTo("EncounterZone", true, out subEle);
				EncounterZone.WriteXML(subEle, master);
			}
			if (RagdollData != null)		
			{		
				ele.TryPathTo("RagdollData", true, out subEle);
				RagdollData.WriteXML(subEle, master);
			}
			if (RagdollBipedData != null)		
			{		
				ele.TryPathTo("RagdollBipedData", true, out subEle);
				RagdollBipedData.WriteXML(subEle, master);
			}
			if (Patrol != null)		
			{		
				ele.TryPathTo("Patrol", true, out subEle);
				Patrol.WriteXML(subEle, master);
			}
			if (Owner != null)		
			{		
				ele.TryPathTo("Owner", true, out subEle);
				Owner.WriteXML(subEle, master);
			}
			if (FactionRank != null)		
			{		
				ele.TryPathTo("FactionRank", true, out subEle);
				FactionRank.WriteXML(subEle, master);
			}
			if (Count != null)		
			{		
				ele.TryPathTo("Count", true, out subEle);
				Count.WriteXML(subEle, master);
			}
			if (Radius != null)		
			{		
				ele.TryPathTo("Radius", true, out subEle);
				Radius.WriteXML(subEle, master);
			}
			if (Health != null)		
			{		
				ele.TryPathTo("Health", true, out subEle);
				Health.WriteXML(subEle, master);
			}
			if (WaterReflections != null)		
			{		
				ele.TryPathTo("WaterReflections", true, out subEle);
				List<string> xmlNames = new List<string>{"WaterReflection"};
				int i = 0;
				foreach (var entry in WaterReflections)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (Decals != null)		
			{		
				ele.TryPathTo("Decals", true, out subEle);
				List<string> xmlNames = new List<string>{"Decal"};
				int i = 0;
				foreach (var entry in Decals)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (LinkedReference != null)		
			{		
				ele.TryPathTo("LinkedReference", true, out subEle);
				LinkedReference.WriteXML(subEle, master);
			}
			if (LinkedReferenceColor != null)		
			{		
				ele.TryPathTo("LinkedReferenceColor", true, out subEle);
				LinkedReferenceColor.WriteXML(subEle, master);
			}
			if (ParentActivateOnly != null)		
			{		
				ele.TryPathTo("ParentActivateOnly", true, out subEle);
				ParentActivateOnly.WriteXML(subEle, master);
			}
			if (ActivateParents != null)		
			{		
				ele.TryPathTo("ActivateParents", true, out subEle);
				List<string> xmlNames = new List<string>{"ActivateParent"};
				int i = 0;
				foreach (var entry in ActivateParents)
				{
					i = i % xmlNames.Count();
					XElement newEle = new XElement(xmlNames[i]);
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
					i++;
				}
			}
			if (ActivationPrompt != null)		
			{		
				ele.TryPathTo("ActivationPrompt", true, out subEle);
				ActivationPrompt.WriteXML(subEle, master);
			}
			if (EnableParent != null)		
			{		
				ele.TryPathTo("EnableParent", true, out subEle);
				EnableParent.WriteXML(subEle, master);
			}
			if (Emittance != null)		
			{		
				ele.TryPathTo("Emittance", true, out subEle);
				Emittance.WriteXML(subEle, master);
			}
			if (MultiBound != null)		
			{		
				ele.TryPathTo("MultiBound", true, out subEle);
				MultiBound.WriteXML(subEle, master);
			}
			if (IgnoredBySandbox != null)		
			{		
				ele.TryPathTo("IgnoredBySandbox", true, out subEle);
				IgnoredBySandbox.WriteXML(subEle, master);
			}
			if (Scale != null)		
			{		
				ele.TryPathTo("Scale", true, out subEle);
				Scale.WriteXML(subEle, master);
			}
			if (PositionRotation != null)		
			{		
				ele.TryPathTo("PositionRotation", true, out subEle);
				PositionRotation.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Base", false, out subEle))
			{
				if (Base == null)
					Base = new RecordReference();
					
				Base.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EncounterZone", false, out subEle))
			{
				if (EncounterZone == null)
					EncounterZone = new RecordReference();
					
				EncounterZone.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RagdollData", false, out subEle))
			{
				if (RagdollData == null)
					RagdollData = new SimpleSubrecord<Byte[]>();
					
				RagdollData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RagdollBipedData", false, out subEle))
			{
				if (RagdollBipedData == null)
					RagdollBipedData = new SimpleSubrecord<Byte[]>();
					
				RagdollBipedData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Patrol", false, out subEle))
			{
				if (Patrol == null)
					Patrol = new ReferencePatrolData();
					
				Patrol.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Owner", false, out subEle))
			{
				if (Owner == null)
					Owner = new RecordReference();
					
				Owner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FactionRank", false, out subEle))
			{
				if (FactionRank == null)
					FactionRank = new SimpleSubrecord<Int32>();
					
				FactionRank.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Count", false, out subEle))
			{
				if (Count == null)
					Count = new SimpleSubrecord<Int32>();
					
				Count.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Radius", false, out subEle))
			{
				if (Radius == null)
					Radius = new SimpleSubrecord<Single>();
					
				Radius.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Health", false, out subEle))
			{
				if (Health == null)
					Health = new SimpleSubrecord<Single>();
					
				Health.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaterReflections", false, out subEle))
			{
				if (WaterReflections == null)
					WaterReflections = new List<WaterReflection>();
					
				foreach (XElement e in subEle.Elements())
				{
					WaterReflection tempXPWR = new WaterReflection();
					tempXPWR.ReadXML(e, master);
					WaterReflections.Add(tempXPWR);
				}
			}
			if (ele.TryPathTo("Decals", false, out subEle))
			{
				if (Decals == null)
					Decals = new List<SimpleSubrecord<Byte[]>>();
					
				foreach (XElement e in subEle.Elements())
				{
					SimpleSubrecord<Byte[]> tempXDCR = new SimpleSubrecord<Byte[]>();
					tempXDCR.ReadXML(e, master);
					Decals.Add(tempXDCR);
				}
			}
			if (ele.TryPathTo("LinkedReference", false, out subEle))
			{
				if (LinkedReference == null)
					LinkedReference = new RecordReference();
					
				LinkedReference.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LinkedReferenceColor", false, out subEle))
			{
				if (LinkedReferenceColor == null)
					LinkedReferenceColor = new LinkedReferenceColor();
					
				LinkedReferenceColor.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ParentActivateOnly", false, out subEle))
			{
				if (ParentActivateOnly == null)
					ParentActivateOnly = new SimpleSubrecord<NoYesByte>();
					
				ParentActivateOnly.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ActivateParents", false, out subEle))
			{
				if (ActivateParents == null)
					ActivateParents = new List<ActivateParent>();
					
				foreach (XElement e in subEle.Elements())
				{
					ActivateParent tempXAPR = new ActivateParent();
					tempXAPR.ReadXML(e, master);
					ActivateParents.Add(tempXAPR);
				}
			}
			if (ele.TryPathTo("ActivationPrompt", false, out subEle))
			{
				if (ActivationPrompt == null)
					ActivationPrompt = new SimpleSubrecord<String>();
					
				ActivationPrompt.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnableParent", false, out subEle))
			{
				if (EnableParent == null)
					EnableParent = new EnableParent();
					
				EnableParent.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Emittance", false, out subEle))
			{
				if (Emittance == null)
					Emittance = new RecordReference();
					
				Emittance.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MultiBound", false, out subEle))
			{
				if (MultiBound == null)
					MultiBound = new RecordReference();
					
				MultiBound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IgnoredBySandbox", false, out subEle))
			{
				if (IgnoredBySandbox == null)
					IgnoredBySandbox = new SubMarker();
					
				IgnoredBySandbox.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Scale", false, out subEle))
			{
				if (Scale == null)
					Scale = new SimpleSubrecord<Single>();
					
				Scale.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PositionRotation", false, out subEle))
			{
				if (PositionRotation == null)
					PositionRotation = new PositionRotation();
					
				PositionRotation.ReadXML(subEle, master);
			}
		}		

		public PlacedGrenade Clone()
		{
			return new PlacedGrenade(this);
		}

	}
}