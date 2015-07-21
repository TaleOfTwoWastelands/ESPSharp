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
	public partial class Color : IESPSerializable, ICloneable, IComparable<Color>, IEquatable<Color>  
	{
		public Byte Red { get; set; }
		public Byte Green { get; set; }
		public Byte Blue { get; set; }
		public Byte Alpha_Unused { get; set; }

		public Color()
		{
			Red = new Byte();
			Green = new Byte();
			Blue = new Byte();
			Alpha_Unused = new Byte();
		}

		public Color(Byte Red, Byte Green, Byte Blue, Byte Alpha_Unused)
		{
			this.Red = Red;
			this.Green = Green;
			this.Blue = Blue;
			this.Alpha_Unused = Alpha_Unused;
		}

		public Color(Color copyObject)
		{
			Red = copyObject.Red;
			Green = copyObject.Green;
			Blue = copyObject.Blue;
			Alpha_Unused = copyObject.Alpha_Unused;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Red = reader.ReadByte();
					Green = reader.ReadByte();
					Blue = reader.ReadByte();
					Alpha_Unused = reader.ReadByte();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(Red);
			writer.Write(Green);
			writer.Write(Blue);
			writer.Write(Alpha_Unused);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Red", true, out subEle);
			subEle.Value = Red.ToString();

			ele.TryPathTo("Green", true, out subEle);
			subEle.Value = Green.ToString();

			ele.TryPathTo("Blue", true, out subEle);
			subEle.Value = Blue.ToString();

			ele.TryPathTo("Alpha_Unused", true, out subEle);
			subEle.Value = Alpha_Unused.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Red", false, out subEle))
				Red = subEle.ToByte();

			if (ele.TryPathTo("Green", false, out subEle))
				Green = subEle.ToByte();

			if (ele.TryPathTo("Blue", false, out subEle))
				Blue = subEle.ToByte();

			if (ele.TryPathTo("Alpha_Unused", false, out subEle))
				Alpha_Unused = subEle.ToByte();
		}

		public object Clone()
		{
			return new Color(this);
		}

        public int CompareTo(Color other)
        {
			return Red.CompareTo(other.Red);
        }

        public static bool operator >(Color objA, Color objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(Color objA, Color objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(Color objA, Color objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(Color objA, Color objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(Color other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Red == other.Red &&
				Green == other.Green &&
				Blue == other.Blue &&
				Alpha_Unused == other.Alpha_Unused;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            Color other = obj as Color;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Red.GetHashCode();
        }

        public static bool operator ==(Color objA, Color objB)
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

        public static bool operator !=(Color objA, Color objB)
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