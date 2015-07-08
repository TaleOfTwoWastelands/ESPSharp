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
	public partial class ResponseData : Subrecord, ICloneable<ResponseData>, IReferenceContainer
	{
		public EmotionType Emotion { get; set; }
		public Int32 EmotionValue { get; set; }
		public Byte[] Unused1 { get; set; }
		public Byte ResponseNumber { get; set; }
		public Byte[] Unused2 { get; set; }
		public FormID Sound { get; set; }
		public NoYesByte UseEmotionAnimation { get; set; }
		public Byte[] Unused3 { get; set; }

		public ResponseData()
		{
			Emotion = new EmotionType();
			EmotionValue = new Int32();
			Unused1 = new byte[4];
			ResponseNumber = new Byte();
			Unused2 = new byte[3];
			Sound = new FormID();
			UseEmotionAnimation = new NoYesByte();
			Unused3 = new byte[3];
		}

		public ResponseData(EmotionType Emotion, Int32 EmotionValue, Byte[] Unused1, Byte ResponseNumber, Byte[] Unused2, FormID Sound, NoYesByte UseEmotionAnimation, Byte[] Unused3)
		{
			this.Emotion = Emotion;
			this.EmotionValue = EmotionValue;
			this.Unused1 = Unused1;
			this.ResponseNumber = ResponseNumber;
			this.Unused2 = Unused2;
			this.Sound = Sound;
			this.UseEmotionAnimation = UseEmotionAnimation;
			this.Unused3 = Unused3;
		}

		public ResponseData(ResponseData copyObject)
		{
			Emotion = copyObject.Emotion;
			EmotionValue = copyObject.EmotionValue;
			Unused1 = (Byte[])copyObject.Unused1.Clone();
			ResponseNumber = copyObject.ResponseNumber;
			Unused2 = (Byte[])copyObject.Unused2.Clone();
			Sound = copyObject.Sound.Clone();
			UseEmotionAnimation = copyObject.UseEmotionAnimation;
			Unused3 = (Byte[])copyObject.Unused3.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Emotion = subReader.ReadEnum<EmotionType>();
					EmotionValue = subReader.ReadInt32();
					Unused1 = subReader.ReadBytes(4);
					ResponseNumber = subReader.ReadByte();
					Unused2 = subReader.ReadBytes(3);
					Sound.ReadBinary(subReader);
					UseEmotionAnimation = subReader.ReadEnum<NoYesByte>();
					Unused3 = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Emotion);
			writer.Write(EmotionValue);			
			if (Unused1 == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused1);
			writer.Write(ResponseNumber);			
			if (Unused2 == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused2);
			Sound.WriteBinary(writer);
			writer.Write((Byte)UseEmotionAnimation);
			if (Unused3 == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused3);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Emotion", true, out subEle);
			subEle.Value = Emotion.ToString();

			ele.TryPathTo("EmotionValue", true, out subEle);
			subEle.Value = EmotionValue.ToString();

			ele.TryPathTo("Unused1", true, out subEle);
			subEle.Value = Unused1.ToHex();

			ele.TryPathTo("ResponseNumber", true, out subEle);
			subEle.Value = ResponseNumber.ToString();

			ele.TryPathTo("Unused2", true, out subEle);
			subEle.Value = Unused2.ToHex();

			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("UseEmotionAnimation", true, out subEle);
			subEle.Value = UseEmotionAnimation.ToString();

			ele.TryPathTo("Unused3", true, out subEle);
			subEle.Value = Unused3.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Emotion", false, out subEle))
			{
				Emotion = subEle.ToEnum<EmotionType>();
			}

			if (ele.TryPathTo("EmotionValue", false, out subEle))
			{
				EmotionValue = subEle.ToInt32();
			}

			if (ele.TryPathTo("Unused1", false, out subEle))
			{
				Unused1 = subEle.ToBytes();
			}

			if (ele.TryPathTo("ResponseNumber", false, out subEle))
			{
				ResponseNumber = subEle.ToByte();
			}

			if (ele.TryPathTo("Unused2", false, out subEle))
			{
				Unused2 = subEle.ToBytes();
			}

			if (ele.TryPathTo("Sound", false, out subEle))
			{
				Sound.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("UseEmotionAnimation", false, out subEle))
			{
				UseEmotionAnimation = subEle.ToEnum<NoYesByte>();
			}

			if (ele.TryPathTo("Unused3", false, out subEle))
			{
				Unused3 = subEle.ToBytes();
			}
		}

		public ResponseData Clone()
		{
			return new ResponseData(this);
		}

	}
}
