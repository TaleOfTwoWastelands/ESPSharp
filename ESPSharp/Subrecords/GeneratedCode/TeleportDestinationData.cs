
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
	public partial class TeleportDestinationData : Subrecord, ICloneable, IComparable<TeleportDestinationData>, IEquatable<TeleportDestinationData>  
	{
		public FormID Door { get; set; }
		public Single PositionX { get; set; }
		public Single PositionY { get; set; }
		public Single PositionZ { get; set; }
		public Single RotationX { get; set; }
		public Single RotationY { get; set; }
		public Single RotationZ { get; set; }
		public YesNoUInt Alarm { get; set; }

		public TeleportDestinationData(string Tag = null)
			:base(Tag)
		{
			Door = new FormID();
			PositionX = new Single();
			PositionY = new Single();
			PositionZ = new Single();
			RotationX = new Single();
			RotationY = new Single();
			RotationZ = new Single();
			Alarm = new YesNoUInt();
		}

		public TeleportDestinationData(FormID Door, Single PositionX, Single PositionY, Single PositionZ, Single RotationX, Single RotationY, Single RotationZ, YesNoUInt Alarm)
		{
			this.Door = Door;
			this.PositionX = PositionX;
			this.PositionY = PositionY;
			this.PositionZ = PositionZ;
			this.RotationX = RotationX;
			this.RotationY = RotationY;
			this.RotationZ = RotationZ;
			this.Alarm = Alarm;
		}

		public TeleportDestinationData(TeleportDestinationData copyObject)
		{
			if (copyObject.Door != null)
				Door = (FormID)copyObject.Door.Clone();
			PositionX = copyObject.PositionX;
			PositionY = copyObject.PositionY;
			PositionZ = copyObject.PositionZ;
			RotationX = copyObject.RotationX;
			RotationY = copyObject.RotationY;
			RotationZ = copyObject.RotationZ;
			Alarm = copyObject.Alarm;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Door.ReadBinary(subReader);
					PositionX = subReader.ReadSingle();
					PositionY = subReader.ReadSingle();
					PositionZ = subReader.ReadSingle();
					RotationX = subReader.ReadSingle();
					RotationY = subReader.ReadSingle();
					RotationZ = subReader.ReadSingle();
					Alarm = subReader.ReadEnum<YesNoUInt>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Door.WriteBinary(writer);
			writer.Write(PositionX);
			writer.Write(PositionY);
			writer.Write(PositionZ);
			writer.Write(RotationX);
			writer.Write(RotationY);
			writer.Write(RotationZ);
			writer.Write((UInt32)Alarm);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Door", true, out subEle);
			Door.WriteXML(subEle, master);

			ele.TryPathTo("Position/X", true, out subEle);
			subEle.Value = PositionX.ToString("G15");

			ele.TryPathTo("Position/Y", true, out subEle);
			subEle.Value = PositionY.ToString("G15");

			ele.TryPathTo("Position/Z", true, out subEle);
			subEle.Value = PositionZ.ToString("G15");

			ele.TryPathTo("Rotation/X", true, out subEle);
			subEle.Value = RotationX.ToString("G15");

			ele.TryPathTo("Rotation/Y", true, out subEle);
			subEle.Value = RotationY.ToString("G15");

			ele.TryPathTo("Rotation/Z", true, out subEle);
			subEle.Value = RotationZ.ToString("G15");

			ele.TryPathTo("Alarm", true, out subEle);
			subEle.Value = Alarm.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Door", false, out subEle))
				Door.ReadXML(subEle, master);

			if (ele.TryPathTo("Position/X", false, out subEle))
				PositionX = subEle.ToSingle();

			if (ele.TryPathTo("Position/Y", false, out subEle))
				PositionY = subEle.ToSingle();

			if (ele.TryPathTo("Position/Z", false, out subEle))
				PositionZ = subEle.ToSingle();

			if (ele.TryPathTo("Rotation/X", false, out subEle))
				RotationX = subEle.ToSingle();

			if (ele.TryPathTo("Rotation/Y", false, out subEle))
				RotationY = subEle.ToSingle();

			if (ele.TryPathTo("Rotation/Z", false, out subEle))
				RotationZ = subEle.ToSingle();

			if (ele.TryPathTo("Alarm", false, out subEle))
				Alarm = subEle.ToEnum<YesNoUInt>();
		}

		public override object Clone()
		{
			return new TeleportDestinationData(this);
		}

        public int CompareTo(TeleportDestinationData other)
        {
			return Door.CompareTo(other.Door);
        }

        public static bool operator >(TeleportDestinationData objA, TeleportDestinationData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(TeleportDestinationData objA, TeleportDestinationData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(TeleportDestinationData objA, TeleportDestinationData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(TeleportDestinationData objA, TeleportDestinationData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(TeleportDestinationData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Door == other.Door &&
				PositionX == other.PositionX &&
				PositionY == other.PositionY &&
				PositionZ == other.PositionZ &&
				RotationX == other.RotationX &&
				RotationY == other.RotationY &&
				RotationZ == other.RotationZ &&
				Alarm == other.Alarm;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            TeleportDestinationData other = obj as TeleportDestinationData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Door.GetHashCode();
        }

        public static bool operator ==(TeleportDestinationData objA, TeleportDestinationData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(TeleportDestinationData objA, TeleportDestinationData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }
	}
}