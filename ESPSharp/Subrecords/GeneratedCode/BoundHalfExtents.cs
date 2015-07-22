
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
	public partial class BoundHalfExtents : Subrecord, ICloneable, IComparable<BoundHalfExtents>, IEquatable<BoundHalfExtents>  
	{
		public Single X { get; set; }
		public Single Y { get; set; }
		public Single Z { get; set; }

		public BoundHalfExtents(string Tag = null)
			:base(Tag)
		{
			X = new Single();
			Y = new Single();
			Z = new Single();
		}

		public BoundHalfExtents(Single X, Single Y, Single Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public BoundHalfExtents(BoundHalfExtents copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
			Z = copyObject.Z;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					X = subReader.ReadSingle();
					Y = subReader.ReadSingle();
					Z = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(X);
			writer.Write(Y);
			writer.Write(Z);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString("G15");

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString("G15");

			ele.TryPathTo("Z", true, out subEle);
			subEle.Value = Z.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("X", false, out subEle))
				X = subEle.ToSingle();

			if (ele.TryPathTo("Y", false, out subEle))
				Y = subEle.ToSingle();

			if (ele.TryPathTo("Z", false, out subEle))
				Z = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new BoundHalfExtents(this);
		}

        public int CompareTo(BoundHalfExtents other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(BoundHalfExtents objA, BoundHalfExtents objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(BoundHalfExtents objA, BoundHalfExtents objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(BoundHalfExtents objA, BoundHalfExtents objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(BoundHalfExtents objA, BoundHalfExtents objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(BoundHalfExtents other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return X == other.X &&
				Y == other.Y &&
				Z == other.Z;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            BoundHalfExtents other = obj as BoundHalfExtents;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        public static bool operator ==(BoundHalfExtents objA, BoundHalfExtents objB)
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

        public static bool operator !=(BoundHalfExtents objA, BoundHalfExtents objB)
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