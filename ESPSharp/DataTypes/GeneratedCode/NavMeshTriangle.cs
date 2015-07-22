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
	public partial class NavMeshTriangle : IESPSerializable, ICloneable, IComparable<NavMeshTriangle>, IEquatable<NavMeshTriangle>  
	{
		public Int16 Vertex1 { get; set; }
		public Int16 Vertex2 { get; set; }
		public Int16 Vertex3 { get; set; }
		public Int16 EdgeVertices1_2 { get; set; }
		public Int16 EdgeVertices2_3 { get; set; }
		public Int16 EdgeVertices3_1 { get; set; }
		public NavMeshTriangleFlags Flags { get; set; }

		public NavMeshTriangle()
		{
			Vertex1 = new Int16();
			Vertex2 = new Int16();
			Vertex3 = new Int16();
			EdgeVertices1_2 = new Int16();
			EdgeVertices2_3 = new Int16();
			EdgeVertices3_1 = new Int16();
			Flags = new NavMeshTriangleFlags();
		}

		public NavMeshTriangle(Int16 Vertex1, Int16 Vertex2, Int16 Vertex3, Int16 EdgeVertices1_2, Int16 EdgeVertices2_3, Int16 EdgeVertices3_1, NavMeshTriangleFlags Flags)
		{
			this.Vertex1 = Vertex1;
			this.Vertex2 = Vertex2;
			this.Vertex3 = Vertex3;
			this.EdgeVertices1_2 = EdgeVertices1_2;
			this.EdgeVertices2_3 = EdgeVertices2_3;
			this.EdgeVertices3_1 = EdgeVertices3_1;
			this.Flags = Flags;
		}

		public NavMeshTriangle(NavMeshTriangle copyObject)
		{
			Vertex1 = copyObject.Vertex1;
			Vertex2 = copyObject.Vertex2;
			Vertex3 = copyObject.Vertex3;
			EdgeVertices1_2 = copyObject.EdgeVertices1_2;
			EdgeVertices2_3 = copyObject.EdgeVertices2_3;
			EdgeVertices3_1 = copyObject.EdgeVertices3_1;
			Flags = copyObject.Flags;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Vertex1 = reader.ReadInt16();
					Vertex2 = reader.ReadInt16();
					Vertex3 = reader.ReadInt16();
					EdgeVertices1_2 = reader.ReadInt16();
					EdgeVertices2_3 = reader.ReadInt16();
					EdgeVertices3_1 = reader.ReadInt16();
					Flags = reader.ReadEnum<NavMeshTriangleFlags>();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(Vertex1);
			writer.Write(Vertex2);
			writer.Write(Vertex3);
			writer.Write(EdgeVertices1_2);
			writer.Write(EdgeVertices2_3);
			writer.Write(EdgeVertices3_1);
			writer.Write((UInt32)Flags);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Vertices/Vertex1", true, out subEle);
			subEle.Value = Vertex1.ToString();

			ele.TryPathTo("Vertices/Vertex2", true, out subEle);
			subEle.Value = Vertex2.ToString();

			ele.TryPathTo("Vertices/Vertex3", true, out subEle);
			subEle.Value = Vertex3.ToString();

			ele.TryPathTo("Edges/Vertices1_2", true, out subEle);
			subEle.Value = EdgeVertices1_2.ToString();

			ele.TryPathTo("Edges/Vertices2_3", true, out subEle);
			subEle.Value = EdgeVertices2_3.ToString();

			ele.TryPathTo("Edges/Vertices3_1", true, out subEle);
			subEle.Value = EdgeVertices3_1.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Vertices/Vertex1", false, out subEle))
				Vertex1 = subEle.ToInt16();

			if (ele.TryPathTo("Vertices/Vertex2", false, out subEle))
				Vertex2 = subEle.ToInt16();

			if (ele.TryPathTo("Vertices/Vertex3", false, out subEle))
				Vertex3 = subEle.ToInt16();

			if (ele.TryPathTo("Edges/Vertices1_2", false, out subEle))
				EdgeVertices1_2 = subEle.ToInt16();

			if (ele.TryPathTo("Edges/Vertices2_3", false, out subEle))
				EdgeVertices2_3 = subEle.ToInt16();

			if (ele.TryPathTo("Edges/Vertices3_1", false, out subEle))
				EdgeVertices3_1 = subEle.ToInt16();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<NavMeshTriangleFlags>();
		}

		public object Clone()
		{
			return new NavMeshTriangle(this);
		}

        public int CompareTo(NavMeshTriangle other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(NavMeshTriangle objA, NavMeshTriangle objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavMeshTriangle objA, NavMeshTriangle objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavMeshTriangle objA, NavMeshTriangle objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavMeshTriangle objA, NavMeshTriangle objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(NavMeshTriangle other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Vertex1 == other.Vertex1 &&
				Vertex2 == other.Vertex2 &&
				Vertex3 == other.Vertex3 &&
				EdgeVertices1_2 == other.EdgeVertices1_2 &&
				EdgeVertices2_3 == other.EdgeVertices2_3 &&
				EdgeVertices3_1 == other.EdgeVertices3_1 &&
				Flags == other.Flags;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshTriangle other = obj as NavMeshTriangle;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Vertex1.GetHashCode();
        }

        public static bool operator ==(NavMeshTriangle objA, NavMeshTriangle objB)
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

        public static bool operator !=(NavMeshTriangle objA, NavMeshTriangle objB)
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