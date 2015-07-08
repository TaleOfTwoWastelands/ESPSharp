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
	public partial class NavigationDoorLink : Subrecord, ICloneable<NavigationDoorLink>, IReferenceContainer
	{
		public FormID NavigationMesh { get; set; }
		public Byte[] Unknown { get; set; }

		public NavigationDoorLink()
		{
			NavigationMesh = new FormID();
			Unknown = new byte[4];
		}

		public NavigationDoorLink(FormID NavigationMesh, Byte[] Unknown)
		{
			this.NavigationMesh = NavigationMesh;
			this.Unknown = Unknown;
		}

		public NavigationDoorLink(NavigationDoorLink copyObject)
		{
			NavigationMesh = copyObject.NavigationMesh.Clone();
			Unknown = (Byte[])copyObject.Unknown.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					NavigationMesh.ReadBinary(subReader);
					Unknown = subReader.ReadBytes(4);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			NavigationMesh.WriteBinary(writer);
			if (Unknown == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unknown);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("NavigationMesh", true, out subEle);
			NavigationMesh.WriteXML(subEle, master);

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("NavigationMesh", false, out subEle))
			{
				NavigationMesh.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				Unknown = subEle.ToBytes();
			}
		}

		public NavigationDoorLink Clone()
		{
			return new NavigationDoorLink(this);
		}

	}
}
