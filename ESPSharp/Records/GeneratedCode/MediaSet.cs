
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
	public partial class MediaSet : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public SimpleSubrecord<MediaSetType> Type { get; set; }
		public SimpleSubrecord<String> Loop_Battle_DayOuter { get; set; }
		public SimpleSubrecord<String> Explore_DayMiddle { get; set; }
		public SimpleSubrecord<String> Suspense_DayInner { get; set; }
		public SimpleSubrecord<String> NightOuter { get; set; }
		public SimpleSubrecord<String> NightMiddle { get; set; }
		public SimpleSubrecord<String> NightInner { get; set; }
		public SimpleSubrecord<Single> DecibelLoop_Battle_DayOuter { get; set; }
		public SimpleSubrecord<Single> DecibelExplore_DayMiddle { get; set; }
		public SimpleSubrecord<Single> DecibelSuspense_DayInner { get; set; }
		public SimpleSubrecord<Single> DecibelNightOuter { get; set; }
		public SimpleSubrecord<Single> DecibelNightMiddle { get; set; }
		public SimpleSubrecord<Single> DecibelNightInner { get; set; }
		public SimpleSubrecord<Single> DayOuterBoundary { get; set; }
		public SimpleSubrecord<Single> DayMiddleBoundary { get; set; }
		public SimpleSubrecord<Single> DayInnerBoundary { get; set; }
		public SimpleSubrecord<Single> NightOuterBoundary { get; set; }
		public SimpleSubrecord<Single> NightMiddleBoundary { get; set; }
		public SimpleSubrecord<Single> NightInnerBoundary { get; set; }
		public SimpleSubrecord<MediaSetEnableFlags> EnableFlags { get; set; }
		public SimpleSubrecord<Single> WaitTime_MinTimeOn_DaytimeMin { get; set; }
		public SimpleSubrecord<Single> LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin { get; set; }
		public SimpleSubrecord<Single> RecoveryTime_LayerCrossfadeTime_DaytimeMax { get; set; }
		public SimpleSubrecord<Single> NighttimeMax { get; set; }
		public RecordReference Intro_Daytime { get; set; }
		public RecordReference Outro_Nighttime { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }

		public MediaSet()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
		}

		public MediaSet(SimpleSubrecord<String> EditorID, SimpleSubrecord<String> Name, SimpleSubrecord<MediaSetType> Type, SimpleSubrecord<String> Loop_Battle_DayOuter, SimpleSubrecord<String> Explore_DayMiddle, SimpleSubrecord<String> Suspense_DayInner, SimpleSubrecord<String> NightOuter, SimpleSubrecord<String> NightMiddle, SimpleSubrecord<String> NightInner, SimpleSubrecord<Single> DecibelLoop_Battle_DayOuter, SimpleSubrecord<Single> DecibelExplore_DayMiddle, SimpleSubrecord<Single> DecibelSuspense_DayInner, SimpleSubrecord<Single> DecibelNightOuter, SimpleSubrecord<Single> DecibelNightMiddle, SimpleSubrecord<Single> DecibelNightInner, SimpleSubrecord<Single> DayOuterBoundary, SimpleSubrecord<Single> DayMiddleBoundary, SimpleSubrecord<Single> DayInnerBoundary, SimpleSubrecord<Single> NightOuterBoundary, SimpleSubrecord<Single> NightMiddleBoundary, SimpleSubrecord<Single> NightInnerBoundary, SimpleSubrecord<MediaSetEnableFlags> EnableFlags, SimpleSubrecord<Single> WaitTime_MinTimeOn_DaytimeMin, SimpleSubrecord<Single> LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin, SimpleSubrecord<Single> RecoveryTime_LayerCrossfadeTime_DaytimeMax, SimpleSubrecord<Single> NighttimeMax, RecordReference Intro_Daytime, RecordReference Outro_Nighttime, SimpleSubrecord<Byte[]> Unknown)
		{
			this.EditorID = EditorID;
		}

		public MediaSet(MediaSet copyObject)
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
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "NAM1":
						if (Type == null)
							Type = new SimpleSubrecord<MediaSetType>();

						Type.ReadBinary(reader);
						break;
					case "NAM2":
						if (Loop_Battle_DayOuter == null)
							Loop_Battle_DayOuter = new SimpleSubrecord<String>();

						Loop_Battle_DayOuter.ReadBinary(reader);
						break;
					case "NAM3":
						if (Explore_DayMiddle == null)
							Explore_DayMiddle = new SimpleSubrecord<String>();

						Explore_DayMiddle.ReadBinary(reader);
						break;
					case "NAM4":
						if (Suspense_DayInner == null)
							Suspense_DayInner = new SimpleSubrecord<String>();

						Suspense_DayInner.ReadBinary(reader);
						break;
					case "NAM5":
						if (NightOuter == null)
							NightOuter = new SimpleSubrecord<String>();

						NightOuter.ReadBinary(reader);
						break;
					case "NAM6":
						if (NightMiddle == null)
							NightMiddle = new SimpleSubrecord<String>();

						NightMiddle.ReadBinary(reader);
						break;
					case "NAM7":
						if (NightInner == null)
							NightInner = new SimpleSubrecord<String>();

						NightInner.ReadBinary(reader);
						break;
					case "NAM8":
						if (DecibelLoop_Battle_DayOuter == null)
							DecibelLoop_Battle_DayOuter = new SimpleSubrecord<Single>();

						DecibelLoop_Battle_DayOuter.ReadBinary(reader);
						break;
					case "NAM9":
						if (DecibelExplore_DayMiddle == null)
							DecibelExplore_DayMiddle = new SimpleSubrecord<Single>();

						DecibelExplore_DayMiddle.ReadBinary(reader);
						break;
					case "NAM0":
						if (DecibelSuspense_DayInner == null)
							DecibelSuspense_DayInner = new SimpleSubrecord<Single>();

						DecibelSuspense_DayInner.ReadBinary(reader);
						break;
					case "ANAM":
						if (DecibelNightOuter == null)
							DecibelNightOuter = new SimpleSubrecord<Single>();

						DecibelNightOuter.ReadBinary(reader);
						break;
					case "BNAM":
						if (DecibelNightMiddle == null)
							DecibelNightMiddle = new SimpleSubrecord<Single>();

						DecibelNightMiddle.ReadBinary(reader);
						break;
					case "CNAM":
						if (DecibelNightInner == null)
							DecibelNightInner = new SimpleSubrecord<Single>();

						DecibelNightInner.ReadBinary(reader);
						break;
					case "JNAM":
						if (DayOuterBoundary == null)
							DayOuterBoundary = new SimpleSubrecord<Single>();

						DayOuterBoundary.ReadBinary(reader);
						break;
					case "KNAM":
						if (DayMiddleBoundary == null)
							DayMiddleBoundary = new SimpleSubrecord<Single>();

						DayMiddleBoundary.ReadBinary(reader);
						break;
					case "LNAM":
						if (DayInnerBoundary == null)
							DayInnerBoundary = new SimpleSubrecord<Single>();

						DayInnerBoundary.ReadBinary(reader);
						break;
					case "MNAM":
						if (NightOuterBoundary == null)
							NightOuterBoundary = new SimpleSubrecord<Single>();

						NightOuterBoundary.ReadBinary(reader);
						break;
					case "NNAM":
						if (NightMiddleBoundary == null)
							NightMiddleBoundary = new SimpleSubrecord<Single>();

						NightMiddleBoundary.ReadBinary(reader);
						break;
					case "ONAM":
						if (NightInnerBoundary == null)
							NightInnerBoundary = new SimpleSubrecord<Single>();

						NightInnerBoundary.ReadBinary(reader);
						break;
					case "PNAM":
						if (EnableFlags == null)
							EnableFlags = new SimpleSubrecord<MediaSetEnableFlags>();

						EnableFlags.ReadBinary(reader);
						break;
					case "DNAM":
						if (WaitTime_MinTimeOn_DaytimeMin == null)
							WaitTime_MinTimeOn_DaytimeMin = new SimpleSubrecord<Single>();

						WaitTime_MinTimeOn_DaytimeMin.ReadBinary(reader);
						break;
					case "ENAM":
						if (LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin == null)
							LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin = new SimpleSubrecord<Single>();

						LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin.ReadBinary(reader);
						break;
					case "FNAM":
						if (RecoveryTime_LayerCrossfadeTime_DaytimeMax == null)
							RecoveryTime_LayerCrossfadeTime_DaytimeMax = new SimpleSubrecord<Single>();

						RecoveryTime_LayerCrossfadeTime_DaytimeMax.ReadBinary(reader);
						break;
					case "GNAM":
						if (NighttimeMax == null)
							NighttimeMax = new SimpleSubrecord<Single>();

						NighttimeMax.ReadBinary(reader);
						break;
					case "HNAM":
						if (Intro_Daytime == null)
							Intro_Daytime = new RecordReference();

						Intro_Daytime.ReadBinary(reader);
						break;
					case "INAM":
						if (Outro_Nighttime == null)
							Outro_Nighttime = new RecordReference();

						Outro_Nighttime.ReadBinary(reader);
						break;
					case "DATA":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte[]>();

						Unknown.ReadBinary(reader);
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
			if (Name != null)
				Name.WriteBinary(writer);
			if (Type != null)
				Type.WriteBinary(writer);
			if (Loop_Battle_DayOuter != null)
				Loop_Battle_DayOuter.WriteBinary(writer);
			if (Explore_DayMiddle != null)
				Explore_DayMiddle.WriteBinary(writer);
			if (Suspense_DayInner != null)
				Suspense_DayInner.WriteBinary(writer);
			if (NightOuter != null)
				NightOuter.WriteBinary(writer);
			if (NightMiddle != null)
				NightMiddle.WriteBinary(writer);
			if (NightInner != null)
				NightInner.WriteBinary(writer);
			if (DecibelLoop_Battle_DayOuter != null)
				DecibelLoop_Battle_DayOuter.WriteBinary(writer);
			if (DecibelExplore_DayMiddle != null)
				DecibelExplore_DayMiddle.WriteBinary(writer);
			if (DecibelSuspense_DayInner != null)
				DecibelSuspense_DayInner.WriteBinary(writer);
			if (DecibelNightOuter != null)
				DecibelNightOuter.WriteBinary(writer);
			if (DecibelNightMiddle != null)
				DecibelNightMiddle.WriteBinary(writer);
			if (DecibelNightInner != null)
				DecibelNightInner.WriteBinary(writer);
			if (DayOuterBoundary != null)
				DayOuterBoundary.WriteBinary(writer);
			if (DayMiddleBoundary != null)
				DayMiddleBoundary.WriteBinary(writer);
			if (DayInnerBoundary != null)
				DayInnerBoundary.WriteBinary(writer);
			if (NightOuterBoundary != null)
				NightOuterBoundary.WriteBinary(writer);
			if (NightMiddleBoundary != null)
				NightMiddleBoundary.WriteBinary(writer);
			if (NightInnerBoundary != null)
				NightInnerBoundary.WriteBinary(writer);
			if (EnableFlags != null)
				EnableFlags.WriteBinary(writer);
			if (WaitTime_MinTimeOn_DaytimeMin != null)
				WaitTime_MinTimeOn_DaytimeMin.WriteBinary(writer);
			if (LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin != null)
				LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin.WriteBinary(writer);
			if (RecoveryTime_LayerCrossfadeTime_DaytimeMax != null)
				RecoveryTime_LayerCrossfadeTime_DaytimeMax.WriteBinary(writer);
			if (NighttimeMax != null)
				NighttimeMax.WriteBinary(writer);
			if (Intro_Daytime != null)
				Intro_Daytime.WriteBinary(writer);
			if (Outro_Nighttime != null)
				Outro_Nighttime.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Type != null)		
			{		
				ele.TryPathTo("Type", true, out subEle);
				Type.WriteXML(subEle, master);
			}
			if (Loop_Battle_DayOuter != null)		
			{		
				ele.TryPathTo("Loop_Battle_DayOuter", true, out subEle);
				Loop_Battle_DayOuter.WriteXML(subEle, master);
			}
			if (Explore_DayMiddle != null)		
			{		
				ele.TryPathTo("Explore_DayMiddle", true, out subEle);
				Explore_DayMiddle.WriteXML(subEle, master);
			}
			if (Suspense_DayInner != null)		
			{		
				ele.TryPathTo("Suspense_DayInner", true, out subEle);
				Suspense_DayInner.WriteXML(subEle, master);
			}
			if (NightOuter != null)		
			{		
				ele.TryPathTo("NightOuter", true, out subEle);
				NightOuter.WriteXML(subEle, master);
			}
			if (NightMiddle != null)		
			{		
				ele.TryPathTo("NightMiddle", true, out subEle);
				NightMiddle.WriteXML(subEle, master);
			}
			if (NightInner != null)		
			{		
				ele.TryPathTo("NightInner", true, out subEle);
				NightInner.WriteXML(subEle, master);
			}
			if (DecibelLoop_Battle_DayOuter != null)		
			{		
				ele.TryPathTo("Decibel/Loop_Battle_DayOuter", true, out subEle);
				DecibelLoop_Battle_DayOuter.WriteXML(subEle, master);
			}
			if (DecibelExplore_DayMiddle != null)		
			{		
				ele.TryPathTo("Decibel/Explore_DayMiddle", true, out subEle);
				DecibelExplore_DayMiddle.WriteXML(subEle, master);
			}
			if (DecibelSuspense_DayInner != null)		
			{		
				ele.TryPathTo("Decibel/Suspense_DayInner", true, out subEle);
				DecibelSuspense_DayInner.WriteXML(subEle, master);
			}
			if (DecibelNightOuter != null)		
			{		
				ele.TryPathTo("Decibel/NightOuter", true, out subEle);
				DecibelNightOuter.WriteXML(subEle, master);
			}
			if (DecibelNightMiddle != null)		
			{		
				ele.TryPathTo("Decibel/NightMiddle", true, out subEle);
				DecibelNightMiddle.WriteXML(subEle, master);
			}
			if (DecibelNightInner != null)		
			{		
				ele.TryPathTo("Decibel/NightInner", true, out subEle);
				DecibelNightInner.WriteXML(subEle, master);
			}
			if (DayOuterBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/DayOuter", true, out subEle);
				DayOuterBoundary.WriteXML(subEle, master);
			}
			if (DayMiddleBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/DayMiddle", true, out subEle);
				DayMiddleBoundary.WriteXML(subEle, master);
			}
			if (DayInnerBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/DayInner", true, out subEle);
				DayInnerBoundary.WriteXML(subEle, master);
			}
			if (NightOuterBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/NightOuter", true, out subEle);
				NightOuterBoundary.WriteXML(subEle, master);
			}
			if (NightMiddleBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/NightMiddle", true, out subEle);
				NightMiddleBoundary.WriteXML(subEle, master);
			}
			if (NightInnerBoundary != null)		
			{		
				ele.TryPathTo("Boundaries/NightInner", true, out subEle);
				NightInnerBoundary.WriteXML(subEle, master);
			}
			if (EnableFlags != null)		
			{		
				ele.TryPathTo("EnableFlags", true, out subEle);
				EnableFlags.WriteXML(subEle, master);
			}
			if (WaitTime_MinTimeOn_DaytimeMin != null)		
			{		
				ele.TryPathTo("WaitTime_MinTimeOn_DaytimeMin", true, out subEle);
				WaitTime_MinTimeOn_DaytimeMin.WriteXML(subEle, master);
			}
			if (LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin != null)		
			{		
				ele.TryPathTo("LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin", true, out subEle);
				LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin.WriteXML(subEle, master);
			}
			if (RecoveryTime_LayerCrossfadeTime_DaytimeMax != null)		
			{		
				ele.TryPathTo("RecoveryTime_LayerCrossfadeTime_DaytimeMax", true, out subEle);
				RecoveryTime_LayerCrossfadeTime_DaytimeMax.WriteXML(subEle, master);
			}
			if (NighttimeMax != null)		
			{		
				ele.TryPathTo("NighttimeMax", true, out subEle);
				NighttimeMax.WriteXML(subEle, master);
			}
			if (Intro_Daytime != null)		
			{		
				ele.TryPathTo("Intro_Daytime", true, out subEle);
				Intro_Daytime.WriteXML(subEle, master);
			}
			if (Outro_Nighttime != null)		
			{		
				ele.TryPathTo("Outro_Nighttime", true, out subEle);
				Outro_Nighttime.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
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
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Type", false, out subEle))
			{
				if (Type == null)
					Type = new SimpleSubrecord<MediaSetType>();
					
				Type.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Loop_Battle_DayOuter", false, out subEle))
			{
				if (Loop_Battle_DayOuter == null)
					Loop_Battle_DayOuter = new SimpleSubrecord<String>();
					
				Loop_Battle_DayOuter.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Explore_DayMiddle", false, out subEle))
			{
				if (Explore_DayMiddle == null)
					Explore_DayMiddle = new SimpleSubrecord<String>();
					
				Explore_DayMiddle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Suspense_DayInner", false, out subEle))
			{
				if (Suspense_DayInner == null)
					Suspense_DayInner = new SimpleSubrecord<String>();
					
				Suspense_DayInner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NightOuter", false, out subEle))
			{
				if (NightOuter == null)
					NightOuter = new SimpleSubrecord<String>();
					
				NightOuter.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NightMiddle", false, out subEle))
			{
				if (NightMiddle == null)
					NightMiddle = new SimpleSubrecord<String>();
					
				NightMiddle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NightInner", false, out subEle))
			{
				if (NightInner == null)
					NightInner = new SimpleSubrecord<String>();
					
				NightInner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/Loop_Battle_DayOuter", false, out subEle))
			{
				if (DecibelLoop_Battle_DayOuter == null)
					DecibelLoop_Battle_DayOuter = new SimpleSubrecord<Single>();
					
				DecibelLoop_Battle_DayOuter.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/Explore_DayMiddle", false, out subEle))
			{
				if (DecibelExplore_DayMiddle == null)
					DecibelExplore_DayMiddle = new SimpleSubrecord<Single>();
					
				DecibelExplore_DayMiddle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/Suspense_DayInner", false, out subEle))
			{
				if (DecibelSuspense_DayInner == null)
					DecibelSuspense_DayInner = new SimpleSubrecord<Single>();
					
				DecibelSuspense_DayInner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/NightOuter", false, out subEle))
			{
				if (DecibelNightOuter == null)
					DecibelNightOuter = new SimpleSubrecord<Single>();
					
				DecibelNightOuter.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/NightMiddle", false, out subEle))
			{
				if (DecibelNightMiddle == null)
					DecibelNightMiddle = new SimpleSubrecord<Single>();
					
				DecibelNightMiddle.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Decibel/NightInner", false, out subEle))
			{
				if (DecibelNightInner == null)
					DecibelNightInner = new SimpleSubrecord<Single>();
					
				DecibelNightInner.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/DayOuter", false, out subEle))
			{
				if (DayOuterBoundary == null)
					DayOuterBoundary = new SimpleSubrecord<Single>();
					
				DayOuterBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/DayMiddle", false, out subEle))
			{
				if (DayMiddleBoundary == null)
					DayMiddleBoundary = new SimpleSubrecord<Single>();
					
				DayMiddleBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/DayInner", false, out subEle))
			{
				if (DayInnerBoundary == null)
					DayInnerBoundary = new SimpleSubrecord<Single>();
					
				DayInnerBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/NightOuter", false, out subEle))
			{
				if (NightOuterBoundary == null)
					NightOuterBoundary = new SimpleSubrecord<Single>();
					
				NightOuterBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/NightMiddle", false, out subEle))
			{
				if (NightMiddleBoundary == null)
					NightMiddleBoundary = new SimpleSubrecord<Single>();
					
				NightMiddleBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Boundaries/NightInner", false, out subEle))
			{
				if (NightInnerBoundary == null)
					NightInnerBoundary = new SimpleSubrecord<Single>();
					
				NightInnerBoundary.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EnableFlags", false, out subEle))
			{
				if (EnableFlags == null)
					EnableFlags = new SimpleSubrecord<MediaSetEnableFlags>();
					
				EnableFlags.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("WaitTime_MinTimeOn_DaytimeMin", false, out subEle))
			{
				if (WaitTime_MinTimeOn_DaytimeMin == null)
					WaitTime_MinTimeOn_DaytimeMin = new SimpleSubrecord<Single>();
					
				WaitTime_MinTimeOn_DaytimeMin.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin", false, out subEle))
			{
				if (LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin == null)
					LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin = new SimpleSubrecord<Single>();
					
				LoopFadeOut_LoopingRandomCrossfadeOverlap_NighttimeMin.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("RecoveryTime_LayerCrossfadeTime_DaytimeMax", false, out subEle))
			{
				if (RecoveryTime_LayerCrossfadeTime_DaytimeMax == null)
					RecoveryTime_LayerCrossfadeTime_DaytimeMax = new SimpleSubrecord<Single>();
					
				RecoveryTime_LayerCrossfadeTime_DaytimeMax.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("NighttimeMax", false, out subEle))
			{
				if (NighttimeMax == null)
					NighttimeMax = new SimpleSubrecord<Single>();
					
				NighttimeMax.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Intro_Daytime", false, out subEle))
			{
				if (Intro_Daytime == null)
					Intro_Daytime = new RecordReference();
					
				Intro_Daytime.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Outro_Nighttime", false, out subEle))
			{
				if (Outro_Nighttime == null)
					Outro_Nighttime = new RecordReference();
					
				Outro_Nighttime.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
		}		

		public MediaSet Clone()
		{
			return new MediaSet(this);
		}

	}
}