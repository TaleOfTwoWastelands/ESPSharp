
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
	public partial class Reference : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public LinkedReferenceColor Unknown1 { get; set; }
		public RecordReference Base { get; set; }
		public RecordReference EncounterZone { get; set; }
		public SimpleSubrecord<Byte[]> RagdollData { get; set; }
		public SimpleSubrecord<Byte[]> RagdollBipedData { get; set; }
		public PrimitiveData Primitive { get; set; }
		public SimpleSubrecord<CollisionLayer> CollisionLayer { get; set; }
		public SubMarker MultiboundPrimitiveMarker { get; set; }
		public BoundHalfExtents BoundHalfExtents { get; set; }
		public TeleportDestinationData TeleportDestination { get; set; }
		public MapMarker MapMarker { get; set; }
		public ReferenceAudio Audio { get; set; }
		public SimpleSubrecord<Byte[]> Unknown2 { get; set; }
		public SimpleSubrecord<Byte[]> Unknown3 { get; set; }
		public RecordReference Target { get; set; }
		public SimpleSubrecord<Int32> LevelModifier { get; set; }
		public ReferencePatrolData Patrol { get; set; }
		public RadioData Radio { get; set; }
		public RecordReference Owner { get; set; }
		public SimpleSubrecord<Int32> FactionRank { get; set; }
		public LockData Lock { get; set; }
		public SimpleSubrecord<Int32> Count { get; set; }
		public SimpleSubrecord<Single> Radius { get; set; }
		public SimpleSubrecord<Single> Health { get; set; }
		public SimpleSubrecord<Single> Radiation { get; set; }
		public SimpleSubrecord<Single> Charge { get; set; }
		public ReferenceAmmo Ammo { get; set; }
		public List<WaterReflection> WaterReflections { get; set; }
		public List<RecordReference> LitWaters { get; set; }
		public List<SimpleSubrecord<Byte[]>> Decals { get; set; }
		public RecordReference LinkedReference { get; set; }
		public LinkedReferenceColor LinkedReferenceColor { get; set; }
		public SimpleSubrecord<NoYesByte> ParentActivateOnly { get; set; }
		public List<ActivateParent> ActivateParents { get; set; }
		public SimpleSubrecord<String> ActivationPrompt { get; set; }
		public EnableParent EnableParent { get; set; }
		public RecordReference Emittance { get; set; }
		public RecordReference MultiBound { get; set; }
		public SimpleSubrecord<ActionFlags> ActionFlags { get; set; }
		public SubMarker OpenByDefault { get; set; }
		public SubMarker IgnoredBySandbox { get; set; }
		public NavigationDoorLink NavigationDoorLink { get; set; }
		public FormArray PortalRooms { get; set; }
		public PlaneData PortalData { get; set; }
		public SimpleSubrecord<Byte> SpeedTreeSeed { get; set; }
		public RoomDataHeader RoomDataHeader { get; set; }
		public RecordReference LinkedRoom { get; set; }
		public PlaneData OcclusionPlaneData { get; set; }
		public LinkedOcclusionPlanes LinkedOcclusionPlanes { get; set; }
		public SimpleSubrecord<Byte[]> DistantLODData { get; set; }
		public SimpleSubrecord<Single> Scale { get; set; }
		public PositionRotation PositionRotation { get; set; }

		public Reference()
		{
					}

		public Reference(SimpleSubrecord<String> EditorID, LinkedReferenceColor Unknown1, RecordReference Base, RecordReference EncounterZone, SimpleSubrecord<Byte[]> RagdollData, SimpleSubrecord<Byte[]> RagdollBipedData, PrimitiveData Primitive, SimpleSubrecord<CollisionLayer> CollisionLayer, SubMarker MultiboundPrimitiveMarker, BoundHalfExtents BoundHalfExtents, TeleportDestinationData TeleportDestination, MapMarker MapMarker, ReferenceAudio Audio, SimpleSubrecord<Byte[]> Unknown2, SimpleSubrecord<Byte[]> Unknown3, RecordReference Target, SimpleSubrecord<Int32> LevelModifier, ReferencePatrolData Patrol, RadioData Radio, RecordReference Owner, SimpleSubrecord<Int32> FactionRank, LockData Lock, SimpleSubrecord<Int32> Count, SimpleSubrecord<Single> Radius, SimpleSubrecord<Single> Health, SimpleSubrecord<Single> Radiation, SimpleSubrecord<Single> Charge, ReferenceAmmo Ammo, List<WaterReflection> WaterReflections, List<RecordReference> LitWaters, List<SimpleSubrecord<Byte[]>> Decals, RecordReference LinkedReference, LinkedReferenceColor LinkedReferenceColor, SimpleSubrecord<NoYesByte> ParentActivateOnly, List<ActivateParent> ActivateParents, SimpleSubrecord<String> ActivationPrompt, EnableParent EnableParent, RecordReference Emittance, RecordReference MultiBound, SimpleSubrecord<ActionFlags> ActionFlags, SubMarker OpenByDefault, SubMarker IgnoredBySandbox, NavigationDoorLink NavigationDoorLink, FormArray PortalRooms, PlaneData PortalData, SimpleSubrecord<Byte> SpeedTreeSeed, RoomDataHeader RoomDataHeader, RecordReference LinkedRoom, PlaneData OcclusionPlaneData, LinkedOcclusionPlanes LinkedOcclusionPlanes, SimpleSubrecord<Byte[]> DistantLODData, SimpleSubrecord<Single> Scale, PositionRotation PositionRotation)
		{
					}

		public Reference(Reference copyObject)
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
					case "RCLR":
						if (Unknown1 == null)
							Unknown1 = new LinkedReferenceColor();

						Unknown1.ReadBinary(reader);
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
					case "XPRM":
						if (Primitive == null)
							Primitive = new PrimitiveData();

						Primitive.ReadBinary(reader);
						break;
					case "XTRI":
						if (CollisionLayer == null)
							CollisionLayer = new SimpleSubrecord<CollisionLayer>();

						CollisionLayer.ReadBinary(reader);
						break;
					case "XMBP":
						if (MultiboundPrimitiveMarker == null)
							MultiboundPrimitiveMarker = new SubMarker();

						MultiboundPrimitiveMarker.ReadBinary(reader);
						break;
					case "XMBO":
						if (BoundHalfExtents == null)
							BoundHalfExtents = new BoundHalfExtents();

						BoundHalfExtents.ReadBinary(reader);
						break;
					case "XTEL":
						if (TeleportDestination == null)
							TeleportDestination = new TeleportDestinationData();

						TeleportDestination.ReadBinary(reader);
						break;
					case "XMRK":
						if (MapMarker == null)
							MapMarker = new MapMarker();

						MapMarker.ReadBinary(reader);
						break;
					case "MMRK":
						if (Audio == null)
							Audio = new ReferenceAudio();

						Audio.ReadBinary(reader);
						break;
					case "XSRF":
						if (Unknown2 == null)
							Unknown2 = new SimpleSubrecord<Byte[]>();

						Unknown2.ReadBinary(reader);
						break;
					case "XSRD":
						if (Unknown3 == null)
							Unknown3 = new SimpleSubrecord<Byte[]>();

						Unknown3.ReadBinary(reader);
						break;
					case "XTRG":
						if (Target == null)
							Target = new RecordReference();

						Target.ReadBinary(reader);
						break;
					case "XLCM":
						if (LevelModifier == null)
							LevelModifier = new SimpleSubrecord<Int32>();

						LevelModifier.ReadBinary(reader);
						break;
					case "XPRD":
						if (Patrol == null)
							Patrol = new ReferencePatrolData();

						Patrol.ReadBinary(reader);
						break;
					case "XRDO":
						if (Radio == null)
							Radio = new RadioData();

						Radio.ReadBinary(reader);
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
					case "XLOC":
						if (Lock == null)
							Lock = new LockData();

						Lock.ReadBinary(reader);
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
					case "XRAD":
						if (Radiation == null)
							Radiation = new SimpleSubrecord<Single>();

						Radiation.ReadBinary(reader);
						break;
					case "XCHG":
						if (Charge == null)
							Charge = new SimpleSubrecord<Single>();

						Charge.ReadBinary(reader);
						break;
					case "XAMT":
						if (Ammo == null)
							Ammo = new ReferenceAmmo();

						Ammo.ReadBinary(reader);
						break;
					case "XPWR":
						if (WaterReflections == null)
							WaterReflections = new List<WaterReflection>();

						WaterReflection tempXPWR = new WaterReflection();
						tempXPWR.ReadBinary(reader);
						WaterReflections.Add(tempXPWR);
						break;
					case "XLTW":
						if (LitWaters == null)
							LitWaters = new List<RecordReference>();

						RecordReference tempXLTW = new RecordReference();
						tempXLTW.ReadBinary(reader);
						LitWaters.Add(tempXLTW);
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
					case "XACT":
						if (ActionFlags == null)
							ActionFlags = new SimpleSubrecord<ActionFlags>();

						ActionFlags.ReadBinary(reader);
						break;
					case "ONAM":
						if (OpenByDefault == null)
							OpenByDefault = new SubMarker();

						OpenByDefault.ReadBinary(reader);
						break;
					case "XIBS":
						if (IgnoredBySandbox == null)
							IgnoredBySandbox = new SubMarker();

						IgnoredBySandbox.ReadBinary(reader);
						break;
					case "XNDP":
						if (NavigationDoorLink == null)
							NavigationDoorLink = new NavigationDoorLink();

						NavigationDoorLink.ReadBinary(reader);
						break;
					case "XPOD":
						if (PortalRooms == null)
							PortalRooms = new FormArray();

						PortalRooms.ReadBinary(reader);
						break;
					case "XPTL":
						if (PortalData == null)
							PortalData = new PlaneData();

						PortalData.ReadBinary(reader);
						break;
					case "XSED":
						if (SpeedTreeSeed == null)
							SpeedTreeSeed = new SimpleSubrecord<Byte>();

						SpeedTreeSeed.ReadBinary(reader);
						break;
					case "XRMR":
						if (RoomDataHeader == null)
							RoomDataHeader = new RoomDataHeader();

						RoomDataHeader.ReadBinary(reader);
						break;
					case "XLRM":
						if (LinkedRoom == null)
							LinkedRoom = new RecordReference();

						LinkedRoom.ReadBinary(reader);
						break;
					case "XOCP":
						if (OcclusionPlaneData == null)
							OcclusionPlaneData = new PlaneData();

						OcclusionPlaneData.ReadBinary(reader);
						break;
					case "XORD":
						if (LinkedOcclusionPlanes == null)
							LinkedOcclusionPlanes = new LinkedOcclusionPlanes();

						LinkedOcclusionPlanes.ReadBinary(reader);
						break;
					case "XLOD":
						if (DistantLODData == null)
							DistantLODData = new SimpleSubrecord<Byte[]>();

						DistantLODData.ReadBinary(reader);
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
			if (Unknown1 != null)
				Unknown1.WriteBinary(writer);
			if (Base != null)
				Base.WriteBinary(writer);
			if (EncounterZone != null)
				EncounterZone.WriteBinary(writer);
			if (RagdollData != null)
				RagdollData.WriteBinary(writer);
			if (RagdollBipedData != null)
				RagdollBipedData.WriteBinary(writer);
			if (Primitive != null)
				Primitive.WriteBinary(writer);
			if (CollisionLayer != null)
				CollisionLayer.WriteBinary(writer);
			if (MultiboundPrimitiveMarker != null)
				MultiboundPrimitiveMarker.WriteBinary(writer);
			if (BoundHalfExtents != null)
				BoundHalfExtents.WriteBinary(writer);
			if (TeleportDestination != null)
				TeleportDestination.WriteBinary(writer);
			if (MapMarker != null)
				MapMarker.WriteBinary(writer);
			if (Audio != null)
				Audio.WriteBinary(writer);
			if (Unknown2 != null)
				Unknown2.WriteBinary(writer);
			if (Unknown3 != null)
				Unknown3.WriteBinary(writer);
			if (Target != null)
				Target.WriteBinary(writer);
			if (LevelModifier != null)
				LevelModifier.WriteBinary(writer);
			if (Patrol != null)
				Patrol.WriteBinary(writer);
			if (Radio != null)
				Radio.WriteBinary(writer);
			if (Owner != null)
				Owner.WriteBinary(writer);
			if (FactionRank != null)
				FactionRank.WriteBinary(writer);
			if (Lock != null)
				Lock.WriteBinary(writer);
			if (Count != null)
				Count.WriteBinary(writer);
			if (Radius != null)
				Radius.WriteBinary(writer);
			if (Health != null)
				Health.WriteBinary(writer);
			if (Radiation != null)
				Radiation.WriteBinary(writer);
			if (Charge != null)
				Charge.WriteBinary(writer);
			if (Ammo != null)
				Ammo.WriteBinary(writer);
			if (WaterReflections != null)
				foreach (var item in WaterReflections)
					item.WriteBinary(writer);
			if (LitWaters != null)
				foreach (var item in LitWaters)
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
			if (ActionFlags != null)
				ActionFlags.WriteBinary(writer);
			if (OpenByDefault != null)
				OpenByDefault.WriteBinary(writer);
			if (IgnoredBySandbox != null)
				IgnoredBySandbox.WriteBinary(writer);
			if (NavigationDoorLink != null)
				NavigationDoorLink.WriteBinary(writer);
			if (PortalRooms != null)
				PortalRooms.WriteBinary(writer);
			if (PortalData != null)
				PortalData.WriteBinary(writer);
			if (SpeedTreeSeed != null)
				SpeedTreeSeed.WriteBinary(writer);
			if (RoomDataHeader != null)
				RoomDataHeader.WriteBinary(writer);
			if (LinkedRoom != null)
				LinkedRoom.WriteBinary(writer);
			if (OcclusionPlaneData != null)
				OcclusionPlaneData.WriteBinary(writer);
			if (LinkedOcclusionPlanes != null)
				LinkedOcclusionPlanes.WriteBinary(writer);
			if (DistantLODData != null)
				DistantLODData.WriteBinary(writer);
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
			if (Unknown1 != null)		
			{		
				ele.TryPathTo("Unknown1", true, out subEle);
				Unknown1.WriteXML(subEle, master);
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
			if (Primitive != null)		
			{		
				ele.TryPathTo("Primitive", true, out subEle);
				Primitive.WriteXML(subEle, master);
			}
			if (CollisionLayer != null)		
			{		
				ele.TryPathTo("CollisionLayer", true, out subEle);
				CollisionLayer.WriteXML(subEle, master);
			}
			if (MultiboundPrimitiveMarker != null)		
			{		
				ele.TryPathTo("MultiboundPrimitiveMarker", true, out subEle);
				MultiboundPrimitiveMarker.WriteXML(subEle, master);
			}
			if (BoundHalfExtents != null)		
			{		
				ele.TryPathTo("BoundHalfExtents", true, out subEle);
				BoundHalfExtents.WriteXML(subEle, master);
			}
			if (TeleportDestination != null)		
			{		
				ele.TryPathTo("TeleportDestination", true, out subEle);
				TeleportDestination.WriteXML(subEle, master);
			}
			if (MapMarker != null)		
			{		
				ele.TryPathTo("MapMarker", true, out subEle);
				MapMarker.WriteXML(subEle, master);
			}
			if (Audio != null)		
			{		
				ele.TryPathTo("Audio", true, out subEle);
				Audio.WriteXML(subEle, master);
			}
			if (Unknown2 != null)		
			{		
				ele.TryPathTo("Unknown2", true, out subEle);
				Unknown2.WriteXML(subEle, master);
			}
			if (Unknown3 != null)		
			{		
				ele.TryPathTo("Unknown3", true, out subEle);
				Unknown3.WriteXML(subEle, master);
			}
			if (Target != null)		
			{		
				ele.TryPathTo("Target", true, out subEle);
				Target.WriteXML(subEle, master);
			}
			if (LevelModifier != null)		
			{		
				ele.TryPathTo("LevelModifier", true, out subEle);
				LevelModifier.WriteXML(subEle, master);
			}
			if (Patrol != null)		
			{		
				ele.TryPathTo("Patrol", true, out subEle);
				Patrol.WriteXML(subEle, master);
			}
			if (Radio != null)		
			{		
				ele.TryPathTo("Radio", true, out subEle);
				Radio.WriteXML(subEle, master);
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
			if (Lock != null)		
			{		
				ele.TryPathTo("Lock", true, out subEle);
				Lock.WriteXML(subEle, master);
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
			if (Radiation != null)		
			{		
				ele.TryPathTo("Radiation", true, out subEle);
				Radiation.WriteXML(subEle, master);
			}
			if (Charge != null)		
			{		
				ele.TryPathTo("Charge", true, out subEle);
				Charge.WriteXML(subEle, master);
			}
			if (Ammo != null)		
			{		
				ele.TryPathTo("Ammo", true, out subEle);
				Ammo.WriteXML(subEle, master);
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
			if (LitWaters != null)		
			{		
				ele.TryPathTo("LitWaters", true, out subEle);
				List<string> xmlNames = new List<string>{"LitWater"};
				int i = 0;
				foreach (var entry in LitWaters)
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
			if (ActionFlags != null)		
			{		
				ele.TryPathTo("ActionFlags", true, out subEle);
				ActionFlags.WriteXML(subEle, master);
			}
			if (OpenByDefault != null)		
			{		
				ele.TryPathTo("OpenByDefault", true, out subEle);
				OpenByDefault.WriteXML(subEle, master);
			}
			if (IgnoredBySandbox != null)		
			{		
				ele.TryPathTo("IgnoredBySandbox", true, out subEle);
				IgnoredBySandbox.WriteXML(subEle, master);
			}
			if (NavigationDoorLink != null)		
			{		
				ele.TryPathTo("NavigationDoorLink", true, out subEle);
				NavigationDoorLink.WriteXML(subEle, master);
			}
			if (PortalRooms != null)		
			{		
				ele.TryPathTo("PortalRooms", true, out subEle);
				PortalRooms.WriteXML(subEle, master);
			}
			if (PortalData != null)		
			{		
				ele.TryPathTo("PortalData", true, out subEle);
				PortalData.WriteXML(subEle, master);
			}
			if (SpeedTreeSeed != null)		
			{		
				ele.TryPathTo("SpeedTreeSeed", true, out subEle);
				SpeedTreeSeed.WriteXML(subEle, master);
			}
			if (RoomDataHeader != null)		
			{		
				ele.TryPathTo("RoomDataHeader", true, out subEle);
				RoomDataHeader.WriteXML(subEle, master);
			}
			if (LinkedRoom != null)		
			{		
				ele.TryPathTo("LinkedRoom", true, out subEle);
				LinkedRoom.WriteXML(subEle, master);
			}
			if (OcclusionPlaneData != null)		
			{		
				ele.TryPathTo("OcclusionPlaneData", true, out subEle);
				OcclusionPlaneData.WriteXML(subEle, master);
			}
			if (LinkedOcclusionPlanes != null)		
			{		
				ele.TryPathTo("LinkedOcclusionPlanes", true, out subEle);
				LinkedOcclusionPlanes.WriteXML(subEle, master);
			}
			if (DistantLODData != null)		
			{		
				ele.TryPathTo("DistantLODData", true, out subEle);
				DistantLODData.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Unknown1", false, out subEle))
			{
				if (Unknown1 == null)
					Unknown1 = new LinkedReferenceColor();
					
				Unknown1.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Primitive", false, out subEle))
			{
				if (Primitive == null)
					Primitive = new PrimitiveData();
					
				Primitive.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CollisionLayer", false, out subEle))
			{
				if (CollisionLayer == null)
					CollisionLayer = new SimpleSubrecord<CollisionLayer>();
					
				CollisionLayer.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MultiboundPrimitiveMarker", false, out subEle))
			{
				if (MultiboundPrimitiveMarker == null)
					MultiboundPrimitiveMarker = new SubMarker();
					
				MultiboundPrimitiveMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("BoundHalfExtents", false, out subEle))
			{
				if (BoundHalfExtents == null)
					BoundHalfExtents = new BoundHalfExtents();
					
				BoundHalfExtents.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TeleportDestination", false, out subEle))
			{
				if (TeleportDestination == null)
					TeleportDestination = new TeleportDestinationData();
					
				TeleportDestination.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("MapMarker", false, out subEle))
			{
				if (MapMarker == null)
					MapMarker = new MapMarker();
					
				MapMarker.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Audio", false, out subEle))
			{
				if (Audio == null)
					Audio = new ReferenceAudio();
					
				Audio.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown2", false, out subEle))
			{
				if (Unknown2 == null)
					Unknown2 = new SimpleSubrecord<Byte[]>();
					
				Unknown2.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown3", false, out subEle))
			{
				if (Unknown3 == null)
					Unknown3 = new SimpleSubrecord<Byte[]>();
					
				Unknown3.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Target", false, out subEle))
			{
				if (Target == null)
					Target = new RecordReference();
					
				Target.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LevelModifier", false, out subEle))
			{
				if (LevelModifier == null)
					LevelModifier = new SimpleSubrecord<Int32>();
					
				LevelModifier.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Patrol", false, out subEle))
			{
				if (Patrol == null)
					Patrol = new ReferencePatrolData();
					
				Patrol.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Radio", false, out subEle))
			{
				if (Radio == null)
					Radio = new RadioData();
					
				Radio.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Lock", false, out subEle))
			{
				if (Lock == null)
					Lock = new LockData();
					
				Lock.ReadXML(subEle, master);
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
			if (ele.TryPathTo("Radiation", false, out subEle))
			{
				if (Radiation == null)
					Radiation = new SimpleSubrecord<Single>();
					
				Radiation.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Charge", false, out subEle))
			{
				if (Charge == null)
					Charge = new SimpleSubrecord<Single>();
					
				Charge.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Ammo", false, out subEle))
			{
				if (Ammo == null)
					Ammo = new ReferenceAmmo();
					
				Ammo.ReadXML(subEle, master);
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
			if (ele.TryPathTo("LitWaters", false, out subEle))
			{
				if (LitWaters == null)
					LitWaters = new List<RecordReference>();
					
				foreach (XElement e in subEle.Elements())
				{
					RecordReference tempXLTW = new RecordReference();
					tempXLTW.ReadXML(e, master);
					LitWaters.Add(tempXLTW);
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
			if (ele.TryPathTo("ActionFlags", false, out subEle))
			{
				if (ActionFlags == null)
					ActionFlags = new SimpleSubrecord<ActionFlags>();
					
				ActionFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OpenByDefault", false, out subEle))
			{
				if (OpenByDefault == null)
					OpenByDefault = new SubMarker();
					
				OpenByDefault.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("IgnoredBySandbox", false, out subEle))
			{
				if (IgnoredBySandbox == null)
					IgnoredBySandbox = new SubMarker();
					
				IgnoredBySandbox.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NavigationDoorLink", false, out subEle))
			{
				if (NavigationDoorLink == null)
					NavigationDoorLink = new NavigationDoorLink();
					
				NavigationDoorLink.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PortalRooms", false, out subEle))
			{
				if (PortalRooms == null)
					PortalRooms = new FormArray();
					
				PortalRooms.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PortalData", false, out subEle))
			{
				if (PortalData == null)
					PortalData = new PlaneData();
					
				PortalData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("SpeedTreeSeed", false, out subEle))
			{
				if (SpeedTreeSeed == null)
					SpeedTreeSeed = new SimpleSubrecord<Byte>();
					
				SpeedTreeSeed.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RoomDataHeader", false, out subEle))
			{
				if (RoomDataHeader == null)
					RoomDataHeader = new RoomDataHeader();
					
				RoomDataHeader.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LinkedRoom", false, out subEle))
			{
				if (LinkedRoom == null)
					LinkedRoom = new RecordReference();
					
				LinkedRoom.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("OcclusionPlaneData", false, out subEle))
			{
				if (OcclusionPlaneData == null)
					OcclusionPlaneData = new PlaneData();
					
				OcclusionPlaneData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LinkedOcclusionPlanes", false, out subEle))
			{
				if (LinkedOcclusionPlanes == null)
					LinkedOcclusionPlanes = new LinkedOcclusionPlanes();
					
				LinkedOcclusionPlanes.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DistantLODData", false, out subEle))
			{
				if (DistantLODData == null)
					DistantLODData = new SimpleSubrecord<Byte[]>();
					
				DistantLODData.ReadXML(subEle, master);
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

		public Reference Clone()
		{
			return new Reference(this);
		}

	}
}