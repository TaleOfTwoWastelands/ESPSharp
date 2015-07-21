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

namespace ESPSharp.SubrecordCollections
{
	public partial class FaceGenData : SubrecordCollection	{
		public SubMarker Marker { get; set; }
		public SimpleSubrecord<Byte[]> GeometrySymmetric { get; set; }
		public SimpleSubrecord<Byte[]> GeometryAsymmetric { get; set; }
		public SimpleSubrecord<Byte[]> TextureSymmetric { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }

		public FaceGenData()
		{
			Marker = new SubMarker();
			GeometrySymmetric = new SimpleSubrecord<Byte[]>();
			GeometryAsymmetric = new SimpleSubrecord<Byte[]>();
			TextureSymmetric = new SimpleSubrecord<Byte[]>();
			Unknown = new SimpleSubrecord<Byte[]>();
		}

		public FaceGenData(SimpleSubrecord<Byte[]> GeometrySymmetric, SimpleSubrecord<Byte[]> GeometryAsymmetric, SimpleSubrecord<Byte[]> TextureSymmetric, SimpleSubrecord<Byte[]> Unknown)
		{
			this.GeometrySymmetric = GeometrySymmetric;
			this.GeometryAsymmetric = GeometryAsymmetric;
			this.TextureSymmetric = TextureSymmetric;
			this.Unknown = Unknown;
		}

		public FaceGenData(FaceGenData copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			readTags.Add(reader.PeekTag());
			Marker.ReadBinary(reader);

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "FGGS":
						if (readTags.Contains("FGGS"))
							return;
						GeometrySymmetric.ReadBinary(reader);
						break;
					case "FGGA":
						if (readTags.Contains("FGGA"))
							return;
						GeometryAsymmetric.ReadBinary(reader);
						break;
					case "FGTS":
						if (readTags.Contains("FGTS"))
							return;
						TextureSymmetric.ReadBinary(reader);
						break;
					case "SNAM":
						if (readTags.Contains("SNAM"))
							return;
						Unknown.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			Marker.WriteBinary(writer);

			if (GeometrySymmetric != null)
				GeometrySymmetric.WriteBinary(writer);
			if (GeometryAsymmetric != null)
				GeometryAsymmetric.WriteBinary(writer);
			if (TextureSymmetric != null)
				TextureSymmetric.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Marker", true, out subEle);
			Marker.WriteXML(subEle, master);

			if (GeometrySymmetric != null)		
			{		
				ele.TryPathTo("Geometry/Symmetric", true, out subEle);
				GeometrySymmetric.WriteXML(subEle, master);
			}
			if (GeometryAsymmetric != null)		
			{		
				ele.TryPathTo("Geometry/Asymmetric", true, out subEle);
				GeometryAsymmetric.WriteXML(subEle, master);
			}
			if (TextureSymmetric != null)		
			{		
				ele.TryPathTo("Texture/Symmetric", true, out subEle);
				TextureSymmetric.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Marker", false, out subEle))
				Marker.ReadXML(subEle, master);

			if (ele.TryPathTo("Geometry/Symmetric", false, out subEle))
			{
				if (GeometrySymmetric == null)
					GeometrySymmetric = new SimpleSubrecord<Byte[]>();
					
				GeometrySymmetric.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Geometry/Asymmetric", false, out subEle))
			{
				if (GeometryAsymmetric == null)
					GeometryAsymmetric = new SimpleSubrecord<Byte[]>();
					
				GeometryAsymmetric.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Texture/Symmetric", false, out subEle))
			{
				if (TextureSymmetric == null)
					TextureSymmetric = new SimpleSubrecord<Byte[]>();
					
				TextureSymmetric.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
		}

		public FaceGenData Clone()
		{
			return new FaceGenData(this);
		}

	}
}
