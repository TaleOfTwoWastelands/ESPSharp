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
	public partial class AnimationSound : Subrecord, ICloneable<AnimationSound>, IReferenceContainer
	{
		public FormID Sound { get; set; }
		public Byte Chance { get; set; }
		public AnimationSoundType Type { get; set; }

		public AnimationSound()
		{
			Sound = new FormID();
			Chance = new Byte();
			Type = new AnimationSoundType();
		}

		public AnimationSound(FormID Sound, Byte Chance, AnimationSoundType Type)
		{
			this.Sound = Sound;
			this.Chance = Chance;
			this.Type = Type;
		}

		public AnimationSound(AnimationSound copyObject)
		{
			Sound = copyObject.Sound.Clone();
			Chance = copyObject.Chance;
			Type = copyObject.Type;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Sound.ReadBinary(subReader);
					Chance = subReader.ReadByte();
					Type = subReader.ReadEnum<AnimationSoundType>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Sound.WriteBinary(writer);
			writer.Write(Chance);			
			writer.Write((Int32)Type);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle);

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Sound", false, out subEle))
			{
				Sound.ReadXML(subEle);
			}

			if (ele.TryPathTo("Chance", false, out subEle))
			{
				Chance = subEle.ToByte();
			}

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<AnimationSoundType>();
			}
		}

		public AnimationSound Clone()
		{
			return new AnimationSound(this);
		}
	}
}
