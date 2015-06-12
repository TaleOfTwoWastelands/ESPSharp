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
	public partial class FormID : IESPSerializable, ICloneable<FormID>
	{
		public UInt32 RawValue { get; protected set; }

		public FormID()
		{
			RawValue = new UInt32();
		}

		public FormID(UInt32 RawValue)
		{
			this.RawValue = RawValue;
		}

		public FormID(FormID copyObject)
		{
			RawValue = copyObject.RawValue;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				RawValue = reader.ReadUInt32();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(RawValue);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			WriteDataXML(ele, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			ReadDataXML(ele, master);
		}

		partial void ReadDataXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteDataXML(XElement ele, ElderScrollsPlugin master);

		public FormID Clone()
		{
			return new FormID(this);
		}
	}
}
