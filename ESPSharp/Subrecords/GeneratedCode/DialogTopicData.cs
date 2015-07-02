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
	public partial class DialogTopicData : Subrecord, ICloneable<DialogTopicData>
	{
		public DialogType Type { get; set; }
		public DialogFlags Flags { get; set; }

		public DialogTopicData()
		{
			Type = new DialogType();
			Flags = new DialogFlags();
		}

		public DialogTopicData(DialogType Type, DialogFlags Flags)
		{
			this.Type = Type;
			this.Flags = Flags;
		}

		public DialogTopicData(DialogTopicData copyObject)
		{
			Type = copyObject.Type;
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Type = subReader.ReadEnum<DialogType>();
					Flags = subReader.ReadEnum<DialogFlags>();
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
			writer.Write((Byte)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Type", false, out subEle))
			{
				Type = subEle.ToEnum<DialogType>();
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<DialogFlags>();
			}
		}

		public DialogTopicData Clone()
		{
			return new DialogTopicData(this);
		}

	}
}
