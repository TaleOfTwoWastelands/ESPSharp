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

namespace ESPSharp.Subrecords
{
	public partial class RagdollData : Subrecord, ICloneable<RagdollData>
	{
		public UInt32 DynamicBoneCount { get; set; }
		public Byte[] Unused1 { get; set; }
		public NoYesByte FeedbackEnabled { get; set; }
		public NoYesByte FootIKEnabled { get; set; }
		public NoYesByte LookIKEnabled { get; set; }
		public NoYesByte GrabIKEnabled { get; set; }
		public NoYesByte PoseMatching { get; set; }
		public Byte Unused2 { get; set; }

		public RagdollData()
		{
			DynamicBoneCount = new UInt32();
			Unused1 = new byte[4];
			FeedbackEnabled = new NoYesByte();
			FootIKEnabled = new NoYesByte();
			LookIKEnabled = new NoYesByte();
			GrabIKEnabled = new NoYesByte();
			PoseMatching = new NoYesByte();
			Unused2 = new Byte();
		}

		public RagdollData(UInt32 DynamicBoneCount, Byte[] Unused1, NoYesByte FeedbackEnabled, NoYesByte FootIKEnabled, NoYesByte LookIKEnabled, NoYesByte GrabIKEnabled, NoYesByte PoseMatching, Byte Unused2)
		{
			this.DynamicBoneCount = DynamicBoneCount;
			this.Unused1 = Unused1;
			this.FeedbackEnabled = FeedbackEnabled;
			this.FootIKEnabled = FootIKEnabled;
			this.LookIKEnabled = LookIKEnabled;
			this.GrabIKEnabled = GrabIKEnabled;
			this.PoseMatching = PoseMatching;
			this.Unused2 = Unused2;
		}

		public RagdollData(RagdollData copyObject)
		{
			DynamicBoneCount = copyObject.DynamicBoneCount;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			FeedbackEnabled = copyObject.FeedbackEnabled;
			FootIKEnabled = copyObject.FootIKEnabled;
			LookIKEnabled = copyObject.LookIKEnabled;
			GrabIKEnabled = copyObject.GrabIKEnabled;
			PoseMatching = copyObject.PoseMatching;
			Unused2 = copyObject.Unused2;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					DynamicBoneCount = subReader.ReadUInt32();
					Unused1 = subReader.ReadBytes(4);
					FeedbackEnabled = subReader.ReadEnum<NoYesByte>();
					FootIKEnabled = subReader.ReadEnum<NoYesByte>();
					LookIKEnabled = subReader.ReadEnum<NoYesByte>();
					GrabIKEnabled = subReader.ReadEnum<NoYesByte>();
					PoseMatching = subReader.ReadEnum<NoYesByte>();
					Unused2 = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(DynamicBoneCount);			
			if (Unused1 == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused1);
			writer.Write((Byte)FeedbackEnabled);
			writer.Write((Byte)FootIKEnabled);
			writer.Write((Byte)LookIKEnabled);
			writer.Write((Byte)GrabIKEnabled);
			writer.Write((Byte)PoseMatching);
			writer.Write(Unused2);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("DynamicBoneCount", true, out subEle);
			subEle.Value = DynamicBoneCount.ToString();

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("FeedbackEnabled", true, out subEle);
			subEle.Value = FeedbackEnabled.ToString();

			ele.TryPathTo("FootIKEnabled", true, out subEle);
			subEle.Value = FootIKEnabled.ToString();

			ele.TryPathTo("LookIKEnabled", true, out subEle);
			subEle.Value = LookIKEnabled.ToString();

			ele.TryPathTo("GrabIKEnabled", true, out subEle);
			subEle.Value = GrabIKEnabled.ToString();

			ele.TryPathTo("PoseMatching", true, out subEle);
			subEle.Value = PoseMatching.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("DynamicBoneCount", false, out subEle))
			{
				DynamicBoneCount = subEle.ToUInt32();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("FeedbackEnabled", false, out subEle))
			{
				FeedbackEnabled = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("FootIKEnabled", false, out subEle))
			{
				FootIKEnabled = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("LookIKEnabled", false, out subEle))
			{
				LookIKEnabled = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("GrabIKEnabled", false, out subEle))
			{
				GrabIKEnabled = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("PoseMatching", false, out subEle))
			{
				PoseMatching = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToByte();
			}
		}

		public RagdollData Clone()
		{
			return new RagdollData(this);
		}

	}
}
