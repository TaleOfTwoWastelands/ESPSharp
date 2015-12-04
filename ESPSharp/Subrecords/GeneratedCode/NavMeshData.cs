
















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
	public partial class NavMeshData : Subrecord, ICloneable, IComparable<NavMeshData>, IEquatable<NavMeshData>  
	{
		public FormID Cell { get; set; }
		public UInt32 VertexCount { get; set; }
		public UInt32 TriangleCount { get; set; }
		public UInt32 ExternalConnectionsCount { get; set; }
		public UInt32 NVCACount { get; set; }
		public UInt32 DoorsCount { get; set; }


		public NavMeshData(string Tag = null)
			:base(Tag)
		{
			Cell = new FormID();
			VertexCount = new UInt32();
			TriangleCount = new UInt32();
			ExternalConnectionsCount = new UInt32();
			NVCACount = new UInt32();
			DoorsCount = new UInt32();

		}

		public NavMeshData(FormID Cell, UInt32 VertexCount, UInt32 TriangleCount, UInt32 ExternalConnectionsCount, UInt32 NVCACount, UInt32 DoorsCount)
		{
			this.Cell = Cell;
			this.VertexCount = VertexCount;
			this.TriangleCount = TriangleCount;
			this.ExternalConnectionsCount = ExternalConnectionsCount;
			this.NVCACount = NVCACount;
			this.DoorsCount = DoorsCount;

		}

		public NavMeshData(NavMeshData copyObject)
		{
			if (copyObject.Cell != null)
				Cell = (FormID)copyObject.Cell.Clone();
			VertexCount = copyObject.VertexCount;
			TriangleCount = copyObject.TriangleCount;
			ExternalConnectionsCount = copyObject.ExternalConnectionsCount;
			NVCACount = copyObject.NVCACount;
			DoorsCount = copyObject.DoorsCount;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Cell.ReadBinary(subReader);
					VertexCount = subReader.ReadUInt32();
					TriangleCount = subReader.ReadUInt32();
					ExternalConnectionsCount = subReader.ReadUInt32();
					NVCACount = subReader.ReadUInt32();
					DoorsCount = subReader.ReadUInt32();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Cell.WriteBinary(writer);
			writer.Write(VertexCount);
			writer.Write(TriangleCount);
			writer.Write(ExternalConnectionsCount);
			writer.Write(NVCACount);
			writer.Write(DoorsCount);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Cell", true, out subEle);
			Cell.WriteXML(subEle, master);

			ele.TryPathTo("VertexCount", true, out subEle);
			subEle.Value = VertexCount.ToString();

			ele.TryPathTo("TriangleCount", true, out subEle);
			subEle.Value = TriangleCount.ToString();

			ele.TryPathTo("ExternalConnectionsCount", true, out subEle);
			subEle.Value = ExternalConnectionsCount.ToString();

			ele.TryPathTo("NVCACount", true, out subEle);
			subEle.Value = NVCACount.ToString();

			ele.TryPathTo("DoorsCount", true, out subEle);
			subEle.Value = DoorsCount.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Cell", false, out subEle))
				Cell.ReadXML(subEle, master);

			if (ele.TryPathTo("VertexCount", false, out subEle))
				VertexCount = subEle.ToUInt32();

			if (ele.TryPathTo("TriangleCount", false, out subEle))
				TriangleCount = subEle.ToUInt32();

			if (ele.TryPathTo("ExternalConnectionsCount", false, out subEle))
				ExternalConnectionsCount = subEle.ToUInt32();

			if (ele.TryPathTo("NVCACount", false, out subEle))
				NVCACount = subEle.ToUInt32();

			if (ele.TryPathTo("DoorsCount", false, out subEle))
				DoorsCount = subEle.ToUInt32();

		}

		public override object Clone()
		{
			return new NavMeshData(this);
		}


        public int CompareTo(NavMeshData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(NavMeshData objA, NavMeshData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavMeshData objA, NavMeshData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavMeshData objA, NavMeshData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavMeshData objA, NavMeshData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(NavMeshData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Cell == other.Cell &&
				VertexCount == other.VertexCount &&
				TriangleCount == other.TriangleCount &&
				ExternalConnectionsCount == other.ExternalConnectionsCount &&
				NVCACount == other.NVCACount &&
				DoorsCount == other.DoorsCount;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshData other = obj as NavMeshData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Cell.GetHashCode();
        }

        public static bool operator ==(NavMeshData objA, NavMeshData objB)
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

        public static bool operator !=(NavMeshData objA, NavMeshData objB)
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