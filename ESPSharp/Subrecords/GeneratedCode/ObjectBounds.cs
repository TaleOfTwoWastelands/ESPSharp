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
	public partial class ObjectBounds : Subrecord, ICloneable<ObjectBounds>
	{
		public Int16 X1 { get; set; }
		public Int16 Y1 { get; set; }
		public Int16 Z1 { get; set; }
		public Int16 X2 { get; set; }
		public Int16 Y2 { get; set; }
		public Int16 Z2 { get; set; }

		public ObjectBounds()
		{
			X1 = new Int16();
			Y1 = new Int16();
			Z1 = new Int16();
			X2 = new Int16();
			Y2 = new Int16();
			Z2 = new Int16();
		}

		public ObjectBounds(Int16 X1, Int16 Y1, Int16 Z1, Int16 X2, Int16 Y2, Int16 Z2)
		{
			this.X1 = X1;
			this.Y1 = Y1;
			this.Z1 = Z1;
			this.X2 = X2;
			this.Y2 = Y2;
			this.Z2 = Z2;
		}

		public ObjectBounds(ObjectBounds copyObject)
		{
			X1 = copyObject.X1;
			Y1 = copyObject.Y1;
			Z1 = copyObject.Z1;
			X2 = copyObject.X2;
			Y2 = copyObject.Y2;
			Z2 = copyObject.Z2;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Master))
			{
				try
				{
					X1 = subReader.ReadInt16();
					Y1 = subReader.ReadInt16();
					Z1 = subReader.ReadInt16();
					X2 = subReader.ReadInt16();
					Y2 = subReader.ReadInt16();
					Z2 = subReader.ReadInt16();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(X1);			
			writer.Write(Y1);			
			writer.Write(Z1);			
			writer.Write(X2);			
			writer.Write(Y2);			
			writer.Write(Z2);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Point1/X", true, out subEle);
			subEle.Value = X1.ToString();

			ele.TryPathTo("Point1/Y", true, out subEle);
			subEle.Value = Y1.ToString();

			ele.TryPathTo("Point1/Z", true, out subEle);
			subEle.Value = Z1.ToString();

			ele.TryPathTo("Point2/X", true, out subEle);
			subEle.Value = X2.ToString();

			ele.TryPathTo("Point2/Y", true, out subEle);
			subEle.Value = Y2.ToString();

			ele.TryPathTo("Point2/Z", true, out subEle);
			subEle.Value = Z2.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Point1/X", false, out subEle))
			{
				X1 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Point1/Y", false, out subEle))
			{
				Y1 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Point1/Z", false, out subEle))
			{
				Z1 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Point2/X", false, out subEle))
			{
				X2 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Point2/Y", false, out subEle))
			{
				Y2 = subEle.ToInt16();
			}

			if (ele.TryPathTo("Point2/Z", false, out subEle))
			{
				Z2 = subEle.ToInt16();
			}
		}

		public ObjectBounds Clone()
		{
			return new ObjectBounds(this);
		}
	}
}
