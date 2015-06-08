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
	public partial class FactionRank : SubrecordCollection, ICloneable<FactionRank>
	{
		public SimpleSubrecord<Int32> Rank { get; set; }
		public SimpleSubrecord<String> MaleTitle { get; set; }
		public SimpleSubrecord<String> FemaleTitle { get; set; }
		public SimpleSubrecord<String> Insignia { get; set; }

		public FactionRank()
		{
			Rank = new SimpleSubrecord<Int32>();
		}

		public FactionRank(SimpleSubrecord<Int32> Rank, SimpleSubrecord<String> MaleTitle, SimpleSubrecord<String> FemaleTitle, SimpleSubrecord<String> Insignia)
		{
			this.Rank = Rank;
			this.MaleTitle = MaleTitle;
			this.FemaleTitle = FemaleTitle;
			this.Insignia = Insignia;
		}

		public FactionRank(FactionRank copyObject)
		{
			Rank = copyObject.Rank.Clone();
			MaleTitle = copyObject.MaleTitle.Clone();
			FemaleTitle = copyObject.FemaleTitle.Clone();
			Insignia = copyObject.Insignia.Clone();
		}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "RNAM":
						if (readTags.Contains("RNAM"))
							return;
						Rank.ReadBinary(reader);
						break;
					case "MNAM":
						if (readTags.Contains("MNAM"))
							return;
						if (MaleTitle == null)
							MaleTitle = new SimpleSubrecord<String>();

						MaleTitle.ReadBinary(reader);
						break;
					case "FNAM":
						if (readTags.Contains("FNAM"))
							return;
						if (FemaleTitle == null)
							FemaleTitle = new SimpleSubrecord<String>();

						FemaleTitle.ReadBinary(reader);
						break;
					case "INAM":
						if (readTags.Contains("INAM"))
							return;
						if (Insignia == null)
							Insignia = new SimpleSubrecord<String>();

						Insignia.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (Rank != null)
				Rank.WriteBinary(writer);
			if (MaleTitle != null)
				MaleTitle.WriteBinary(writer);
			if (FemaleTitle != null)
				FemaleTitle.WriteBinary(writer);
			if (Insignia != null)
				Insignia.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele)
		{
			XElement subEle;
			if (Rank != null)		
			{		
				ele.TryPathTo("Rank", true, out subEle);
				Rank.WriteXML(subEle);
			}
			if (MaleTitle != null)		
			{		
				ele.TryPathTo("Title/Male", true, out subEle);
				MaleTitle.WriteXML(subEle);
			}
			if (FemaleTitle != null)		
			{		
				ele.TryPathTo("Title/Female", true, out subEle);
				FemaleTitle.WriteXML(subEle);
			}
			if (Insignia != null)		
			{		
				ele.TryPathTo("Insignia", true, out subEle);
				Insignia.WriteXML(subEle);
			}
		}

		public override void ReadXML(XElement ele)
		{
			XElement subEle;

			if (ele.TryPathTo("Rank", false, out subEle))
			{
				if (Rank == null)
					Rank = new SimpleSubrecord<Int32>();
					
				Rank.ReadXML(subEle);
			}
			if (ele.TryPathTo("Title/Male", false, out subEle))
			{
				if (MaleTitle == null)
					MaleTitle = new SimpleSubrecord<String>();
					
				MaleTitle.ReadXML(subEle);
			}
			if (ele.TryPathTo("Title/Female", false, out subEle))
			{
				if (FemaleTitle == null)
					FemaleTitle = new SimpleSubrecord<String>();
					
				FemaleTitle.ReadXML(subEle);
			}
			if (ele.TryPathTo("Insignia", false, out subEle))
			{
				if (Insignia == null)
					Insignia = new SimpleSubrecord<String>();
					
				Insignia.ReadXML(subEle);
			}
		}

		public FactionRank Clone()
		{
			return new FactionRank(this);
		}

	}
}
