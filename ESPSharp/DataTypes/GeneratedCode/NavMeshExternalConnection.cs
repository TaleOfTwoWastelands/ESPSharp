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
	public partial class NavMeshExternalConnection : IESPSerializable, ICloneable<NavMeshExternalConnection>, IReferenceContainer
	{
		public Byte[] Unknown { get; set; }
		public FormID NavigationMesh { get; set; }
		public UInt16 Triangle { get; set; }

		public NavMeshExternalConnection()
		{
			Unknown = new byte[4];
			NavigationMesh = new FormID();
			Triangle = new UInt16();
		}

		public NavMeshExternalConnection(Byte[] Unknown, FormID NavigationMesh, UInt16 Triangle)
		{
			this.Unknown = Unknown;
			this.NavigationMesh = NavigationMesh;
			this.Triangle = Triangle;
		}

		public NavMeshExternalConnection(NavMeshExternalConnection copyObject)
		{
			Unknown = (Byte[])copyObject.Unknown.Clone();
			NavigationMesh = copyObject.NavigationMesh.Clone();
			Triangle = copyObject.Triangle;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Unknown = reader.ReadBytes(4);
				NavigationMesh.ReadBinary(reader);
				Triangle = reader.ReadUInt16();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unknown);
			NavigationMesh.WriteBinary(writer);
			writer.Write(Triangle);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();

			ele.TryPathTo("NavigationMesh", true, out subEle);
			NavigationMesh.WriteXML(subEle, master);

			ele.TryPathTo("Triangle", true, out subEle);
			subEle.Value = Triangle.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}

			if (ele.TryPathTo("NavigationMesh", false, out subEle))
			{
				NavigationMesh.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Triangle", false, out subEle))
			{
				Triangle = subEle.ToUInt16();
			}
		}

		public NavMeshExternalConnection Clone()
		{
			return new NavMeshExternalConnection(this);
		}
	}
}
