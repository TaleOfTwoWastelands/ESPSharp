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
	public partial class QuestTargetData : Subrecord, ICloneable<QuestTargetData>, IReferenceContainer
	{
		public FormID Target { get; set; }
		public QuestTargetFlags Flags { get; set; }
		public Byte[] Unused { get; set; }

		public QuestTargetData()
		{
			Target = new FormID();
			Flags = new QuestTargetFlags();
			Unused = new byte[3];
		}

		public QuestTargetData(FormID Target, QuestTargetFlags Flags, Byte[] Unused)
		{
			this.Target = Target;
			this.Flags = Flags;
			this.Unused = Unused;
		}

		public QuestTargetData(QuestTargetData copyObject)
		{
			Target = copyObject.Target.Clone();
			Flags = copyObject.Flags;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Target.ReadBinary(subReader);
					Flags = subReader.ReadEnum<QuestTargetFlags>();
					Unused = subReader.ReadBytes(3);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Target.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Target", true, out subEle);
			Target.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Target", false, out subEle))
			{
				Target.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<QuestTargetFlags>();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public QuestTargetData Clone()
		{
			return new QuestTargetData(this);
		}

	}
}
