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
	public partial class PlaneData : Subrecord, ICloneable<PlaneData>
	{
		public Single Width { get; set; }
		public Single Height { get; set; }
		public Single PositionX { get; set; }
		public Single PositionY { get; set; }
		public Single PositionZ { get; set; }
		public Single RotationQuaternion1 { get; set; }
		public Single RotationQuaternion2 { get; set; }
		public Single RotationQuaternion3 { get; set; }
		public Single RotationQuaternion4 { get; set; }

		public PlaneData()
		{
			Width = new Single();
			Height = new Single();
			PositionX = new Single();
			PositionY = new Single();
			PositionZ = new Single();
			RotationQuaternion1 = new Single();
			RotationQuaternion2 = new Single();
			RotationQuaternion3 = new Single();
			RotationQuaternion4 = new Single();
		}

		public PlaneData(Single Width, Single Height, Single PositionX, Single PositionY, Single PositionZ, Single RotationQuaternion1, Single RotationQuaternion2, Single RotationQuaternion3, Single RotationQuaternion4)
		{
			this.Width = Width;
			this.Height = Height;
			this.PositionX = PositionX;
			this.PositionY = PositionY;
			this.PositionZ = PositionZ;
			this.RotationQuaternion1 = RotationQuaternion1;
			this.RotationQuaternion2 = RotationQuaternion2;
			this.RotationQuaternion3 = RotationQuaternion3;
			this.RotationQuaternion4 = RotationQuaternion4;
		}

		public PlaneData(PlaneData copyObject)
		{
			Width = copyObject.Width;
			Height = copyObject.Height;
			PositionX = copyObject.PositionX;
			PositionY = copyObject.PositionY;
			PositionZ = copyObject.PositionZ;
			RotationQuaternion1 = copyObject.RotationQuaternion1;
			RotationQuaternion2 = copyObject.RotationQuaternion2;
			RotationQuaternion3 = copyObject.RotationQuaternion3;
			RotationQuaternion4 = copyObject.RotationQuaternion4;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Width = subReader.ReadSingle();
					Height = subReader.ReadSingle();
					PositionX = subReader.ReadSingle();
					PositionY = subReader.ReadSingle();
					PositionZ = subReader.ReadSingle();
					RotationQuaternion1 = subReader.ReadSingle();
					RotationQuaternion2 = subReader.ReadSingle();
					RotationQuaternion3 = subReader.ReadSingle();
					RotationQuaternion4 = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Width);			
			writer.Write(Height);			
			writer.Write(PositionX);			
			writer.Write(PositionY);			
			writer.Write(PositionZ);			
			writer.Write(RotationQuaternion1);			
			writer.Write(RotationQuaternion2);			
			writer.Write(RotationQuaternion3);			
			writer.Write(RotationQuaternion4);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Width", true, out subEle);
			subEle.Value = Width.ToString("G15");

			ele.TryPathTo("Height", true, out subEle);
			subEle.Value = Height.ToString("G15");

			ele.TryPathTo("Position/X", true, out subEle);
			subEle.Value = PositionX.ToString("G15");

			ele.TryPathTo("Position/Y", true, out subEle);
			subEle.Value = PositionY.ToString("G15");

			ele.TryPathTo("Position/Z", true, out subEle);
			subEle.Value = PositionZ.ToString("G15");

			ele.TryPathTo("Rotation/Quaternion1", true, out subEle);
			subEle.Value = RotationQuaternion1.ToString("G15");

			ele.TryPathTo("Rotation/Quaternion2", true, out subEle);
			subEle.Value = RotationQuaternion2.ToString("G15");

			ele.TryPathTo("Rotation/Quaternion3", true, out subEle);
			subEle.Value = RotationQuaternion3.ToString("G15");

			ele.TryPathTo("Rotation/Quaternion4", true, out subEle);
			subEle.Value = RotationQuaternion4.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Width", false, out subEle))
			{
				Width = subEle.ToSingle();
			}

			if (ele.TryPathTo("Height", false, out subEle))
			{
				Height = subEle.ToSingle();
			}

			if (ele.TryPathTo("Position/X", false, out subEle))
			{
				PositionX = subEle.ToSingle();
			}

			if (ele.TryPathTo("Position/Y", false, out subEle))
			{
				PositionY = subEle.ToSingle();
			}

			if (ele.TryPathTo("Position/Z", false, out subEle))
			{
				PositionZ = subEle.ToSingle();
			}

			if (ele.TryPathTo("Rotation/Quaternion1", false, out subEle))
			{
				RotationQuaternion1 = subEle.ToSingle();
			}

			if (ele.TryPathTo("Rotation/Quaternion2", false, out subEle))
			{
				RotationQuaternion2 = subEle.ToSingle();
			}

			if (ele.TryPathTo("Rotation/Quaternion3", false, out subEle))
			{
				RotationQuaternion3 = subEle.ToSingle();
			}

			if (ele.TryPathTo("Rotation/Quaternion4", false, out subEle))
			{
				RotationQuaternion4 = subEle.ToSingle();
			}
		}

		public PlaneData Clone()
		{
			return new PlaneData(this);
		}

	}
}
