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
	public partial class DialogResponseData : Subrecord, ICloneable<DialogResponseData>
	{
		public DialogResponseType Type { get; set; }
		public NextSpeaker NextSpeaker { get; set; }
		public DialogResponseFlags Flags { get; set; }

		public DialogResponseData()
		{
			Type = new DialogResponseType();
			NextSpeaker = new NextSpeaker();
			Flags = new DialogResponseFlags();
		}

		public DialogResponseData(DialogResponseType Type, NextSpeaker NextSpeaker, DialogResponseFlags Flags)
		{
			this.Type = Type;
			this.NextSpeaker = NextSpeaker;
			this.Flags = Flags;
		}

		public DialogResponseData(DialogResponseData copyObject)
		{
			Type = copyObject.Type;
			NextSpeaker = copyObject.NextSpeaker;
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<DialogResponseType>();
					NextSpeaker = subReader.ReadEnum<NextSpeaker>();
					Flags = subReader.ReadEnum<DialogResponseFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Type);
			writer.Write((Byte)NextSpeaker);
			writer.Write((UInt16)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("NextSpeaker", true, out subEle);
			subEle.Value = NextSpeaker.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<DialogResponseType>();
			}

			if (ele.TryPathTo("NextSpeaker", false, out subEle))
			{
				NextSpeaker = subEle.ToEnum<NextSpeaker>();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<DialogResponseFlags>();
			}
		}

		public DialogResponseData Clone()
		{
			return new DialogResponseData(this);
		}

	}
}
