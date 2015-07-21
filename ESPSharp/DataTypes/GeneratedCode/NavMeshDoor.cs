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
	public partial class NavMeshDoor : IESPSerializable, ICloneable, IComparable<NavMeshDoor>, IEquatable<NavMeshDoor>  
	{
		public FormID Door { get; set; }
		public UInt16 Triangle { get; set; }
		public Byte[] Unused { get; set; }

		public NavMeshDoor()
		{
			Door = new FormID();
			Triangle = new UInt16();
			Unused = new byte[2];
		}

		public NavMeshDoor(FormID Door, UInt16 Triangle, Byte[] Unused)
		{
			this.Door = Door;
			this.Triangle = Triangle;
			this.Unused = Unused;
		}

		public NavMeshDoor(NavMeshDoor copyObject)
		{
			if (copyObject.Door != null)
				Door = (FormID)copyObject.Door.Clone();
			Triangle = copyObject.Triangle;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Door.ReadBinary(reader);
					Triangle = reader.ReadUInt16();
					Unused = reader.ReadBytes(2);
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Door.WriteBinary(writer);
			writer.Write(Triangle);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Door", true, out subEle);
			Door.WriteXML(subEle, master);

			ele.TryPathTo("Triangle", true, out subEle);
			subEle.Value = Triangle.ToString();

			WriteUnusedXML(ele, master);
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Door", false, out subEle))
				Door.ReadXML(subEle, master);

			if (ele.TryPathTo("Triangle", false, out subEle))
				Triangle = subEle.ToUInt16();

			ReadUnusedXML(ele, master);
		}

		public object Clone()
		{
			return new NavMeshDoor(this);
		}

        public int CompareTo(NavMeshDoor other)
        {
			return Door.CompareTo(other.Door);
        }

        public static bool operator >(NavMeshDoor objA, NavMeshDoor objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavMeshDoor objA, NavMeshDoor objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavMeshDoor objA, NavMeshDoor objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavMeshDoor objA, NavMeshDoor objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(NavMeshDoor other)
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
				Triangle == other.Triangle &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshDoor other = obj as NavMeshDoor;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Door.GetHashCode();
        }

        public static bool operator ==(NavMeshDoor objA, NavMeshDoor objB)
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

        public static bool operator !=(NavMeshDoor objA, NavMeshDoor objB)
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

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}