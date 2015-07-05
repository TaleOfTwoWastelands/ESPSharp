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
	public partial class PackageLocations : SubrecordCollection, ICloneable<PackageLocations>
	{
		public PackageLocation Location1 { get; set; }
		public PackageLocation Location2 { get; set; }

		public PackageLocations()
		{
		}

		public PackageLocations(PackageLocation Location1, PackageLocation Location2)
		{
			this.Location1 = Location1;
			this.Location2 = Location2;
		}

		public PackageLocations(PackageLocations copyObject)
		{
			Location1 = copyObject.Location1.Clone();
			Location2 = copyObject.Location2.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "PLDT":
						if (readTags.Contains("PLDT"))
							return;
						if (Location1 == null)
							Location1 = new PackageLocation();

						Location1.ReadBinary(reader);
						break;
					case "PLD2":
						if (readTags.Contains("PLD2"))
							return;
						if (Location2 == null)
							Location2 = new PackageLocation();

						Location2.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Location1 != null)
				Location1.WriteBinary(writer);
			if (Location2 != null)
				Location2.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (Location1 != null)		
			{		
				ele.TryPathTo("Location1", true, out subEle);
				Location1.WriteXML(subEle, master);
			}
			if (Location2 != null)		
			{		
				ele.TryPathTo("Location2", true, out subEle);
				Location2.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Location1", false, out subEle))
			{
				if (Location1 == null)
					Location1 = new PackageLocation();
					
				Location1.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Location2", false, out subEle))
			{
				if (Location2 == null)
					Location2 = new PackageLocation();
					
				Location2.ReadXML(subEle, master);
			}
		}

		public PackageLocations Clone()
		{
			return new PackageLocations(this);
		}

	}
}
