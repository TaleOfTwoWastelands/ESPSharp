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
	public partial class NavMeshDoor : IESPSerializable, ICloneable<NavMeshDoor>, IReferenceContainer
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
			Door = copyObject.Door.Clone();
			Triangle = copyObject.Triangle;
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

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Door", false, out subEle))
			{
				Door.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Triangle", false, out subEle))
			{
				Triangle = subEle.ToUInt16();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public NavMeshDoor Clone()
		{
			return new NavMeshDoor(this);
		}
	}
}
