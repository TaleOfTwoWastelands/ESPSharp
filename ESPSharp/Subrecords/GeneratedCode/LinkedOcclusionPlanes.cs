
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
	public partial class LinkedOcclusionPlanes : Subrecord, ICloneable, IComparable<LinkedOcclusionPlanes>, IEquatable<LinkedOcclusionPlanes>  
	{
		public FormID Right { get; set; }
		public FormID Left { get; set; }
		public FormID Bottom { get; set; }
		public FormID Top { get; set; }

		public LinkedOcclusionPlanes(string Tag = null)
			:base(Tag)
		{
			Right = new FormID();
			Left = new FormID();
			Bottom = new FormID();
			Top = new FormID();
		}

		public LinkedOcclusionPlanes(FormID Right, FormID Left, FormID Bottom, FormID Top)
		{
			this.Right = Right;
			this.Left = Left;
			this.Bottom = Bottom;
			this.Top = Top;
		}

		public LinkedOcclusionPlanes(LinkedOcclusionPlanes copyObject)
		{
			if (copyObject.Right != null)
				Right = (FormID)copyObject.Right.Clone();
			if (copyObject.Left != null)
				Left = (FormID)copyObject.Left.Clone();
			if (copyObject.Bottom != null)
				Bottom = (FormID)copyObject.Bottom.Clone();
			if (copyObject.Top != null)
				Top = (FormID)copyObject.Top.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Right.ReadBinary(subReader);
					Left.ReadBinary(subReader);
					Bottom.ReadBinary(subReader);
					Top.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Right.WriteBinary(writer);
			Left.WriteBinary(writer);
			Bottom.WriteBinary(writer);
			Top.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Right", true, out subEle);
			Right.WriteXML(subEle, master);

			ele.TryPathTo("Left", true, out subEle);
			Left.WriteXML(subEle, master);

			ele.TryPathTo("Bottom", true, out subEle);
			Bottom.WriteXML(subEle, master);

			ele.TryPathTo("Top", true, out subEle);
			Top.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Right", false, out subEle))
				Right.ReadXML(subEle, master);

			if (ele.TryPathTo("Left", false, out subEle))
				Left.ReadXML(subEle, master);

			if (ele.TryPathTo("Bottom", false, out subEle))
				Bottom.ReadXML(subEle, master);

			if (ele.TryPathTo("Top", false, out subEle))
				Top.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new LinkedOcclusionPlanes(this);
		}

        public int CompareTo(LinkedOcclusionPlanes other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LinkedOcclusionPlanes other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Right == other.Right &&
				Left == other.Left &&
				Bottom == other.Bottom &&
				Top == other.Top;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LinkedOcclusionPlanes other = obj as LinkedOcclusionPlanes;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Right.GetHashCode();
        }

        public static bool operator ==(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
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

        public static bool operator !=(LinkedOcclusionPlanes objA, LinkedOcclusionPlanes objB)
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