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
	public partial class ActivateParent : Subrecord, ICloneable<ActivateParent>, IReferenceContainer
	{
		public FormID Parent { get; set; }
		public Single Delay { get; set; }

		public ActivateParent()
		{
			Parent = new FormID();
			Delay = new Single();
		}

		public ActivateParent(FormID Parent, Single Delay)
		{
			this.Parent = Parent;
			this.Delay = Delay;
		}

		public ActivateParent(ActivateParent copyObject)
		{
			Parent = copyObject.Parent.Clone();
			Delay = copyObject.Delay;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					Delay = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Parent.WriteBinary(writer);
			writer.Write(Delay);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("Delay", true, out subEle);
			subEle.Value = Delay.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Parent", false, out subEle))
			{
				Parent.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Delay", false, out subEle))
			{
				Delay = subEle.ToSingle();
			}
		}

		public ActivateParent Clone()
		{
			return new ActivateParent(this);
		}

	}
}
