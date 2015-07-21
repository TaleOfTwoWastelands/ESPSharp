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
	public partial class XYZFloat : IESPSerializable, ICloneable, IComparable<XYZFloat>, IEquatable<XYZFloat>  
	{
		public Single X { get; set; }
		public Single Y { get; set; }
		public Single Z { get; set; }

		public XYZFloat()
		{
			X = new Single();
			Y = new Single();
			Z = new Single();
		}

		public XYZFloat(Single X, Single Y, Single Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public XYZFloat(XYZFloat copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
			Z = copyObject.Z;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				X = reader.ReadSingle();
					Y = reader.ReadSingle();
					Z = reader.ReadSingle();
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
			writer.Write(Z);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString("G15");

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString("G15");

			ele.TryPathTo("Z", true, out subEle);
			subEle.Value = Z.ToString("G15");
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("X", false, out subEle))
				X = subEle.ToSingle();

			if (ele.TryPathTo("Y", false, out subEle))
				Y = subEle.ToSingle();

			if (ele.TryPathTo("Z", false, out subEle))
				Z = subEle.ToSingle();
		}

		public object Clone()
		{
			return new XYZFloat(this);
		}

        public int CompareTo(XYZFloat other)
        {
			return X.CompareTo(other.X);
        }

        public static bool operator >(XYZFloat objA, XYZFloat objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(XYZFloat objA, XYZFloat objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(XYZFloat objA, XYZFloat objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(XYZFloat objA, XYZFloat objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(XYZFloat other)
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

            XYZFloat other = obj as XYZFloat;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        public static bool operator ==(XYZFloat objA, XYZFloat objB)
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

        public static bool operator !=(XYZFloat objA, XYZFloat objB)
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