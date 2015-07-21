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
	public partial class NavMeshDoorList : Subrecord, ICloneable, IEquatable<NavMeshDoorList>, IReferenceContainer  
	{
		public List<NavMeshDoor> Doors { get; set; }

		public NavMeshDoorList(string Tag = null)
			:base(Tag)
		{
			Doors = new List<NavMeshDoor>();
		}

		public NavMeshDoorList(List<NavMeshDoor> Doors)
		{
			this.Doors = Doors;
		}

		public NavMeshDoorList(NavMeshDoorList copyObject)
		{
			if (copyObject.Doors != null)
				foreach(var temp in copyObject.Doors)
					Doors.Add((NavMeshDoor)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/8; i++)
					{
						var temp = new NavMeshDoor();
						temp.ReadBinary(subReader);
						Doors.Add(temp);
					}
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			foreach (var temp in Doors)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Doors", true, out subEle);
			foreach (var temp in Doors)
			{
				XElement e = new XElement("Door");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Doors", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new NavMeshDoor();
					temp.ReadXML(e, master);
					Doors.Add(temp);
				}
		}

		public override object Clone()
		{
			return new NavMeshDoorList(this);
		}

        public bool Equals(NavMeshDoorList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Doors.SequenceEqual(other.Doors);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshDoorList other = obj as NavMeshDoorList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Doors.GetHashCode();
        }

        public static bool operator ==(NavMeshDoorList objA, NavMeshDoorList objB)
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

        public static bool operator !=(NavMeshDoorList objA, NavMeshDoorList objB)
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