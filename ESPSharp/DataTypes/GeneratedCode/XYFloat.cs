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
	public partial class XYFloat : IESPSerializable, ICloneable<XYFloat>
	{
		public Single X { get; set; }
		public Single Y { get; set; }

		public XYFloat()
		{
			X = new Single();
			Y = new Single();
		}

		public XYFloat(Single X, Single Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public XYFloat(XYFloat copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				X = reader.ReadSingle();
				Y = reader.ReadSingle();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(X);			
			writer.Write(Y);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString("G15");

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString("G15");
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("X", false, out subEle))
			{
				X = subEle.ToSingle();
			}

			if (ele.TryPathTo("Y", false, out subEle))
			{
				Y = subEle.ToSingle();
			}
		}

		public XYFloat Clone()
		{
			return new XYFloat(this);
		}
	}
}
