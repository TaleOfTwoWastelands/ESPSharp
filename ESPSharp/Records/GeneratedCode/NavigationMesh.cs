
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

namespace ESPSharp.Records
{
	public partial class NavigationMesh : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public SimpleSubrecord<UInt32> Version { get; set; }
		public NavMeshData Data { get; set; }
		public SimpleSubrecord<Byte[]> Vertices { get; set; }
		public SimpleSubrecord<Byte[]> Triangles { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }
		public NavMeshDoorList Doors { get; set; }
		public SimpleSubrecord<Byte[]> Grid { get; set; }
		public NavMeshExternalConnectionList ExternalConnections { get; set; }

		public NavigationMesh()
		{
					}

		public NavigationMesh(SimpleSubrecord<String> EditorID, SimpleSubrecord<UInt32> Version, NavMeshData Data, SimpleSubrecord<Byte[]> Vertices, SimpleSubrecord<Byte[]> Triangles, SimpleSubrecord<Byte[]> Unknown, NavMeshDoorList Doors, SimpleSubrecord<Byte[]> Grid, NavMeshExternalConnectionList ExternalConnections)
		{
					}

		public NavigationMesh(NavigationMesh copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "NVER":
						if (Version == null)
							Version = new SimpleSubrecord<UInt32>();

						Version.ReadBinary(reader);
						break;
					case "DATA":
						if (Data == null)
							Data = new NavMeshData();

						Data.ReadBinary(reader);
						break;
					case "NVVX":
						if (Vertices == null)
							Vertices = new SimpleSubrecord<Byte[]>();

						Vertices.ReadBinary(reader);
						break;
					case "NVTR":
						if (Triangles == null)
							Triangles = new SimpleSubrecord<Byte[]>();

						Triangles.ReadBinary(reader);
						break;
					case "NVCA":
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte[]>();

						Unknown.ReadBinary(reader);
						break;
					case "NVDP":
						if (Doors == null)
							Doors = new NavMeshDoorList();

						Doors.ReadBinary(reader);
						break;
					case "NVGD":
						if (Grid == null)
							Grid = new SimpleSubrecord<Byte[]>();

						Grid.ReadBinary(reader);
						break;
					case "NVEX":
						if (ExternalConnections == null)
							ExternalConnections = new NavMeshExternalConnectionList();

						ExternalConnections.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (Version != null)
				Version.WriteBinary(writer);
			if (Data != null)
				Data.WriteBinary(writer);
			if (Vertices != null)
				Vertices.WriteBinary(writer);
			if (Triangles != null)
				Triangles.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (Doors != null)
				Doors.WriteBinary(writer);
			if (Grid != null)
				Grid.WriteBinary(writer);
			if (ExternalConnections != null)
				ExternalConnections.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (Version != null)		
			{		
				ele.TryPathTo("Version", true, out subEle);
				Version.WriteXML(subEle, master);
			}
			if (Data != null)		
			{		
				ele.TryPathTo("Data", true, out subEle);
				Data.WriteXML(subEle, master);
			}
			if (Vertices != null)		
			{		
				ele.TryPathTo("Vertices", true, out subEle);
				Vertices.WriteXML(subEle, master);
			}
			if (Triangles != null)		
			{		
				ele.TryPathTo("Triangles", true, out subEle);
				Triangles.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (Doors != null)		
			{		
				ele.TryPathTo("Doors", true, out subEle);
				Doors.WriteXML(subEle, master);
			}
			if (Grid != null)		
			{		
				ele.TryPathTo("Grid", true, out subEle);
				Grid.WriteXML(subEle, master);
			}
			if (ExternalConnections != null)		
			{		
				ele.TryPathTo("ExternalConnections", true, out subEle);
				ExternalConnections.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Version", false, out subEle))
			{
				if (Version == null)
					Version = new SimpleSubrecord<UInt32>();
					
				Version.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Data", false, out subEle))
			{
				if (Data == null)
					Data = new NavMeshData();
					
				Data.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Vertices", false, out subEle))
			{
				if (Vertices == null)
					Vertices = new SimpleSubrecord<Byte[]>();
					
				Vertices.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Triangles", false, out subEle))
			{
				if (Triangles == null)
					Triangles = new SimpleSubrecord<Byte[]>();
					
				Triangles.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Doors", false, out subEle))
			{
				if (Doors == null)
					Doors = new NavMeshDoorList();
					
				Doors.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Grid", false, out subEle))
			{
				if (Grid == null)
					Grid = new SimpleSubrecord<Byte[]>();
					
				Grid.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ExternalConnections", false, out subEle))
			{
				if (ExternalConnections == null)
					ExternalConnections = new NavMeshExternalConnectionList();
					
				ExternalConnections.ReadXML(subEle, master);
			}
		}		

		public NavigationMesh Clone()
		{
			return new NavigationMesh(this);
		}

	}
}