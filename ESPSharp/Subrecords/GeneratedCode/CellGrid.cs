
















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
	public partial class CellGrid : Subrecord, ICloneable, IComparable<CellGrid>, IEquatable<CellGrid>  
	{
		public Int32 X { get; set; }
		public Int32 Y { get; set; }
		public ForceHideLandFlags ForceHideLand { get; set; }


		public CellGrid(string Tag = null)
			:base(Tag)
		{
			X = new Int32();
			Y = new Int32();
			ForceHideLand = new ForceHideLandFlags();

		}

		public CellGrid(Int32 X, Int32 Y, ForceHideLandFlags ForceHideLand)
		{
			this.X = X;
			this.Y = Y;
			this.ForceHideLand = ForceHideLand;

		}

		public CellGrid(CellGrid copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
			ForceHideLand = copyObject.ForceHideLand;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					X = subReader.ReadInt32();
					Y = subReader.ReadInt32();
					ForceHideLand = subReader.ReadEnum<ForceHideLandFlags>();

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
			writer.Write((UInt32)ForceHideLand);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString();

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString();

			ele.TryPathTo("ForceHideLand", true, out subEle);
			subEle.Value = ForceHideLand.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("X", false, out subEle))
				X = subEle.ToInt32();

			if (ele.TryPathTo("Y", false, out subEle))
				Y = subEle.ToInt32();

			if (ele.TryPathTo("ForceHideLand", false, out subEle))
				ForceHideLand = subEle.ToEnum<ForceHideLandFlags>();

		}

		public override object Clone()
		{
			return new CellGrid(this);
		}


        public int CompareTo(CellGrid other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(CellGrid objA, CellGrid objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(CellGrid objA, CellGrid objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(CellGrid objA, CellGrid objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(CellGrid objA, CellGrid objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(CellGrid other)
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
				ForceHideLand == other.ForceHideLand;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            CellGrid other = obj as CellGrid;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        public static bool operator ==(CellGrid objA, CellGrid objB)
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

        public static bool operator !=(CellGrid objA, CellGrid objB)
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