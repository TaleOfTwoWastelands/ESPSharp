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

namespace ESPSharp.DataTypes
{
	public partial class AlternateTexture : IESPSerializable, ICloneable<AlternateTexture>, IReferenceContainer
	{
		public String Name { get; set; }
		public FormID TextureSet { get; set; }
		public Int32 Index { get; set; }

		public AlternateTexture()
		{
			Name = "";
			TextureSet = new FormID();
			Index = new Int32();
		}

		public AlternateTexture(String Name, FormID TextureSet, Int32 Index)
		{
			this.Name = Name;
			this.TextureSet = TextureSet;
			this.Index = Index;
		}

		public AlternateTexture(AlternateTexture copyObject)
		{
			Name = (String)copyObject.Name.Clone();
			TextureSet = copyObject.TextureSet.Clone();
			Index = copyObject.Index;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				ReadData(reader);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			WriteData(writer);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Name", true, out subEle);
			subEle.Value = Name.ToString();

			ele.TryPathTo("TextureSet", true, out subEle);
			TextureSet.WriteXML(subEle, master);

			ele.TryPathTo("Index", true, out subEle);
			subEle.Value = Index.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Name", false, out subEle))
			{
				Name = subEle.Value;
			}

			if (ele.TryPathTo("TextureSet", false, out subEle))
			{
				TextureSet.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Index", false, out subEle))
			{
				Index = subEle.ToInt32();
			}
		}

		partial void ReadData(ESPReader reader);

		partial void WriteData(ESPWriter writer);

		public AlternateTexture Clone()
		{
			return new AlternateTexture(this);
		}
	}
}
